using ResturantAPI.Models.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResturantAPI.Models
{
    public interface I_Articles<TEntity>
    {
        IEnumerable<ArticlesDTO> GetAll();
        Articles Get(Guid id);
        ArticlesDTO GetDTO(Guid id);
        ArticlesDTO Add(ArticlesDTO entity);
        void Update(TEntity dbEntity, ArticlesDTO entity);
        void Delete(TEntity entity);
    }
}
