using BookStore.Services;

namespace BookStore.Extentions
{
    public static class ServiceCollectionExentions
    {
        public static IServiceCollection AddBookStorage(this IServiceCollection services) {
            return services.AddSingleton<IBookStorage, BookStorage>();
        }
    }
}
