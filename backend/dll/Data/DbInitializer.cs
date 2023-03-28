using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.Data
{
    internal class DbInitializer
    {
        public static void Initialize(CareerMapContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
