using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataSearchContain.UnitTest.DataGenrators.SearchAmountDataGenerator
{
	public class TestSearchAmountDataGeneratorValidAmount 
		: IEnumerable<object[]>
	{
		private readonly List<object[]> _data = new List<object[]>
		{
			new object[] { "hammer" },
			new object[] { "chair" },
			new object[] { "chair" },
			new object[] { "Hat" },
			new object[] { "hammer" },
			new object[] { "chair" },
			new object[] { "Cake" },
			new object[] { "Car" },
			new object[] { "hammer" },
			new object[] { "Hat" },
			new object[] { "chair" },
			new object[] { "Hat" },
			new object[] { "hammer" },
			new object[] { "chair" },
			new object[] { "Cake" },
			new object[] { "Car" },
};

		public IEnumerator<object[]> GetEnumerator()
		{
			return _data.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
