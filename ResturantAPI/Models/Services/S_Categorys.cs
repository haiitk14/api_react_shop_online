using ResturantAPI.Models.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResturantAPI.Models
{
    public class S_Categorys : I_Categorys<Categorys>
    {
        readonly ResturantDbContext _resturantDb;
        public S_Categorys(ResturantDbContext context)
        {
            _resturantDb = context;
        }

        public IEnumerable<Categorys> GetAll()
        {
            return _resturantDb.Categorys.ToList();
        }

        public Categorys Get(Guid id)
        {
            return _resturantDb.Categorys
                  .FirstOrDefault(e => e.Id == id);
        }

        public void Add(Categorys categorys)
        {
            _resturantDb.Categorys.Add(categorys);
            _resturantDb.SaveChanges();
        }

        public void Update(Categorys categorys, Categorys entity)
        {
            categorys.Name = entity.Name;
            categorys.Code = entity.Code;
            categorys.Description = entity.Description;
            categorys.IsMenu = entity.IsMenu;
            categorys.IsPublic = entity.IsPublic;
            categorys.Order = entity.Order;
            categorys.TitleSeo = entity.TitleSeo;
            categorys.KeywordsSeo = entity.KeywordsSeo;
            categorys.DescriptionSeo = entity.DescriptionSeo;
            categorys.UpdatedDate = entity.UpdatedDate;
            _resturantDb.SaveChanges();
        }

        public void Delete(Categorys categorys)
        {
            var articles = _resturantDb.Articles.Where(w => w.CategoryId == categorys.Id ).ToList();
            _resturantDb.Articles.RemoveRange(articles);
            _resturantDb.Categorys.Remove(categorys);
            _resturantDb.SaveChanges();
        }

        public IEnumerable<Categorys> GetByIsPublic(bool isPublic)
        {
            return _resturantDb.Categorys
                  .Where(w => w.IsPublic == isPublic).ToList();
        }
    }
}
