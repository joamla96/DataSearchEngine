using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileManagementAPI {
	public class Config {
		public static string ConnWrite { get {
				return "Server=ssh.jalawebs.com,1433;Initial Catalog=DataSearchEngineMaster;Persist Security Info=False;User ID=sa;Password=Sj@0coL!5Cn5Ia6i;MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;"; // TODO Get from appsettings
			} }

		public static string ConnReadOnly { get {
				return ConnWrite; // TODO for future when we have multiple read databases
			} }
	}
}
