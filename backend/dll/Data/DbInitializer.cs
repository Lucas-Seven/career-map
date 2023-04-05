namespace dll.Data
{
    internal class DbInitializer
    {
        public static void Initialize(AprovAtosContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
