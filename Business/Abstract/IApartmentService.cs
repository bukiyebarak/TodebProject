using Business.Configuration.Response;
using DTO.Apartment;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IApartmentService
    {
        public IEnumerable<Apartment> GetAll();
        public CommandResponse Insert(CreateApartmentRequest apartment);
        public CommandResponse Update(UpdateApartmentRequest apartment);
        public CommandResponse Delete(DeleteApartmentRequest apartment);
    }
}
