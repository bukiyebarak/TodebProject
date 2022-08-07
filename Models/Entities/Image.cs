using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public int ApartmentId { get; set; }
        public string Title { get; set; }
        public string Picture { get; set; }

        [ForeignKey("ApartmentId")]
        public Apartment Apartment { get; set; }
    }
}
