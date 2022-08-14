using DAL.MongoBase;
using Models.Documents;

namespace DAL.Abstract
{
    public interface ICreditCardRepository: IDocumentRepository<CreditCard>
    {
    }
}
