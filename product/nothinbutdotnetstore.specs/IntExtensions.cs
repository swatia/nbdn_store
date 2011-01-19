using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Contracts;

namespace nothinbutdotnetstore.specs
{
    public static class IntExtensions
    {
        public static void ShouldEqual(this int valueToTest, int testValue)
        {
            if (valueToTest != testValue)
            {
                throw new Exception("Integer does not euqal " + testValue + ".");
            }
        }
    }
}
