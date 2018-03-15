using Logger.Entities;
using MongoDB.Driver;
using Nancy;
using Nancy.Conventions;
using Nancy.TinyIoc;

namespace Logger.Helper
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(NancyConventions nancyConventions) => nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("Scripts"));

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            var connString = "mongodb://localhost:27017";
            var databaseName = "DGN";

            var client = new MongoClient(connString);
            var database = client.GetDatabase(databaseName);

            var collection = database.GetCollection<ErrorLog>("ErrorLogs");

            container.Register<IMongoClient>(client);
            container.Register(database);
            container.Register(collection);

        }
    }
}