using Business.Abstract;
using DAL.Abstract;
using Models.Documents;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CreditCardService : ICreditCardService
    {
        private readonly ICreditCardRepository _repository;

        public CreditCardService(ICreditCardRepository repository)
        {
            _repository = repository;
        }

        public void Add(CreditCard model)
        {
            _repository.Add(model);
        }

        public void Update(CreditCard model)
        {
            _repository.Update(model);
        }

        public void Delete(ObjectId id)
        {
            _repository.Delete(id);
        }

        public CreditCard Get(ObjectId id)
        {
            return _repository.Get(x => x.Id == id);
        }

        public IEnumerable<CreditCard> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
