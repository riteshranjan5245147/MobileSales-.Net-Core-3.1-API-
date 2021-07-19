using Microsoft.EntityFrameworkCore;
using MobileStoreMonthlyReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStoreMonthlyReport.MobileSalesData
{
    public class GenericCRUD<TEntity> : IGenericCRUD<TEntity> where TEntity : class
    {
        private DataContext _context;
        private DbSet<TEntity> _dbSet;
        public GenericCRUD(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public bool Delete(dynamic id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            _context.Entry(entityToDelete).State = EntityState.Deleted;
            return true;
        }

        public List<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity GetById(dynamic id)
        {
            return _dbSet.Find(id);
        }

        public TEntity Insert(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }

        //public TEntity GetTable(TEntity entity)
        //{
        //    entity = _context.Set(entity.GetType());
        //    return entity;
        //}

        //public List<TEntity> GetMonthlyBrandWiseSales(DateTime fromDate, DateTime toDate, string brand)
        //{
        //    var table = _context.Set<Sales>();
        //    return table.Where(x => x.ProductModel == brand && x.DateOfSelling >= fromDate && x.DateOfSelling <= toDate).ToList();
            
        //}
    }
}
