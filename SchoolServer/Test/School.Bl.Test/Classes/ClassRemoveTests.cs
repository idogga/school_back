using FluentAssertions;
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
    public class ClassRemoveTests : BaseTest
    {
        private ClassService _classService;
        private Class _class;

        [SetUp]
        public override void StartAllServices()
        {
            base.StartAllServices();
            _classService = new ClassService(Context);
            _class = new Class(1, 'b')
            {
                Id = Guid.NewGuid()
            };
            Context.Classes.Add(_class);

            Context.SaveChanges();
        }

        [Test]
        [Category("negative")]
        public void NoClass_RemoveClass_ReturnError()
        {
            // Prepare
            var randomGuid = Guid.NewGuid();

            // Act
            Action act = () => { _classService.DeleteAsync(randomGuid).Wait(); };

            // Assert
            act.Should().Throw<NotFoundEntityException>();
        }
    }
}
