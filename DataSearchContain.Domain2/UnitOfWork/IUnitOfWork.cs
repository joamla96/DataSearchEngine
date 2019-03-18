using DataSearchContain.Domain.UnitOfWork.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataSearchContain.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Instance of the Repository
        /// </summary>
        IRepository Repository { get; }
    }
}
