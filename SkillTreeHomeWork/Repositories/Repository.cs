using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.ComponentModel;
using System.Data.Entity;

namespace SkillTreeHomeWork.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public IUnitOfWork UnitOfWork { get; set; }

        private DbSet<T> _Objectset;
        private DbSet<T> ObjectSet
        {
            get
            {
                if (_Objectset == null)
                {
                    _Objectset = UnitOfWork.Context.Set<T>();
                }
                return _Objectset;
            }
        }
        public Repository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public IQueryable<T> LookupAll()
        {
            return ObjectSet;
        }

        public T LookupByGuid(Guid? guid)
        {
            return ObjectSet.Find(guid);
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> filter)
        {
            return ObjectSet.Where(filter);
        }

        public T GetSingle(Expression<Func<T, bool>> filter)
        {
            return ObjectSet.SingleOrDefault(filter);
        }

        public void Create(T entity)
        {
            ObjectSet.Add(entity);
        }

        public void Update(T entity)
        {
            UnitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(T entity)
        {
            //在DeleteConfirmed我有先做過一次LookupByGuid查詢資料，因此在ObjectSet時只剩一筆資料。
            //刪除時會在發生(無法刪除此物件，因為在 ObjectStateManager 中找不到)。

            if (UnitOfWork.Context.Entry(entity).State == EntityState.Detached)
            {
                //看線上資訊有人寫到可以在Detached狀態下執行ObjectSet Attach，但會發生(因為另一個相同類型的實體已經有相同的主索引鍵值)
                //ObjectSet.Attach(entity);

                //查看VS錯誤訊息有寫到可以將狀態改為Modified，但試著將UnitOfWork的Context改為EntityState.Modified一樣會發生
                //(因為另一個相同類型的實體已經有相同的主索引鍵值)
                //UnitOfWork.Context.Entry(entity).State = EntityState.Modified;
            }

            //請問老師這部份的觀念部份，我那裡錯誤了，請問我該怎麼處理這個問題，謝謝?
            ObjectSet.Remove(entity);
        }

        public void Commit()
        {
            UnitOfWork.Save();
        }
    }
}