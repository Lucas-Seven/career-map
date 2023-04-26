using dll.Models;
using viewmodels;
using Microsoft.Data.SqlClient;
using dll.Models.CareerMap;
using viewmodels.CareerMap;
using dll.Models.Form;

namespace dll.DAL
{
    public class AlternativesDAO
    {
        private readonly string _connectionString;
        public AlternativesDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MAlternative Insert(MAlternative alternative)
        {
            try
            {
                int alternativeId = 0;

                string sql = @"--X
    INSERT INTO questionAlternatives_tb (
              question_id
            , alternative
            , is_right
    )
    OUTPUT INSERTED.ID
    VALUES
           (@question_id,
           ,@alternative>
           ,@is_right);
";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        // Add requirement
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Transaction = transaction;
                            command.Parameters.AddWithValue("@question_id", alternative.QuestionId);
                            command.Parameters.AddWithValue("@alternative", alternative.Alternative);
                            command.Parameters.AddWithValue("@is_right", alternative.IsRight);
                            //alternativeId = command.ExecuteNonQuery();
                            alternativeId = (Int32) command.ExecuteScalar();
                        }

                        transaction.Commit();
                        Console.WriteLine($"The requirement with Id {alternativeId} was successfully registered.");

                        alternative.AlternativeId = alternativeId;

                        return alternative;
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        if (ex.Number == 2601 || ex.Number == 2627) // Unique constraint violation
                        {
                            throw new Exception($"An error occurred while registering the questionAlternative in the database. \n\nSqlException: The question Alternative '{alternative.Alternative}' is already registered in the system.");
                        }
                        else
                        {
                            throw new Exception($"An error occurred while registering the questionAlternative in the database. \n\nSqlException: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred. \n\nException: {ex.Message}");
            }
        }

        //public List<VMRequirement> SelectAllRequirements()
        //{
        //    try
        //    {
        //        List<VMRequirement> requirements = new List<VMRequirement>();

        //        string sql = @"SELECT 
        //                            requirement_id, 
        //                            requirement_name 
        //                        FROM 
        //                            positionRequirements_tb;";

        //        using (SqlConnection connection = new SqlConnection(_connectionString))
        //        {
        //            connection.Open();

        //            try
        //            {
        //                using (SqlCommand command = new SqlCommand(sql, connection))
        //                {
        //                    using (SqlDataReader dataReader = command.ExecuteReader())
        //                    {
        //                        while (dataReader.Read())
        //                        {
        //                            int requirementId = Convert.ToInt32(dataReader["requirement_id"]);
        //                            VMRequirement requirement = requirements.FirstOrDefault(c => c.RequirementId == requirementId);

        //                            if (requirement == null)
        //                            {
        //                                requirement = new VMRequirement()
        //                                {
        //                                    RequirementId = requirementId,
        //                                    RequirementName = dataReader["requirement_name"].ToString()
        //                                };
        //                                requirements.Add(requirement);
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            catch (SqlException ex)
        //            {
        //                throw new Exception($"An error occurred when fetching \"requirements\" from the database. \n\nSqlException: {ex.Message}");
        //            }
        //        }

        //        if (requirements == null || requirements.Count == 0)
        //        {
        //            throw new Exception("The \"requirement\" not found.");
        //        }

        //        Console.WriteLine("The \"SelectAllRequirements\" query was successful.");
        //        return requirements;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"An error occurred. \n\nException: {ex.Message}");
        //    }
        //}
    }
}
