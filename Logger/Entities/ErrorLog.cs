using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Logger.Entities
{
    public class ErrorLog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ErrorText { get; set; }
        public int UserID { get; set; }
        public string Platform { get; set; }
        public int ErrorCode { get; set; }
    }
}