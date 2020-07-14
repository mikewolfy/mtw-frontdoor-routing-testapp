using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mtw.routing.test.app
{
    public class Counter
    {
        private int count = 0;

        public int GetCount()
        {
            return ++count;
        }

        public void Reset()
        {
            count = 0;
        }
    }
}
