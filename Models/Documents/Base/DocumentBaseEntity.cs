using MongoDB.Bson;

namespace Models.Documents.Base
{
    public abstract class DocumentBaseEntity
    {
        public ObjectId Id { get; set; }
        public string ObjectId => Id.ToString();
    }
}
