using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Bill
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public float Electricity { get; set; }
        public float Water { get; set; }
        public float NaturalGas { get; set; }
        public float Dues { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}