using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using School.BL.Professor;
using School.Database;
using System;
using System.Threading.Tasks;

namespace School.Bl.Test.Teachers
{
    [TestFixture]
    public class TeacherAddTests : BaseTest
    {
        private TeacherService _teacherService;

        [SetUp]
        public override void StartAllServices()
        {
            base.StartAllServices();
            _teacherService = new TeacherService(Context);
        }

        [Test]
        [Category("positive")]
        public async Task CreateTeacher_AddTeacher_ReturnId()
        {
            // Prepare
            var teacher = new Teacher("name");

            // Act
            var teacherId = await _teacherService.CreateAsync(teacher);

            // Assert
            var actualTeacher = await Context.Teachers.FirstOrDefaultAsync(x => x.Id == teacherId);
            actualTeacher.Should().BeEquivalentTo(teacher, 
                opts => opts.Excluding(t=>t.Id)
                    .Excluding(t=>t.Subjects));
        }

        [Test]
        [Category("negative")]
        public async Task CreateTeacherWithoutName_AddTeacher_ReturnError()
        {
            // Prepare
            var teacher = new Teacher(string.Empty);

            // Act
            Action act = () => { _teacherService.CreateAsync(teacher).Wait(); };

            // Assert
            act.Should().Throw<ApplicationException>();
            var hasAnyTeachers = await Context.Teachers.AnyAsync();
            hasAnyTeachers.Should().BeFalse();
        }
    }
}
