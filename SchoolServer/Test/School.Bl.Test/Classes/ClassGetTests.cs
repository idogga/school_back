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
    public class ClassGetTests : BaseTest
    {
        private ClassService _classService;

        [SetUp]
        public override void StartAllServices()
        {
            base.StartAllServices();
            _classService = new ClassService(Context);
            var clas = new Class(3, 'a')
            {
                Id = Guid.NewGuid()
            };
            Context.Classes.Add(clas);
            Context.SaveChanges();
        }

        [Test]
        [Category("positive")]
        public async Task ExistClass_GetClass_ClassReturn()
        {
            // Prepare
            var expectClass = await Context.Classes.FirstAsync(x => x.Litera == 'a');

            // Act
            var actualClass = await _classService.ReadAsync(expectClass.Id);

            // Assert
            actualClass.Should().BeEquivalentTo(expectClass);
        }

        [Test]
        [Category("negative")]
        public void NoClass_GetClass_ReturnError()
        {
            // Prepare
            var randomGuid = Guid.NewGuid();

            // Act
            Action act = () => { _classService.ReadAsync(randomGuid).Wait(); };

            // Assert
            act.Should().Throw<NotFoundEntityException>();
        }
    }
}
