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

        public MCompanyPosition InsertCompanyPosition(MCompanyPosition companyPosition)
        {
            try
            {
                string sql = @"-- Insert company position in companyPositions_tb table
                                INSERT INTO companyPositions_tb (
                                  company_position_name
                                ) 
                                VALUES (
                                  @CompanyPositionName
                                );";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        // Add company position
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Transaction = transaction;
                            command.Parameters.AddWithValue("@CompanyPositionName", companyPosition.CompanyPositionName);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        Console.WriteLine($"The company position with Id {companyPosition.CompanyPositionId} was successfully registered.");
                        return companyPosition;
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        if (ex.Number == 2601 || ex.Number == 2627) // Unique constraint violation
                        {
                            throw new Exception($"An error occurred while registering the company position in the database. \n\nSqlException: The company position '{companyPosition.CompanyPositionName}' is already registered in the system.");
                        }
                        else
                        {
                            throw new Exception($"An error occurred while registering the company position in the database. \n\nSqlException: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred. \n\nException: {ex.Message}");
            }
        }

        public MCompanyPositionRequirement InsertRequirementInCompanyPosition(MCompanyPositionRequirement companyPositionRequirement)
        {
            try
            {
                string sql = @"-- Insert requirement in company position
                                INSERT INTO companyPositions_positionRequirements_tb (
                                  company_position_id, 
                                  requirement_id, 
                                  group_name
                                ) 
                                VALUES (
                                  @CompanyPositionId, 
                                  @RequirementId, 
                                  @GroupName
                                );";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        // Add career map
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Transaction = transaction;
                            command.Parameters.AddWithValue("@CompanyPositionId", companyPositionRequirement.CompanyPositionId);
                            command.Parameters.AddWithValue("@RequirementId", companyPositionRequirement.RequirementId);
                            command.Parameters.AddWithValue("@GroupName", companyPositionRequirement.GroupName != null ? companyPositionRequirement.GroupName : DBNull.Value);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        Console.WriteLine($"The requirement with Id {companyPositionRequirement.RequirementId} was successfully registered.");
                        return companyPositionRequirement;
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"An error occurred while registering the requirement in the company position. \n\nSqlException: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred. \n\nException: {ex.Message}");
            }
        }

        public List<VMCompanyPosition> SelectAllCompanyPositions()
        {
            try
            {
                List<VMCompanyPosition> companyPositions = new List<VMCompanyPosition>();

                string sql = @"SELECT 
                                    company_position_id, 
                                    company_position_name 
                                FROM 
                                    companyPositions_tb;";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    try
                    {
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            using (SqlDataReader dataReader = command.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    int companyPositionId = Convert.ToInt32(dataReader["company_position_id"]);
                                    VMCompanyPosition companyPosition = companyPositions.FirstOrDefault(c => c.CompanyPositionId == companyPositionId);

                                    if (companyPosition == null)
                                    {
                                        companyPosition = new VMCompanyPosition()
                                        {
                                            CompanyPositionId = companyPositionId,
                                            CompanyPositionName = dataReader["company_position_name"].ToString()
                                        };
                                        companyPositions.Add(companyPosition);
                                    }
                                }
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception($"An error occurred when fetching \"company positions\" from the database. \n\nSqlException: {ex.Message}");
                    }
                }

                if (companyPositions == null || companyPositions.Count == 0)
                {
                    throw new Exception("The \"company positions\" not found.");
                }

                Console.WriteLine("The \"SelectAllCompanyPositions\" query was successful.");
                return companyPositions;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred. \n\nException: {ex.Message}");
            }
        }
    }
}
