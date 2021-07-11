using MobileStoreMonthlyReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}
