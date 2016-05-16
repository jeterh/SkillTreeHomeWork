using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SkillTreeHomeWork.Models;
using SkillTreeHomeWork.Repositories;
using SkillTreeHomeWork.Models.ViewModels;

namespace SkillTreeHomeWork.Service
{
    public class AccountBookService : Repository<AccountBookModels>
    {
        private readonly IRepository<AccountBookModels> _accountBookRep;

        public AccountBookService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _accountBookRep = new Repository<AccountBookModels>(unitOfWork);
        }

        public IEnumerable<AccountBookViewModels> Lookup()
        {
            var source = _accountBookRep.LookupAll();
            var result = source.Select(accountBook => new AccountBookViewModels()
            {
                Id = accountBook.Id,
                Amount = accountBook.Amount,
                Date = accountBook.Date,
                Category= accountBook.Category,
                Remark = accountBook.Remark
            }).ToList();
            return result;
        }

        public new AccountBookViewModels LookupByGuid(Guid? id)
        {           
            var source = _accountBookRep.LookupByGuid(id);

            if (source == null)
            {
                return null;
            }

            var result = new AccountBookViewModels()
            {
                Id = source.Id,
                Amount = source.Amount,
                Date = source.Date,
                Category = source.Category,
                Remark = source.Remark
            };

            return result;
        }

        public void Add(AccountBookViewModels accountBook)
        {
            var result = new AccountBookModels()
            {
                Id = accountBook.Id,
                Amount = accountBook.Amount,
                Date = accountBook.Date,
                Category = accountBook.Category,
                Remark = accountBook.Remark
            };

            _accountBookRep.Create(result);
        }

        public void Edit(AccountBookViewModels accountBook)
        {
            var result = new AccountBookModels()
            {
                Id = accountBook.Id,
                Amount = accountBook.Amount,
                Date = accountBook.Date,
                Category = accountBook.Category,
                Remark = accountBook.Remark
            };

            _accountBookRep.Update(result);
        }

        public void Remove(AccountBookViewModels accountBook)
        {
            var result = new AccountBookModels()
            {
                Id = accountBook.Id,
                Amount = accountBook.Amount,
                Date = accountBook.Date,
                Category = accountBook.Category,
                Remark = accountBook.Remark
            };

            _accountBookRep.Remove(result);
        }

        public void Save()
        {
            _accountBookRep.Commit();
        }
    }
}