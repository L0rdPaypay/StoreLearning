using System;
using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "ISBN 11111-11111", "Ya. Napisal", "Aboba-San", "OOOchen` interesnay kniga", 7.19m),
            new Book(2, "ISBN 22222-22222", "Kto-to tam napisal", "Naruto", "Ya Naruto Yzumaki, ya stany velikim Hokage", 12.45m),
            new Book(3, "ISBN 33333-33333", "eto voobshe derevnya", "Konoha", "Listik delaet` pym pym. Texnika 1000 letney boli", 69.99m),
        };

        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(book =>  book.Isbn == isbn)
                        .ToArray();
        }

        public Book GetById(int id)
        {
            return books.Single(book => book.Id == id);
        }

        Book[] IBookRepository.GetAllByTitleOrAuthor(string query)
        {
            return books.Where(book => book.Author.Contains(query)
                                    || book.Title.Contains(query))
                        .ToArray();
        }
    }
}
