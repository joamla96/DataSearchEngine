using System;
using System.Collections.Generic;
using System.Text;
using WebClient.Domain.UnitOfWork.Repository;

namespace WebClient.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Instance of the Repository
        /// </summary>
        IRepository Repository { get; }
    }
}
