using Models.Documents;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        void Add(CreditCard model);
        void Update(CreditCard model);
        void Delete(ObjectId id);
        CreditCard Get(ObjectId id);
        IEnumerable<CreditCard> GetAll();
    }
}
