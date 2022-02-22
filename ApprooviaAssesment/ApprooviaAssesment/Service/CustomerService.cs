using ApprooviaAssesment.Model;
using ApprooviaAssesment.Models;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace ApprooviaAssesment.Services
{
    public class CustomerService
    {
        private readonly IMongoCollection<Customer> _customers;
        public CustomerService(ISparkPlugDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _customers = database.GetCollection<Customer>(settings.SparkPlugCollectionName); 
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            await _customers.InsertOneAsync(customer);

            return customer;
        }
    }
}
