using BookStore.Services;

namespace BookStore.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBookStorage(this IServiceCollection services)
        {
            return services.AddSingleton<IBookStorage, BookStorage>();
        }

        public static IServiceCollection AddPersonCheck(this IServiceCollection services)
        {
            return services.AddSingleton<IPersonCheck, PersonCheck>();
        }
    }
}
