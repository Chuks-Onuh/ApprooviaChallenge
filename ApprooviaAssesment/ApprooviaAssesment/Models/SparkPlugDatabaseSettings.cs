using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApprooviaAssesment.Models
{
    public class SparkPlugDatabaseSettings : ISparkPlugDatabaseSettings
    {
        public string SparkPlugCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
