using Microsoft.Data.SqlClient;
using viewmodels.CareerMap;
using viewmodels.Form;

namespace dll.DAL
{
    public class QuestionAlternativesDAO
    {
        private readonly string _connectionString;
        public QuestionAlternativesDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public VMQuestionAlternatives GetQuestionById(int questionId)
        {
            try
            {
                VMQuestionAlternatives question = new VMQuestionAlternatives();

                string sql = @"--X
                     --		DECLARE @questionId INT = 1;
                                SELECT 
	                                --testQuestions tq
	                                tq.question_id,
	                                tq.question,
	                                tq.is_required,
	                                tq.description,

	                                --questionsTypes qt
	                                qt.question_type_id,
	                                qt.question_type_name,

	                                --questionAlternatives qa
	                                qa.alternative_id,
	                                qa.alternative,
	                                qa.is_right

                                FROM
	                                testQuestions_tb tq
	                                INNER JOIN questionTypes_tb qt ON tq.question_type_id = qt.question_type_id
	                                LEFT JOIN questionAlternatives_tb qa on tq.question_id = qa.question_id
                                WHERE
	                                tq.question_id = @questionId
                                ORDER BY
	                                qa.alternative;";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();


                    try
                    {
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@questionId", questionId);

                            using (SqlDataReader dataReader = command.ExecuteReader())
                            {
                                if (dataReader.HasRows)
                                {


                                    while (dataReader.Read())
                                    {
                                        if(question.QuestionId != questionId) { 
                                            question = new VMQuestionAlternatives()
                                            {
                                                QuestionId = Convert.ToInt32(dataReader["question_id"]),
                                                IsRequired = Convert.ToBoolean(dataReader["is_required"]),
                                                Question = dataReader["question"].ToString(),
                                                Description = !Convert.IsDBNull(dataReader["description"]) ?
                                                                dataReader["description"].ToString() :
                                                                null,

                                                Type = new VMQuestionType()
                                                {
                                                    QuestionTypeId = Convert.ToInt32(dataReader["question_type_id"]),
                                                    QuestionTypeName = dataReader["question_type_name"].ToString()
                                                },

                                                Alternatives = new List<VMAlternative>()
                                            };
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
                    catch (SqlException ex)
                    {
                        throw new Exception($"An error occurred when fetching \"test\" from the database. \n\nSqlException: {ex.Message}");
                    }
                }

                Console.WriteLine("The \"SelectTestByRequirementId\" query was successful.");
                return question;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred. \n\nException: {ex.Message}");
            }
        }
    }
}
