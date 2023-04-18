using dll.Models;
using Microsoft.Data.SqlClient;
using viewmodels;
using viewmodels.CareerMap;
using viewmodels.Form;

namespace dll.DAL
{
    public class TestsDAO
    {
        private readonly string _connectionString;
        public TestsDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public VMTestEntire SelectTestByRequirementId(int requirementId)
        {
            try
            {
                VMTestEntire test = new VMTestEntire();
                
                string sql = @"-- X
                                SELECT 
                                    t.test_id, 
                                    t.description AS test_description, 
                                    r.requirement_id, 
                                    r.requirement_name, 
                                    q.question_id, 
                                    q.is_required, 
                                    q.question, 
                                    q.description AS question_description, 
                                    qt.question_type_id, 
                                    qt.question_type_name, 
                                    a.alternative_id, 
                                    a.alternative 
                                FROM 
                                    tests_tb AS t 
                                    INNER JOIN tests_testQuestions_tb AS tq ON tq.test_id = t.test_id 
                                    INNER JOIN positionRequirements_tb AS r ON r.requirement_id = t.requirement_id 
                                    INNER JOIN testQuestions_tb AS q ON q.question_id = tq.question_id 
                                    INNER JOIN questionTypes_tb AS qt ON qt.question_type_id = q.question_type_id 
                                    INNER JOIN questionAlternatives_tb AS a ON a.question_id = tq.question_id 
                                WHERE 
                                    t.requirement_id = @requirementId;";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    try
                    {                      
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@requirementId", requirementId);

                            using (SqlDataReader dataReader = command.ExecuteReader())
                            {
                                if (dataReader.HasRows)
                                {
                                    test = new VMTestEntire();
                                    test.QuestionsAlternatives = new List<VMQuestionAlternatives>();
                                    while (dataReader.Read())
                                    {
                                        test.TestId = Convert.ToInt32(dataReader["test_id"]);
                                        test.Description = !Convert.IsDBNull(dataReader["test_description"]) ? dataReader["test_description"].ToString() : null;

                                        test.Requirement = new VMRequirement()
                                        {
                                            RequirementId = Convert.ToInt32(dataReader["requirement_id"]),
                                            RequirementName = dataReader["requirement_name"].ToString()
                                        };

                                        int questionId = Convert.ToInt32(dataReader["question_id"]);
                                        VMQuestionAlternatives question = test.QuestionsAlternatives.FirstOrDefault(q => q.QuestionId == questionId);
                                        if (question == null)
                                        {
                                            question = new VMQuestionAlternatives()
                                            {
                                                QuestionId = questionId,
                                                IsRequired = Convert.ToBoolean(dataReader["is_required"]),
                                                Question = dataReader["question"].ToString(),
                                                Description = !Convert.IsDBNull(dataReader["question_description"]) ?
                                                                dataReader["question_description"].ToString() :
                                                                null,

                                                Type = new VMQuestionType()
                                                {
                                                    QuestionTypeId = Convert.ToInt32(dataReader["question_type_id"]),
                                                    QuestionTypeName = dataReader["question_type_name"].ToString()
                                                },

                                                Alternatives = new List<VMAlternative>()
                                            };
                                            test.QuestionsAlternatives.Add(question);
                                        }

                                        question.Alternatives.Add(new VMAlternative
                                        {
                                            AlternativeId = Convert.ToInt32(dataReader["alternative_id"]),
                                            Alternative = dataReader["alternative"].ToString()
                                        });
                                    }
                                }
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception($"An error occurred when fetching \"test\" from the database. \n\nSqlException: {ex.Message}");
                    }
                }

                Console.WriteLine("The \"SelectTestByRequirementId\" query was successful.");
                return test;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred. \n\nException: {ex.Message}");
            }
        }
    }
}