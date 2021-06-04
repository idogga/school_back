using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using School.BL.Professor;
using School.Database;
using System;
using System.Threading.Tasks;

namespace School.Bl.Test.Teachers
{
    public class TeacherRemoveTests : BaseTest
    {
        private TeacherService _teacherService;
        private Teacher _teacher;

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

            Context.SaveChanges();
        }

        [Test]
        [Category("positive")]
        public async Task ExistTeacher_RemoveTeacher_Success()
        {
            // Prepare
            var subject = new Subject("subject")
            {
                Id = Guid.NewGuid(),
                MaxPerWeek = 10
            };
            Context.Subjects.Add(subject);
            var teacher = await Context.Teachers.FirstAsync(x => x.Name == "teacher_name");
            teacher.Subjects.Add(subject);
            await Context.SaveChangesAsync();

            // Act
            await _teacherService.DeleteAsync(teacher.Id);

            // Assert
            var actualTeacher = await Context.Teachers.FindAsync(teacher.Id);
            actualTeacher.Should().BeNull();
            
            var actualSubject = await Context.Subjects.FindAsync(subject.Id);
            actualSubject.Should().BeEquivalentTo(subject);
        }

        [Test]
        [Category("negative")]
        public void NoTeacher_RemoveTeacher_ReturnError()
        {
            // Prepare
            var randomGuid = Guid.NewGuid();

            // Act
            Action act = () => { _teacherService.DeleteAsync(randomGuid).Wait(); };

            // Assert
            act.Should().Throw<NotFoundEntityException>();
        }
    }
}
