namespace dll.DAL
{
    public class QuestionTypesDAO
    {
        private readonly string _connectionString;
        public QuestionTypesDAO(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
