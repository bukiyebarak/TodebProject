using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Apartment
{
    public class UpdateApartmentRequest
    {
        public int Id { get; set; }
        public int No { get; set; }
        public char Block { get; set; }
        public string Type { get; set; }
        public string Floor { get; set; }
        public ApartmentStatus ApartmentStatus { get; set; }

    }
}
