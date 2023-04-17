using dll.Models;
using dll.Models.CareerMap;
using Microsoft.Data.SqlClient;
using viewmodels;
using viewmodels.CareerMap;

namespace dll.DAL
{
    public class CompanyPositionsDAO
    {
        private readonly string _connectionString;
        public CompanyPositionsDAO(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
