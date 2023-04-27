using dll.Models.CareerMap;
using dll.Models.Form;
using Microsoft.Data.SqlClient;
using viewmodels.Form;

namespace dll.DAL
{
    public class TestQuestionsDAO
    {
        private readonly string _connectionString;
        private readonly AlternativesDAO alternativesDAO;
        public TestQuestionsDAO(string connectionString)
        {
            _connectionString = connectionString;
            alternativesDAO = new AlternativesDAO(connectionString);
        }

        public MQuestion Insert(MQuestion question)
        {
            try
            {
                string sql = @"--X
INSERT INTO testQuestions_tb
           (question_type_id
           ,question
           ,is_required
           ,description)
    OUTPUT INSERTED.question_id 
    VALUES
           (@question_type_id
           ,@question
           ,@is_required
           ,@description);";

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
                            command.Parameters.AddWithValue("@question_type_id", question.QuestionTypeId);
                            command.Parameters.AddWithValue("@question", question.Question);
                            command.Parameters.AddWithValue("@is_required", question.IsRequired);
                            command.Parameters.AddWithValue("@description", question.Description);

                            question.QuestionId = (Int32)command.ExecuteScalar();
                        }

                        transaction.Commit();
                        //Console.WriteLine($"The requirement with Id {test.RequirementId} was successfully registered.");
                        return question;
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        //throw new Exception($"An error occurred while registering the requirement in the company position. \n\nSqlException: {ex.Message}");
                        throw new Exception($"An error occurred. \n\nSqlException: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred. \n\nException: {ex.Message}");
            }
        }

        //public VMTestEntire InsertTest(VMTestEntire test) {
        //    return test;
        //}

        //public VMTestEntire InsertTest(VMTestEntire test)
        //{
        //    try
        //    {
        //        string sql = @"-- Insert requirement in company position
        //                        INSERT INTO companyPositions_positionRequirements_tb (
        //                          company_position_id, 
        //                          requirement_id, 
        //                          group_name
        //                        ) 
        //                        VALUES (
        //                          @CompanyPositionId, 
        //                          @RequirementId, 
        //                          @GroupName
        //                        );";


        //        Dictionary<MTest, List<MQuestion>> testQuestions = new Dictionary<MTest, List<MQuestion>>();

        //        var mreq = new MRequirement()
        //        { 
        //            RequirementId= test.Requirement.RequirementId,
        //            RequirementName= test.Requirement.RequirementName
        //        };

        //        var mtest = new MTest()
        //        {
        //            TestId = test.TestId,
        //            Description = test.Description,
        //            RequirementId = mreq.RequirementId
        //        };

        //        if(!testQuestions.ContainsKey(mtest))
        //        {
        //            testQuestions.Add(mtest, new List<MQuestion>());
        //        }

        //        foreach (var question in test.QuestionsAlternatives)
        //        {
        //            var mquestion = new MQuestion()
        //            {
        //                Description= question.Description,
        //                IsRequired= question.IsRequired,
        //                Question = question.Question,
        //                QuestionId = question.QuestionId,
        //                QuestionTypeId = question.Type.QuestionTypeId
        //            };

        //            testQuestions[mtest].Add(mquestion);
        //        }




        //        using (SqlConnection connection = new SqlConnection(_connectionString))
        //        {
        //            connection.Open();
        //            SqlTransaction transaction = connection.BeginTransaction();

        //            try
        //            {
        //                // Add career map
        //                using (SqlCommand command = new SqlCommand(sql, connection))
        //                {
        //                    command.Transaction = transaction;
        //                    command.Parameters.AddWithValue("@CompanyPositionId", test.CompanyPositionId);
        //                    command.Parameters.AddWithValue("@RequirementId", test.RequirementId);
        //                    command.Parameters.AddWithValue("@GroupName", test.GroupName != null ? test.GroupName : DBNull.Value);
        //                    command.ExecuteNonQuery();
        //                }

        //                transaction.Commit();
        //                Console.WriteLine($"The requirement with Id {test.RequirementId} was successfully registered.");
        //                return test;
        //            }
        //            catch (SqlException ex)
        //            {
        //                transaction.Rollback();
        //                throw new Exception($"An error occurred while registering the requirement in the company position. \n\nSqlException: {ex.Message}");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"An error occurred. \n\nException: {ex.Message}");
        //    }
        //}

    }
}
