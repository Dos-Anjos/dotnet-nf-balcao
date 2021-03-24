using System;
using nf_balcao.Data.Collections;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace nf_balcao.Data
{
    public class MongoDB
    {
        public IMongoDatabase DB { get; }

        public MongoDB(IConfiguration configuration)
        {
            try
            {
  //              var settings = MongoClientSettings.FromUrl(new MongoUrl(configuration["ConnectionString"]));
  //              var client = new MongoClient(settings);

                var connectionString = @"mongodb+srv://api:C6rKrnkakXNysurK@cluster0.zdjvp.mongodb.net/pedido?retryWrites=true&w=majority";
                var mongoUrl = new MongoUrl(connectionString);
  
                var client = new MongoClient(mongoUrl);
                DB = client.GetDatabase(configuration["NomeBanco"]);
                MapClasses();
            }
            catch (Exception ex)
            {
                throw new MongoException("It was not possible to connect to MongoDB", ex);
            }
        }

        private void MapClasses()
        {
            var conventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("camelCase", conventionPack, t => true);

            if (!BsonClassMap.IsClassMapRegistered(typeof(Pedido)))
            {
                BsonClassMap.RegisterClassMap<Pedido>(ped =>
                {
                    ped.AutoMap();
                    ped.SetIgnoreExtraElements(true);
                });
            }
        }
    }
}