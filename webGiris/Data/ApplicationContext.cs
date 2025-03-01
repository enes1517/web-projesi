using webGiris.Models;

namespace webGiris.Data
{
    public static class ApplicationContext
    {
        public static List<Book> Books { get; set; }

        static ApplicationContext()
        {
            Books = new List<Book>()
            {
                new Book{Id=1,Tittle="kemal",Price=150},
                new Book{Id=1,Tittle="sadakat",Price=100},

                new Book{Id=2,Tittle="hacivat",Price=80},
                new Book{Id=3,Tittle="carlo",Price=70}



            };

           
        }

    }
}
