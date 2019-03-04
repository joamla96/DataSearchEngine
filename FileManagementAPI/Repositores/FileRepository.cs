using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using FileManagementAPI.Interfaces;
using FileManagementAPI.Models;
using Microsoft.IdentityModel.Protocols;

namespace FileManagementAPI.Repositores {
	public class FileRepository : IFileRepository {
		public async Task<bool> Insert(FileDTO input) {
			using (IDbConnection db = new SqlConnection(Config.ConnWrite)) {
				var query = "INSERT INTO File (Id, Content, Name) VALUE(@Id, @Content, @Name)";

				await db.ExecuteAsync(query, input);
			}

			return true; // Assuming no exceptions where thrown
		}
	}
}
