using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgresTest.DAL.Entities
{
    /// <summary>
    /// Клиент
    /// </summary>
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public ICollection<Purchase>? Purchases { get; set; }
    }
}
