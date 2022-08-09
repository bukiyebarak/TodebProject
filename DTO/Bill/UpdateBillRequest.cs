using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Bill
{
    public class UpdateBillRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public float Electricity { get; set; }
        public float Water { get; set; }
        public float NaturalGas { get; set; }
        public float Dues { get; set; }
    }
}
