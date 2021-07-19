using MobileStoreMonthlyReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MobileStoreMonthlyReport.MobileSalesData
{
    public interface IGenericCRUD<TEntity>
    {
        List<TEntity> GetAll();

        TEntity GetById(dynamic id);

        TEntity Insert(TEntity entity);

        TEntity Update(TEntity entity);

        bool Delete(dynamic id);

        //Get query for entity
        //Parameters are filter, orderBy
        IQueryable<TEntity> Query(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

    }
}
