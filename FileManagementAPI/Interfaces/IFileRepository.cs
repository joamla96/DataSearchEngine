using FileManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileManagementAPI.Interfaces {
	public interface IFileRepository {
		Task<bool> Insert(FileDTO input);
	}
}
