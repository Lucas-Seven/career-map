using dll.Models;
using Microsoft.Data.SqlClient;
using viewmodels;

namespace dll.DAL
{
    public class TestsDAO
    {
        private readonly string _connectionString;
        public TestsDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        //public TestVM SelectTestByRequirementId(int requirementId)
        //{
        //    TestVM test = null;

        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(_connectionString))
        //        {
        //            connection.Open();

        //            try
        //            {
        //                using (SqlCommand command = new SqlCommand(
        //                    "SELECT t.test_id, t.description AS 'test_description', " +
        //                    "r.requirement_id, r.requirement_name, " +
        //                    "q.question_id, q.is_required, q.question, q.description  AS 'question_description', " +
        //                    "qt.question_type_id, qt.question_type_name, " +
        //                    "a.alternative_id, a.alternative " +
        //                    "FROM tests_tb AS t " +
        //                    "INNER JOIN tests_testQuestions_tb AS tq ON tq.test_id = t.test_id " +
        //                    "INNER JOIN positionRequirements_tb AS r ON r.requirement_id = t.requirement_id " +
        //                    "INNER JOIN testQuestions_tb AS q ON q.question_id = tq.question_id " +
        //                    "INNER JOIN questionTypes_tb AS qt ON qt.question_type_id = q.question_type_id " +
        //                    "INNER JOIN questionAlternatives_tb AS a ON a.question_id = tq.question_id " +
        //                    "WHERE t.requirement_id = @requirementId;", connection))
        //                {
        //                    command.Parameters.AddWithValue("@requirementId", requirementId);

        //                    using (SqlDataReader dataReader = command.ExecuteReader())
        //                    {
        //                        if (dataReader.HasRows)
        //                        {
        //                            test = new TestVM();
        //                            test.Questions = new List<TestQuestionVM>();
        //                            while (dataReader.Read())
        //                            {
        //                                test.TestId = Convert.ToInt32(dataReader["test_id"]);
        //                                test.Description = !Convert.IsDBNull(dataReader["test_description"]) ?
        //                                                  dataReader["test_description"].ToString() :
        //                                                  null;
        //                                test.Requirement = new PositionVMRequirement()
        //                                {
        //                                    RequirementId = Convert.ToInt32(dataReader["requirement_id"]),
        //                                    RequirementName = dataReader["requirement_name"].ToString()
        //                                };

        //                                int questionId = Convert.ToInt32(dataReader["question_id"]);
        //                                TestQuestionVM question = test.Questions.FirstOrDefault(q => q.QuestionId == questionId);
        //                                if (question == null)
        //                                {
        //                                    question = new TestQuestionVM()
        //                                    {
        //                                        QuestionId = questionId,
        //                                        IsRequired = Convert.ToBoolean(dataReader["is_required"]),
        //                                        Question = dataReader["question"].ToString(),
        //                                        Description = !Convert.IsDBNull(dataReader["question_description"]) ?
        //                                                        dataReader["question_description"].ToString() :
        //                                                        null,

        //                                        Type = new QuestionTypeVM()
        //                                        {
        //                                            QuestionTypeId = Convert.ToInt32(dataReader["question_type_id"]),
        //                                            QuestionTypeName = dataReader["question_type_name"].ToString()
        //                                        },

        //                                        Alternatives = new List<QuestionAlternativeVM>()
        //                                    };
        //                                    test.Questions.Add(question);
        //                                }

        //                                question.Alternatives.Add(new QuestionAlternativeVM
        //                                {
        //                                    AlternativeId = Convert.ToInt32(dataReader["alternative_id"]),
        //                                    Alternative = dataReader["alternative"].ToString()
        //                                });
        //                            }
        //                        }
        //                    }
        //                }

        //                if (test == null)
        //                {
        //                    throw new Exception($"Test with requirement Id {requirementId} not found.");
        //                }
        //                Console.WriteLine("The SelectTestByRequirementId query was successful.");
        //                return test;
        //            }
        //            catch (SqlException ex)
        //            {
        //                throw new Exception($"An error occurred when fetching test from the database. \n\nSqlException: {ex.Message}");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"An error occurred when fetching test from the database. \n\nException: {ex.Message}");
        //    }
        //}
    }
}
