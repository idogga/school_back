using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using School.BL.Professor;
using School.Database;
using System;
using System.Threading.Tasks;

namespace School.Bl.Test.Teachers
{
    public class TeacherAddSubjectTests : BaseTest
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
        public async Task ExistTeacher_AddSubject_Success()
        {
            // Prepare

            // Act
            await _teacherService.AddSubjectAsync(_teacher.Id, _subject.Id);

            // Assert
            var expectTeacher = await Context.Teachers
                .Include(t => t.Subjects)
                .FirstAsync(x => x.Id == _teacher.Id);

            expectTeacher.Subjects.Should().HaveCount(1);

            expectTeacher.Subjects.Should().ContainEquivalentOf(_subject);
        }

        [Test]
        [Category("negative")]
        public async Task ExistTeacherWithSubject_AddSubject_ReturnError()
        {
            // Prepare
            var t = await Context.Teachers.Include(t => t.Subjects).FirstAsync(x => x.Id == _teacher.Id);
            var s = await Context.Subjects.FindAsync(_subject.Id);
            t.Subjects.Add(s);
            Context.SaveChanges();

            // Act
            Action act = () => { _teacherService.AddSubjectAsync(t.Id, s.Id).Wait(); };

            // Assert
            act.Should().Throw<ApplicationException>();

            var expectTeacher = await Context.Teachers.Include(t => t.Subjects).FirstAsync(x => x.Id == _teacher.Id);
            expectTeacher.Subjects.Should().HaveCount(1);

        }

        [Test]
        [Category("negative")]
        public void NoTeacher_AddSubject_ReturnError()
        {
            // Prepare
            var randomTeacherId = Guid.NewGuid();

            // Act
            Action act = () => { _teacherService.AddSubjectAsync(randomTeacherId, _subject.Id).Wait(); };

            // Assert
            act.Should().Throw<NotFoundEntityException>();
        }


        [Test]
        [Category("negative")]
        public void NoSubject_AddSubject_ReturnError()
        {
            // Prepare
            var randomSubjectId = Guid.NewGuid();

            // Act
            Action act = () => { _teacherService.AddSubjectAsync(_teacher.Id, randomSubjectId).Wait(); };

            // Assert
            act.Should().Throw<NotFoundEntityException>();
        }
    }
}
