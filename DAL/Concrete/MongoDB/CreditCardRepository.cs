using DAL.Abstract;
using DAL.MongoBase;
using Microsoft.Extensions.Configuration;
using Models.Documents;
using MongoDB.Driver;

namespace DAL.Concrete.MongoDB
{
    public class CreditCardRepository : DocumentRepository<CreditCard>, ICreditCardRepository
    {
        private const string CollectionName = "CreditCard";

        public CreditCardRepository(MongoClient client, IConfiguration configuration) : base(client, configuration, CollectionName)
        {
        }
    }
}
