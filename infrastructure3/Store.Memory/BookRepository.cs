using System;
using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "ISBN 11111-11111", "Ya. Napisal", "Aboba-San"),
            new Book(2, "ISBN 22222-22222", "Kto-to tam napisal", "Naruto"),
            new Book(3, "ISBN 33333-33333", "eto voobshe derevnya", "Konoha"),
        };

        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(book =>  book.Isbn == isbn)
                        .ToArray();
        }

        Book[] IBookRepository.GetAllByTitleOrAuthor(string query)
        {
            return books.Where(book => book.Author.Contains(query)
                                    || book.Title.Contains(query))
                        .ToArray();
        }
    }
}
