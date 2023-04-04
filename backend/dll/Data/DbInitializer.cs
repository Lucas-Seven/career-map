namespace dll.Data
{
    internal class DbInitializer
    {
        public static void Initialize(CareerMapContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
