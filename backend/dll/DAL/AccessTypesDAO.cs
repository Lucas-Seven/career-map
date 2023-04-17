using dll.Models.User;
using Microsoft.Data.SqlClient;

namespace dll.DAL
{
    public class AccessTypesDAO
    {
        private readonly string _connectionString;
        public AccessTypesDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MAccessType InsertAccessType(MAccessType accessType)
        {
            try
            {
                string sql = @"-- Insert access type in accessTypes_tb table
                                INSERT INTO accessTypes_tb (
                                  access_type_id, access_type_name
                                ) 
                                VALUES (
                                  @AccessTypeId, @AccessTypeName
                                );";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        // Add access type
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Transaction = transaction;
                            command.Parameters.AddWithValue("@AccessTypeId", accessType.AccessTypeId);
                            command.Parameters.AddWithValue("@AccessTypeName", accessType.AccessTypeName);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        Console.WriteLine($"The access type with Id {accessType.AccessTypeId} was successfully registered.");
                        return accessType;
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        if (ex.Number == 2601 || ex.Number == 2627) // Unique constraint violation
                        {
                            throw new Exception($"An error occurred while registering the access type in the database. \n\nSqlException: The access type '{accessType.AccessTypeName}' is already registered in the system.");
                        }
                        else
                        {
                            throw new Exception($"An error occurred while registering the access type in the database. \n\nSqlException: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred. \n\nException: {ex.Message}");
            }
        }
    }
}
