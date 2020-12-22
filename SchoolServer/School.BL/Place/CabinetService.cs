namespace School.BL.Place
{
    using System;
    using System.Threading.Tasks;

    using School.Abstract;
    using School.Database;

    public class CabinetService : CrudService<Cabinete>
    {
        public override Task<string> CreateAsync(Cabinete model)
        {
            throw new NotImplementedException();
        }

        public override Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public override Task<Cabinete> ReadAsync(string id)
        {
            throw new NotImplementedException();
        }

        public override Task UpdateAsync(Cabinete model)
        {
            throw new NotImplementedException();
        }
    }
}