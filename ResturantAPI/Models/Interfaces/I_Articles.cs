﻿using ResturantAPI.Models.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResturantAPI.Models
{
    public interface I_Articles<TEntity>
    {
        IEnumerable<ArticlesDTO> GetAll();
        TEntity Get(Guid id);
        void Add(ArticlesDTO entity);
        void Update(TEntity dbEntity, TEntity entity);
        void Delete(TEntity entity);
    }
}
