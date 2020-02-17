using ResturantAPI.Models.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResturantAPI.Models
{
    public class S_Articles : I_Articles<Articles>
    {
        readonly ResturantDbContext _resturantDb;
        public S_Articles(ResturantDbContext context)
        {
            _resturantDb = context;
        }

        public IEnumerable<Articles> GetAll()
        {
            return _resturantDb.Articles.ToList();
        }

        public Articles Get(Guid id)
        {
            return _resturantDb.Articles
                  .FirstOrDefault(e => e.Id == id);
        }

        public void Add(Articles articles)
        {
            _resturantDb.Articles.Add(articles);
            _resturantDb.SaveChanges();
        }

        public void Update(Articles articles, Articles entity)
        {

            articles.Name = entity.Name;

            _resturantDb.SaveChanges();
        }

        public void Delete(Articles articles)
        {
            _resturantDb.Articles.Remove(articles);
            _resturantDb.SaveChanges();
        }
    }
}
