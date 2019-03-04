using DataSearchContain.Domain.UnitOfWork.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataSearchContain.Infrastructure.UnitOfWork.Reposetory
{
    public class Repository : IRepository
    {
        public async Task<bool> WordExist(string word)
        {
            return true;
        }
    }
}
