using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace WebClient.UnitTest.DataGenrators.AmountContainerDataGenerator
{
	class TestSearchAmountDataGeneratorValidAmounts : IEnumerable<object[]>
	{
		

		private readonly List<object[]> _mockList = new List<object[]>
		{
			new object[] { "hammer" },
			new object[] { "chair" },
			new object[] { "chair" },
			new object[] { "Hat" },
			new object[] { "hammer" },
			new object[] { "chair" },
			new object[] { "Cake" },
			new object[] { "Car" },

		};

		public IEnumerator<object[]> GetEnumerator()
		{
			return _mockList.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
	
	
}
