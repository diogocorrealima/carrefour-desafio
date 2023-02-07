using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using SalesAPI.Domain.Core.Entities;
using SalesAPI.Domain.Entities;


namespace SalesAPI.Infra.Data
{
    public class SalesMapping
    {
        public static void DefineClassMap()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Sales)))
            {
                BsonClassMap.RegisterClassMap<Sales>(cm =>
                {
                    cm.AutoMap();


                    cm.MapMember(s => s.TotalValue).SetIsRequired(true);
                    cm.MapMember(s => s.Products).SetIsRequired(true);

                });
            }
        }
    }
}
