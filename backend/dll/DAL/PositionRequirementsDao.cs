using dll.Models;
using dll.ViewModels;
using Microsoft.Data.SqlClient;

namespace dll.DAL
{
    public class PositionRequirementsDAO
    {
        private readonly string _connectionString;
        public PositionRequirementsDAO(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
