using ResturantAPI.Models.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResturantAPI.Models
{
    public class S_Editors : I_Editors<Editors>
    {
        readonly ResturantDbContext _resturantDb;
        public S_Editors(ResturantDbContext context)
        {
            _resturantDb = context;
        }

        public IEnumerable<Editors> GetAll()
        {
            return _resturantDb.Editors.ToList();
        }

        public Editors Get(Guid id)
        {
            return _resturantDb.Editors
                  .FirstOrDefault(e => e.Id == id);
        }

        public void Add(Editors Editors)
        {
            _resturantDb.Editors.Add(Editors);
            _resturantDb.SaveChanges();
        }

        public void Update(Editors Editors, Editors entity)
        {
            _resturantDb.SaveChanges();
        }

        public void Delete(Editors Editors)
        {
            _resturantDb.Editors.Remove(Editors);
            _resturantDb.SaveChanges();
        }
    }
}
