using System.Data.Entity.Design.PluralizationServices;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace UniversityTeachersMongo.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(string mongoUrl)
        {
            InitDbSettings();
            _database = InitDbInstance(mongoUrl);
        }

        private static IMongoDatabase InitDbInstance(string mongoUrl)
        {
            var url = new MongoUrl(mongoUrl);
            var client = new MongoClient(mongoUrl);
            return client.GetDatabase(url.DatabaseName);
        }
        
        private static void InitDbSettings()
        {
            var pack = new ConventionPack { new CamelCaseElementNameConvention() };
             ConventionRegistry.Register("camel case", pack, _ => true);
        }

        public IMongoCollection<TEntity> Collection<TEntity>() where TEntity : class
        {
            var serv = PluralizationService.CreateService(new System.Globalization.CultureInfo("en-us"));
            var collectionName = serv.Pluralize(typeof(TEntity).Name);
            return _database.GetCollection<TEntity>(collectionName);
        }
    }
}