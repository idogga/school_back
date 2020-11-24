using System;
using System.Collections.Generic;
using System.Text;

namespace School.BL
{
    using System.Threading.Tasks;

    using School.AbstractService;

    public class CabinetService:CrudService<Cabinete>
    {
        public override Task<string> CreateAsync(Cabinete model)
        {
            throw new NotImplementedException();
        }

        public override Task<Cabinete> ReadAsync(string id)
        {
            throw new NotImplementedException();
        }

        public override Task<Cabinete> UpdateAsync(Cabinete model)
        {
            throw new NotImplementedException();
        }

        public override Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
