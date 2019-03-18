using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataSearchContain.Domain.UnitOfWork.Repository
{
    public interface IRepository
    {
        /// <summary>
        /// Method to check if a given word exist in the database
        /// </summary>
        /// <param name="word">What word we are looking for</param>
        /// <returns>An true/false if the word exist or not</returns>
        Task<bool> WordExist(string word);

		/// <summary>
		/// Method that returns the amount of MatchingItems
		/// </summary>
		/// <param name="word">how many of the items matches the String word </param>
		/// <returns>The amount of matching items</returns>
		Task<int> MatchingItems(string word);
    }
}
