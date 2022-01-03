using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyJobSearches.Common.Test.Utilities
{
    public class CompanyTestUtility
    {
        public static Company GetOniryx()
        {
            return new Company(
                id: 1,
                name: "Oniryx");
        }
    }
}
