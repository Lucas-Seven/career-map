namespace dll.DAL
{
    public class QuestionAlternativesDAO
    {
        private readonly string _connectionString;
        public QuestionAlternativesDAO(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
