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
    public class TeacherGetTests : BaseTest
    {
        private TeacherService _teacherService;

        [SetUp]
        public override void StartAllServices()
        {
            base.StartAllServices();
            _teacherService = new TeacherService(Context);
            var teacher = new Teacher("teacher_name")
            {
                Id = Guid.NewGuid()
            };
            Context.Teachers.Add(teacher);
            Context.SaveChanges();
        }

        [Test]
        [Category("positive")]
        public async Task ExistTeacher_GetTeacher_TeacherReturn()
        {
            // Prepare
            var expectTeacher = await Context.Teachers.FirstAsync(x => x.Name == "teacher_name");

            // Act
            var actualTeacher = await _teacherService.ReadAsync(expectTeacher.Id);

            // Assert
            actualTeacher.Should().BeEquivalentTo(expectTeacher);
        }

        [Test]
        [Category("positive")]
        public async Task ExistTeacherWithSubjects_GetTeacher_TeacherWithSubjectsReturn()
        {
            // Prepare
            var subject = new Subject("subject")
            {
                Id = Guid.NewGuid(),
                MaxPerWeek = 10
            };
            Context.Subjects.Add(subject);
            var expectTeacher = await Context.Teachers
                .Include(t => t.Subjects)
                .FirstAsync(x => x.Name == "teacher_name");
            expectTeacher.Subjects.Add(subject);
            await Context.SaveChangesAsync();

            // Act
            var actualTeacher = await _teacherService.ReadAsync(expectTeacher.Id);

            // Assert
            actualTeacher.Should().BeEquivalentTo(expectTeacher, opts => 
                opts.Excluding(t => t.Subjects));

            actualTeacher.Subjects.Should().NotBeEmpty();
            actualTeacher.Subjects.First().Should().BeEquivalentTo(expectTeacher.Subjects.First());
        }

        [Test]
        [Category("negative")]
        public void NoTeacher_GetTeacher_ReturnError()
        {
            // Prepare
            var randomGuid = Guid.NewGuid();

            // Act
            Action act = () => { _teacherService.ReadAsync(randomGuid).Wait(); };

            // Assert
            act.Should().Throw<NotFoundEntityException>();
        }
    }
}
