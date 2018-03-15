using Logger.Entities;
using MongoDB.Driver;
using Nancy;
using Nancy.ModelBinding;

namespace Logger.Modules
{
    public class LogModule : NancyModule
    {
        private readonly IMongoCollection<ErrorLog> _errorLog;

        public LogModule(IMongoCollection<ErrorLog> errorLog)
            :base("/api")
        {
            _errorLog = errorLog;
            Post["/Log"] = AddLog;
        }

        private Response AddLog(dynamic parameters)
        {
            var model = this.Bind<ErrorLog>();
            if (model.ErrorText == string.Empty)
            {
                return HttpStatusCode.BadRequest;
            }
            _errorLog.InsertOneAsync(model);
            return "Başarılı";
        }
    }
}