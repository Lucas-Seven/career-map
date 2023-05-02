using dll.Models.CareerMap;
using dll.Models.Form;
using Microsoft.Data.SqlClient;

namespace dll.DAL
{
    public class TestAnswersDAO
    {
        private readonly string _connectionString;
        public TestAnswersDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MTestAnswer Insert(MTestAnswer answer)
        {
            try
            {
                string sql = @"--X
                    INSERT INTO testAnswers_tb 
                        (user_id
                        ,test_id
                        ,question_id
                        ,alternative_id
                        ,dissertative_answer
                    )
                    OUTPUT INSERTED.answer_id 
                    VALUES 
                        (@userId
                        ,@testId
                        ,@questionId
                        ,@alternativeId
                        ,@dissertativeAnswer
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
                            command.Parameters.AddWithValue("@userId", answer.UserId);
                            command.Parameters.AddWithValue("@testId", answer.TestId);
                            command.Parameters.AddWithValue("@questionId", answer.QuestionId);

                            command.Parameters.AddWithValue("@dissertativeAnswer", answer.DissertativeAnswer == null? DBNull.Value : answer.DissertativeAnswer);
                            command.Parameters.AddWithValue("@alternativeId", answer.AlternativeId == null ? DBNull.Value : answer.AlternativeId);
                            answer.AnswerId = (Int32) command.ExecuteScalar();
                        }

                        transaction.Commit();
                        Console.WriteLine($"Answer {answer.AnswerId} saved! The answer to Test {answer.TestId}, Question {answer.QuestionId} was successfully registered.");
                        return answer;
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"An error occurred while registering the company position in the career map. \n\nSqlException: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred. \n\nException: {ex.Message}");
            }
        }

        public List<MTestAnswer> InsertAll(List<MTestAnswer> answers)
        {
            var data = new Dictionary<int, MTestAnswer>();

            foreach (var item in answers)
            {
                var answer = Insert(item);
                data.Add(answer.AnswerId, answer);
            }

            return data.Values.ToList();
        }
    }
}
