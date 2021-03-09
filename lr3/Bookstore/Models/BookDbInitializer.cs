using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Bookstore.Models
{
    public class BookDbInitializer : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext db)
        {
            db.Books.Add(new Book { Name = "Война и мир", Author = "Л. Толстой", Price = 220, Publisher = "РосМэн" });
            db.Books.Add(new Book { Name = "Отцы и дети", Author = "И. Тургенев", Price = 180, Publisher = "РосМэн" });
            db.Books.Add(new Book { Name = "Чайка", Author = "А. Чехов", Price = 150, Publisher = "Махаон" });

            db.Purchases.Add(new Purchase { Person = "Л. Толстой", Address = "РосМэн", BookId = 1, Date = DateTime.Now });
            db.Purchases.Add(new Purchase { Person = "Лев", Address = "д. Егорово", BookId = 1, Date = DateTime.Now });

            base.Seed(db);
        }
    }
}