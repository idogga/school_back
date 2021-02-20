namespace School.Bl.Test.Place
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using FluentAssertions;

    using Microsoft.EntityFrameworkCore;

    using NUnit.Framework;

    using School.BL.Place;
    using School.Database;

    [TestFixture]
    public class PlaceTests : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            _cabinetService = new CabinetService(Context);
        }

        private CabinetService _cabinetService;

        [TestCase("first", Category = "positive")]
        [TestCase("second", Category = "positive")]
        [TestCase("Third", Category = "positive")]
        public async Task AddPlace(string name)
        {
            // Prepare
            var model = new Cabinete { Name = name };

            // Act
            var resultId = await _cabinetService.CreateAsync(model);

            // Assert
            var toGuid = Guid.TryParse(resultId, out _);
            toGuid.Should().BeTrue();
        }

        [TestCase("name", Category = "negative")]
        [TestCase("Name", Category = "negative")]
        public async Task AddDuplicatePlace(string name)
        {
            // Prepare
            Context.Add(new Cabinete { Name = "name" });
            await Context.SaveChangesAsync();
            var model = new Cabinete { Name = name };

            // Act
            Action act = () => { _cabinetService.CreateAsync(model).Wait(); };

            // Assert
            act.Should().Throw<ApplicationException>();
        }

        [Test]
        [Category("negative")]
        public async Task RemoveDuplicatePlace()
        {
            // Prepare
            var id = Guid.NewGuid().ToString();

            // Act
            Action act = () => { _cabinetService.DeleteAsync(id).Wait(); };

            // Assert
            act.Should().Throw<ApplicationException>();
            var allCabinetes = await Context.Cabinetes.Where(x => x.Id == id).ToListAsync();
            allCabinetes.Should().BeEmpty();
        }

        [Test]
        [Category("positive")]
        public async Task RemovePlace()
        {
            // Prepare
            var id = Guid.NewGuid().ToString();
            Context.Add(new Cabinete { Name = "name", Id = id });
            await Context.SaveChangesAsync();

            // Act
            await _cabinetService.DeleteAsync(id);

            // Assert
            var allCabinetes = await Context.Cabinetes.Where(x => x.Id == id).ToListAsync();
            allCabinetes.Should().BeEmpty();
        }
    }
}