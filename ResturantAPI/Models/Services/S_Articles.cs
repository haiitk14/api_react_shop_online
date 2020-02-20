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

        public IEnumerable<ArticlesDTO> GetAll()
        {
            var listCategorys = _resturantDb.Categorys.ToList();
            var listArticlesEditors = _resturantDb.Articles.Join(_resturantDb.Editors,
                art => art.Id,
                edit => edit.ArticlesId,
                (art, edit) => new { Articles = art, Editors = edit}).ToList();

            var listArticles = listArticlesEditors.Join(_resturantDb.Categorys,
                art => art.Articles.CategoryId,
                cate => cate.Id,
                (art, cate) => new ArticlesDTO() { Id = art.Articles.Id, CategoryId = art.Articles.CategoryId, Name = art.Articles.Name, Description = art.Articles.Description, Order = art.Articles.Order, IsPublic = art.Articles.IsPublic, Slug = art.Articles.Slug, TitleSeo = art.Articles.TitleSeo, KeywordsSeo = art.Articles.KeywordsSeo, DescriptionSeo = art.Articles.DescriptionSeo, CreatedDate = art.Articles.CreatedDate, UpdatedDate = art.Articles.UpdatedDate, Image = art.Articles.Image, CategoryName = cate.Name, Content = art.Editors.Content }).ToList();

            return listArticles;
        }

        public Articles Get(Guid id)
        {
            return _resturantDb.Articles
                  .FirstOrDefault(e => e.Id == id);
        }

        public void Add(ArticlesDTO articlesDTO)
        {
            var articles = new Articles()
            {
                Id = articlesDTO.Id,
                Name = articlesDTO.Name,
                Description = articlesDTO.Description,
                Order = articlesDTO.Order,
                CategoryId = articlesDTO.CategoryId,
                Slug = articlesDTO.Slug,
                IsPublic = articlesDTO.IsPublic,
                TitleSeo = articlesDTO.TitleSeo,
                DescriptionSeo = articlesDTO.DescriptionSeo,
                KeywordsSeo = articlesDTO.KeywordsSeo,
                Image = articlesDTO.Image,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };
            var editors = new Editors()
            {
                Id = Guid.NewGuid(),
                ArticlesId = articlesDTO.Id,
                Content = articlesDTO.Content,
                CreatedDate = articlesDTO.CreatedDate,
                UpdatedDate = articlesDTO.UpdatedDate
            };
            _resturantDb.Articles.Add(articles);
            _resturantDb.Editors.Add(editors);
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
