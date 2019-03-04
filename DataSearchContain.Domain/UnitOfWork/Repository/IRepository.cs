using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataSearchContain.Domain.UnitOfWork.Repository
{
    public interface IRepository
    {
        /// <summary>
        /// Metod to check if a given word exist in the database
        /// </summary>
        /// <param name="word">What word we are looking for</param>
        /// <returns>An true/false if the word exist or not</returns>
        Task<bool> WordExist(string word);
    }
}
