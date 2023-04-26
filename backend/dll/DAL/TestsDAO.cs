using dll.Models;
using dll.Models.Form;
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

        public ICollection<VMTestEntire> SelectTestByRequirementId(int requirementId)
        {
            try
            {
                Dictionary<int, VMTestEntire> tests = new Dictionary<int, VMTestEntire>();


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
                                    LEFT JOIN tests_testQuestions_tb AS tq ON tq.test_id = t.test_id 
                                    LEFT JOIN positionRequirements_tb AS r ON r.requirement_id = t.requirement_id 
                                    LEFT JOIN testQuestions_tb AS q ON q.question_id = tq.question_id 
                                    LEFT JOIN questionTypes_tb AS qt ON qt.question_type_id = q.question_type_id 
                                    LEFT JOIN questionAlternatives_tb AS a ON a.question_id = tq.question_id 
                                WHERE 
                                    t.requirement_id = @requirementId
                                ORDER BY 
                                    t.test_id;";

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
                                    while (dataReader.Read())
                                    {
                                        var testId = Convert.ToInt32(dataReader["test_id"]);
                                        VMTestEntire test;

                                        if (!tests.ContainsKey(testId))
                                        {
                                            test = new VMTestEntire();
                                            test.TestId = Convert.ToInt32(dataReader["test_id"]);
                                            test.Description = !Convert.IsDBNull(dataReader["test_description"]) ? dataReader["test_description"].ToString() : null;

                                            test.Requirement = new VMRequirement()
                                            {
                                                RequirementId = Convert.ToInt32(dataReader["requirement_id"]),
                                                RequirementName = dataReader["requirement_name"].ToString()
                                            };

                                            tests.Add(testId, test);
                                        }

                                        test = tests[testId];

                                        if (!Convert.IsDBNull(dataReader["question_id"]))
                                        {
                                            int questionId = Convert.ToInt32(dataReader["question_id"]);

                                            VMQuestionAlternatives question = test.QuestionsAlternatives.Where(q => q.QuestionId == questionId).FirstOrDefault();
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

                                            if (!Convert.IsDBNull(dataReader["alternative_id"]))
                                            {
                                                var alternative = new VMAlternative
                                                {
                                                    AlternativeId = Convert.ToInt32(dataReader["alternative_id"]),
                                                    Alternative = dataReader["alternative"].ToString()
                                                };

                                                if (alternative != null && alternative.AlternativeId > 0)
                                                {
                                                    question.Alternatives.Add(alternative);
                                                }
                                            } 
                                        }
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
                return tests.Values.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred. \n\nException: {ex.Message}");
            }
        }

        public VMTestEntire SelectTestById(int testId)
        {
            try
            {
                VMTestEntire test = new VMTestEntire();

                string sql = @"-- X
                    -- DECLARE @requirementId INT = 3, @testId INT = 8
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
                                    LEFT JOIN tests_testQuestions_tb AS tq ON tq.test_id = t.test_id 
                                    LEFT JOIN positionRequirements_tb AS r ON r.requirement_id = t.requirement_id 
                                    LEFT JOIN testQuestions_tb AS q ON q.question_id = tq.question_id 
                                    LEFT JOIN questionTypes_tb AS qt ON qt.question_type_id = q.question_type_id 
                                    LEFT JOIN questionAlternatives_tb AS a ON a.question_id = tq.question_id 
                                WHERE 
									t.test_id = @testId 
								ORDER BY t.test_id";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    try
                    {
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@testId", testId);

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

                                        if (!Convert.IsDBNull(dataReader["requirement_id"]))
                                        {
                                            test.Requirement = new VMRequirement()
                                            {
                                                RequirementId = Convert.ToInt32(dataReader["requirement_id"]),
                                                RequirementName = dataReader["requirement_name"].ToString()
                                            };


                                            if (!Convert.IsDBNull(dataReader["question_id"]))
                                            {
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

                                                if (!Convert.IsDBNull(dataReader["alternative_id"]))
                                                {
                                                    var alternative = new VMAlternative
                                                    {
                                                        AlternativeId = Convert.ToInt32(dataReader["alternative_id"]),
                                                        Alternative = dataReader["alternative"].ToString()
                                                    };

                                                    if (alternative != null && alternative.AlternativeId > 0)
                                                    {
                                                        question.Alternatives.Add(alternative);
                                                    }
                                                } 
                                            }
                                        }
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

        public MTest Insert(MTest test)
        {
            try
            {
                string sql = @"--X
INSERT INTO tests_tb
(
     requirement_id
    ,description
)
OUTPUT INSERTED.test_id

VALUES
(
    @requirement_id
    ,@description
);";

                /*
                Dictionary<MTest, List<MQuestion>> testQuestions = new Dictionary<MTest, List<MQuestion>>();

                var mreq = new MRequirement()
                {
                    RequirementId = test.Requirement.RequirementId,
                    RequirementName = test.Requirement.RequirementName
                };

                var mtest = new MTest()
                {
                    TestId = test.TestId,
                    Description = test.Description,
                    RequirementId = mreq.RequirementId
                };

                if (!testQuestions.ContainsKey(mtest))
                {
                    testQuestions.Add(mtest, new List<MQuestion>());
                }

                foreach (var question in test.QuestionsAlternatives)
                {
                    var mquestion = new MQuestion()
                    {
                        Description = question.Description,
                        IsRequired = question.IsRequired,
                        Question = question.Question,
                        QuestionId = question.QuestionId,
                        QuestionTypeId = question.Type.QuestionTypeId
                    };

                    testQuestions[mtest].Add(mquestion);
                }

                /**/


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
                            command.Parameters.AddWithValue("@requirement_id", test.RequirementId);
                            command.Parameters.AddWithValue("@description", test.Description);

                            test.TestId = (Int32)command.ExecuteScalar();
                        }

                        transaction.Commit();
                        //Console.WriteLine($"The requirement with Id {test.RequirementId} was successfully registered.");
                        return test;
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

    }
}