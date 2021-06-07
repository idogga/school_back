using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using School.BL.Pupil;
using School.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Bl.Test.Classes
{
    [TestFixture]
    public class ClassAddTests :  BaseTest
    {
        private ClassService _classService;

        [SetUp]
        public override void StartAllServices()
        {
            base.StartAllServices();
            _classService = new ClassService(Context);
        }

        [Test]
        [Category("positive")]
        public async Task CreateClass_AddClass_ReturnId()
        {
            // Prepare
            var clas = new Class(1, 'A');

            // Act
            var classId = await _classService.CreateAsync(clas);

            // Assert
            var actualClass = await Context.Classes.FirstOrDefaultAsync(x => x.Id == classId);
            actualClass.Should().BeEquivalentTo(clas,
                opts => opts.Excluding(t => t.Id));
        }

        [Test]
        [Category("negative")]
        public async Task CreateClassBellowZero_AddClass_ReturnError()
        {
            // Prepare
            var clas = new Class(-1, 'a');

            // Act
            Action act = () => { _classService.CreateAsync(clas).Wait(); };

            // Assert
            act.Should().Throw<ApplicationException>();
            var hasAnyClasss = await Context.Classes.AnyAsync();
            hasAnyClasss.Should().BeFalse();
        }
    }
}
