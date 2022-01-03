using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application._Abstracts
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// add one record
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// delete one record
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// update one record
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// get all records. Not paging for each query < 100 records
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IQueryable<T> List(Expression<Func<T, bool>> expression);

        /// <summary>
        /// add multi records
        /// </summary>
        /// <param name="entity"></param>
        void AddMulti(List<T> entity);

        /// <summary>
        /// update multi records from id's list
        /// </summary>
        /// <param name="listT"></param>
        void UpdateMultiByIds(IEnumerable<T> listT);

        /// <summary>
        /// delete multi records
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="listT"></param>
        void DeleteMulti(Expression<Func<T, bool>> expression, IEnumerable<T> listT);

        T GetSingleById(int id);
        /// <summary>
        /// get one record by expression
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        Task<T> GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null);

        /// <summary>
        /// filtering 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="total"></param>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        IQueryable<T> GetMultiPaging(Expression<Func<T, bool>> expression, out int total, int index = 0, int size = 50, string[] includes = null);

        /// <summary>
        /// connt with expression
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        int Count(Expression<Func<T, bool>> where);

        /// <summary>
        /// check contain with expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        bool CheckContains(Expression<Func<T, bool>> expression);
    }
}