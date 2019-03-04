using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WebClient.UnitTest.DataGenrators.SearchContainDataGenerator
{
    public class TestSearchContainDataGeneratorValidSearch
        : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { "cake" },
            new object[] { "coo	kie" },
            new object[] { "chocolate" },
            new object[] { "coffee" },
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
