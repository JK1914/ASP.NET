using BookStore.Extentions;
using BookStore.Models;
using BookStore.Services;

namespace BookStore
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddBookStorage();

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSingleton<ILibraryStorage, LibraryStorage>();
            builder.Services.AddSingleton<IUserStorage, UserStorage>();
            builder.Services.AddSingleton<List<Library>>(provider => { return new List<Library>() {
                new Library() {
                    Name = "Библиотека им. Расширения Кругозора",AvailableBooks = new List<Book>(){
                        new Book(){
                            Id = 1,
                            Name = "Отель 'У погибшего альпиниста'",
                            AuthorName = "Стругацкие",
                            PublisherDate = new DateTime(1970,09,05),
                            Description = "Приехав по срочному вызову в отель, инспектор полиции не обнаружил ничего уголовнонаказуемого, но подметил происходящие там странности. Снежная лавина не позволила ему уехать в тот же день, и вскоре инспектор обнаружил тело убитого постояльца. Подозрение падает на всех, кто живет в отеле.",
                            IsBooked = false,
                            ImageUrl = "https://avatars.mds.yandex.net/get-kinopoisk-image/1946459/fe248003-7e5b-402c-ad91-de9176a2f567/1920x"
                        },
                        new Book(){
                            Id = 2,
                            Name = "Отель 'У погибшего альпиниста'",
                            AuthorName = "Стругацкие",
                            PublisherDate = new DateTime(1970,09,05),
                            Description = "Приехав по срочному вызову в отель, инспектор полиции не обнаружил ничего уголовнонаказуемого, но подметил происходящие там странности. Снежная лавина не позволила ему уехать в тот же день, и вскоре инспектор обнаружил тело убитого постояльца. Подозрение падает на всех, кто живет в отеле.",
                            IsBooked = false,
                            ImageUrl = "https://avatars.mds.yandex.net/get-kinopoisk-image/1946459/fe248003-7e5b-402c-ad91-de9176a2f567/1920x"
                        },
                        new Book(){
                            Id = 3,
                            Name = "Отель 'У погибшего альпиниста'",
                            AuthorName = "Стругацкие",
                            PublisherDate = new DateTime(1970,09,05),
                            Description = "Приехав по срочному вызову в отель, инспектор полиции не обнаружил ничего уголовнонаказуемого, но подметил происходящие там странности. Снежная лавина не позволила ему уехать в тот же день, и вскоре инспектор обнаружил тело убитого постояльца. Подозрение падает на всех, кто живет в отеле.",
                            IsBooked = false,
                            ImageUrl = "https://avatars.mds.yandex.net/get-kinopoisk-image/1946459/fe248003-7e5b-402c-ad91-de9176a2f567/1920x"
                        },
                        new Book(){
                            Id = 4,
                            Name = "Луна - суровая хозяйка",
                            AuthorName = "Р. Хайнлайн",
                            PublisherDate = new DateTime(1965,09,05),
                            Description = "Все знают Луну как космическую тюрьму, многие десятилетия сюда ссылали с Земли уголовников и диссидентов. Теперь это сырьевой придаток метрополии, обеспечивающий её бесценным зерном. Но однажды Лунная администрация перегнула палку — и лунари взбунтовались.",
                            IsBooked = false,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/ru/c/c7/Heinlein_-_Moon_Is_a_Harsh_Mistress_1_edition_%28IF_12.1965%29.jpg"
                        },
                        new Book(){
                            Id = 5,
                            Name = "Луна - суровая хозяйка",
                            AuthorName = "Р. Хайнлайн",
                            PublisherDate = new DateTime(1965,09,05),
                            Description = "Все знают Луну как космическую тюрьму, многие десятилетия сюда ссылали с Земли уголовников и диссидентов. Теперь это сырьевой придаток метрополии, обеспечивающий её бесценным зерном. Но однажды Лунная администрация перегнула палку — и лунари взбунтовались.",
                            IsBooked = false,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/ru/c/c7/Heinlein_-_Moon_Is_a_Harsh_Mistress_1_edition_%28IF_12.1965%29.jpg"
                        },
                        new Book(){
                            Id = 6,
                            Name = "Непобедимый",
                            AuthorName = "С. Лем",
                            PublisherDate = new DateTime(1964,09,05),
                            Description = "Совершенство технического гения — крейсер «Непобедимый» — совершает посадку на планету Регис III. Год назад здесь исчез похожий звездолёт, не вышедший на связь после посадки. Экспедиция корабля стремится выяснить, что произошло. А Регис III пустынен, ничем не примечателен... и до странного тих.",
                            IsBooked = false,
                            ImageUrl = "https://book24.kz/upload/resize_cache/iblock/fde/239_390_1/fdecc3f025a340bd1ce462d798b69978.jpg"
                        },
                        new Book(){
                            Id = 7,
                            Name = "Непобедимый",
                            AuthorName = "С. Лем",
                            PublisherDate = new DateTime(1964,09,05),
                            Description = "Совершенство технического гения — крейсер «Непобедимый» — совершает посадку на планету Регис III. Год назад здесь исчез похожий звездолёт, не вышедший на связь после посадки. Экспедиция корабля стремится выяснить, что произошло. А Регис III пустынен, ничем не примечателен... и до странного тих.",
                            IsBooked = false,
                            ImageUrl = "https://book24.kz/upload/resize_cache/iblock/fde/239_390_1/fdecc3f025a340bd1ce462d798b69978.jpg"
                        },   
                        //new Book(){
                        //    Id = 8,
                        //    Name = "Аэропорт",
                        //    AuthorName = "А. Хейли",
                        //    PublisherDate = new DateTime(1970,09,05),
                        //    Description = "Город, где находится крупнейший аэропорт, неожиданно накрывает снежный буран, поэтому все службы работают в экстренном режиме. На сотрудников аэропорта обрушивается одна проблема за другой - сначала непонятно где исчезает машина с продуктами, а потом на борту одного из самолетов происходит страшная авария. Ко всему прочему добавляются обострившиеся личные проблемы героев, их сложные душевные драмы - вот в такой запутанный клубок сюжетных линий завяжется действие романа, уместившееся в один пятничный вечер.",
                        //    IsBooked = false,
                        //    ImageUrl = "https://simg.marwin.kz/media/catalog/product/cache/8d1771fdd19ec2393e47701ba45e606d/c/o/cover1_54_54.jpg"
                        //},
                        new Book(){
                            Id = 9,
                            Name = "Вино из одуванчиков",
                            AuthorName = "Р. Брэдбери",
                            PublisherDate = new DateTime(1957,09,05),
                            Description = "Войдите в светлый мир двенадцатилетнего мальчика и проживите с ним одно лето, наполненное событиями радостными и печальными, загадочными и тревожными; лето, когда каждый день совершаются удивительные открытия, главное из которых — ты живой, ты дышишь, ты чувствуешь!",
                            IsBooked = false,
                            ImageUrl = "https://simg.marwin.kz/media/catalog/product/cache/8d1771fdd19ec2393e47701ba45e606d/c/o/cover1__w600_43_59.jpg"
                        },

                    }
                    }
                };
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Library}/{action=Index}/{id?}");

            await app.RunAsync();
        }
    }
}