using DataSearchContain.Domain.UnitOfWork;
using DataSearchContain.Domain.UnitOfWork.Repository;
using DataSearchContain.Infrastructure.UnitOfWork.Reposetory;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataSearchContain.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {
            this.Repository = new Repository();
        }

        public IRepository Repository { get; }
    }
}
