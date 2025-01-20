using Lessons.Lesson_24_Module601.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Lesson_24_Module601.Services
{
    public class CustomerOperations
    {
        public void Add(Customer customer)
        {
            MongoDbConnection connection = new MongoDbConnection();
            IMongoCollection<BsonDocument> collection = connection.GetCollection("Customers");

            BsonDocument document = new BsonDocument
            {
                {"Name",customer.Name },
                {"Surname",customer.Surname },
                {"City",customer.City },
                {"Balance",customer.Balance },
                {"ShoppingCount",customer.ShoppingCount },
            };

            collection.InsertOne(document);
        }

        public List<Customer> GetAll()
        {
            MongoDbConnection connection = new MongoDbConnection();
            IMongoCollection<BsonDocument> collection = connection.GetCollection("Customers");

            List<BsonDocument> bsonList = collection.Find(new BsonDocument()).ToList();
            List<Customer> customers = new List<Customer>();
            foreach (BsonDocument bson in bsonList)
            {
                customers.Add(new Customer
                {
                    Id = bson["_id"].ToString(),
                    Balance = decimal.Parse(bson["Balance"].ToString()),
                    City = bson["City"].ToString(),
                    Name = bson["Name"].ToString(),
                    ShoppingCount = int.Parse(bson["ShoppingCount"].ToString()),
                    Surname = bson["Surname"].ToString()
                });
            }
            return customers;
        }

        public void Delete(string id)
        {
            MongoDbConnection connection = new MongoDbConnection();
            IMongoCollection<BsonDocument> collection = connection.GetCollection("Customers");

            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            collection.DeleteOne(filter);
        }

        public void Update(Customer customer)
        {
            MongoDbConnection connection = new MongoDbConnection();
            IMongoCollection<BsonDocument> collection = connection.GetCollection("Customers");

            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(customer.Id));
            UpdateDefinition<BsonDocument> updatedValues = Builders<BsonDocument>.Update
                .Set("Name", customer.Name)
                .Set("Surname", customer.Surname)
                .Set("City", customer.City)
                .Set("Balance", customer.Balance)
                .Set("ShoppingCount", customer.ShoppingCount);
            collection.UpdateOne(filter, updatedValues);
        }

        public Customer GetById(string id)
        {
            MongoDbConnection connection = new MongoDbConnection();
            IMongoCollection<BsonDocument> collection = connection.GetCollection("Customers");

            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            BsonDocument result = collection.Find(filter).FirstOrDefault();
            return new Customer
            {
                Id = result["_id"].ToString(),
                Name = result["Name"].ToString(),
                Surname = result["Surname"].ToString(),
                City = result["City"].ToString(),
                Balance = decimal.Parse(result["Balance"].ToString()),
                ShoppingCount = int.Parse(result["ShoppingCount"].ToString()),
            };
        }
    }
}
