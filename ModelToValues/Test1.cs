using System;
using System.Collections.Generic;
using System.Text;

namespace ModelToValues
{
    public class Test1
    {
        public string First1 { get; set; }
        public string First2 { get; set; }
        public bool First3 { get; set; }

        public Test2 FirstSecond;
        public Test2 AnotherSecond;
    }

    public class Test2
    {
        public string Second1 { get; set; }
        public string Second2 { get; set; }
        public bool Second3 { get; set; }
    }
}
