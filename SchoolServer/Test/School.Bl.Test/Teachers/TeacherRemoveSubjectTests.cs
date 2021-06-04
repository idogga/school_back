using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using School.BL.Professor;
using School.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Bl.Test.Teachers
{
    public class TeacherRemoveSubjectTests : BaseTest
    {
        private TeacherService _teacherService;

        private Teacher _teacher;

        private Subject _subject;

        [SetUp]
        public override void StartAllServices()
        {
            base.StartAllServices();
            _teacherService = new TeacherService(Context);
            _teacher = new Teacher("teacher_name")
            {
                Id = Guid.NewGuid()
            };
            Context.Teachers.Add(_teacher);

            _subject = new Subject("subject")
            {
                Id = Guid.NewGuid(),
                MaxPerWeek = 10
            };
            Context.Subjects.Add(_subject);

            Context.SaveChanges();
        }

        [Test]
        [Category("positive")]
        public async Task ExistTeacher_RemoveSubject_Success()
        {
            // Prepare
            var t = await Context.Teachers.Include(t => t.Subjects).FirstAsync(x => x.Id == _teacher.Id);
            var s = await Context.Subjects.FindAsync(_subject.Id);
            t.Subjects.Add(s);
            Context.SaveChanges();

            // Act
            await _teacherService.DeleteSubjectAsync(_teacher.Id, _subject.Id);

            // Assert
            var expectTeacher = await Context.Teachers
                .Include(t => t.Subjects)
                .FirstAsync(x => x.Id == _teacher.Id);

            expectTeacher.Subjects.Should().BeEmpty();
        }

        [Test]
        [Category("negative")]
        public async Task ExistTeacherWithSubject_RemoveSubject_ReturnError()
        {
            // Prepare

            // Act
            Action act = () => { _teacherService.DeleteSubjectAsync(_teacher.Id, _subject.Id).Wait(); };

            // Assert
            act.Should().Throw<NotFoundEntityException>();

            var expectTeacher = await Context.Teachers.Include(t => t.Subjects).FirstAsync(x => x.Id == _teacher.Id);
            expectTeacher.Subjects.Should().BeEmpty();
        }

        [Test]
        [Category("negative")]
        public async Task NoTeacher_RemoveSubject_ReturnError()
        {
            // Prepare
            var randomTeacherId = Guid.NewGuid();

            // Act
            Action act = () => { _teacherService.DeleteSubjectAsync(randomTeacherId, _subject.Id).Wait(); };

            // Assert
            act.Should().Throw<NotFoundEntityException>();

            var expectTeacher = await Context.Teachers.Include(t => t.Subjects).FirstAsync(x => x.Id == _teacher.Id);
            expectTeacher.Subjects.Should().BeEmpty();
        }


        [Test]
        [Category("negative")]
        public async Task NoSubject_RemoveSubject_ReturnError()
        {
            // Prepare
            var randomSubjectId = Guid.NewGuid();

            // Act
            Action act = () => { _teacherService.DeleteSubjectAsync(_teacher.Id, randomSubjectId).Wait(); };

            // Assert
            act.Should().Throw<NotFoundEntityException>();

            var expectTeacher = await Context.Teachers.Include(t => t.Subjects).FirstAsync(x => x.Id == _teacher.Id);
            expectTeacher.Subjects.Should().BeEmpty();
        }
    }
}
