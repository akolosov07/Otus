using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgresTest.BLL.Dtos
{
    public class CreateCustomerDto
    {
        public string Name { get; set; }
    }
    public class CustomerDto : CreateCustomerDto
    {
        public int CustomerID { get; set; }
    }
}
