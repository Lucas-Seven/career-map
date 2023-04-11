using dll.Models;
using dll.ViewModels;
using Microsoft.Data.SqlClient;

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
