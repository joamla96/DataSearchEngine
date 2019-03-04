using System;
using System.Collections.Generic;
using System.Text;
using WebClient.Domain.UnitOfWork;
using WebClient.Domain.UnitOfWork.Repository;

namespace WebClient.Infrastructure.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {
            Repository = new Repository.Repository();
        }

        public IRepository Repository { get; }
        
    }
}
