using AutoMapper;
using BackgroundJobs.Abstract;
using Business.Abstract;
using Business.Configuration.Extensions;
using Business.Configuration.Response;
using Business.Configuration.Validator.FluentValidation.Bill;
using DAL.Abstract;
using DTO.Bill;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BillService : IBillService
    {
        private readonly IBillRepository _billRepository;
        private IMapper _mapper;
        private IJobs _jobs;

        public BillService(IBillRepository billRepository, IMapper mapper, IJobs jobs)
        {
            _billRepository = billRepository;
            _mapper = mapper;
            _jobs = jobs;

        }

        public CommandResponse Delete(DeleteBillRequest bill)
        {
            var validator = new DeleteBillRequestValidator();
            validator.Validate(bill).ThrowIfException();
            var entity = _mapper.Map<Bill>(bill);

            _billRepository.Delete(entity);
            _billRepository.SaveChanges();
            return new CommandResponse
            {
                Status = true,
                Messsage = "Fatura Bilgileri Silindi",

            };
        }

        public IEnumerable<Bill> GetAll()
        {
            return _billRepository.GetAll();
        }

        public CommandResponse Insert(CreateBillRequest bill)
        {

            var validator = new CreateBillRequestValidator();
            validator.Validate(bill).ThrowIfException();
            var entity = _mapper.Map<Bill>(bill);

            _billRepository.Add(entity);
            _billRepository.SaveChanges();

            return new CommandResponse
            {
                Status = true,
                Messsage = $"Faturanız eklendi",
            };
        }

        public CommandResponse Update(UpdateBillRequest bill)
        {
            var validator = new UpdateBillRequestValidator();
            validator.Validate(bill).ThrowIfException();

            var entity = _billRepository.Get(x => x.Id == bill.Id);
            if (entity == null)
            {
                return new CommandResponse()
                {
                    Status = false,
                    Messsage = "Veri tabanında bu Id de kayıt bulunmamaktadır"
                };
            }

            var mappedEntity = _mapper.Map(bill, entity);

            _billRepository.Update(mappedEntity);
            _billRepository.SaveChanges();
            return new CommandResponse
            {
                Status = true,
                Messsage = $"Fatura bilgileriniz güncellendi. User Name={bill.UserId} Id={bill.Id}",
            };
        }
    }
}
