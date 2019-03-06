using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WebClient.UnitTest.DataGenrators.AmountContainerDataGenerator
{
	class TestSearchAmountDataGeneratorInvalidValues
   : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { "" },
            new object[] { null },
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
