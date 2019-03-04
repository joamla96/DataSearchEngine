using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataSearchContain.UnitTest.DataGenrators.SearchContainDataGenerator
{

    public class TestSearchContainDataGeneratorInvalidValues
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
