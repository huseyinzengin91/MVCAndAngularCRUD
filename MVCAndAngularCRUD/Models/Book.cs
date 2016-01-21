using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAndAngularCRUD.Models
{
    public class Book
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public List<Book> GetSampleBookList()
        {
            List<Book> bookList = new List<Book>{
                new Book{ID=1,Name="C#", Year=2001},
                new Book{ID=2,Name="JAVA",Year=2002},
                new Book{ID=3,Name="PYTHON",Year=2003},
                new Book{ID=4,Name="JAVASCRİPT",Year=2002},
                new Book{ID=5,Name="RUBY",Year=2001},
                new Book{ID=6,Name="DELPHİ",Year=2003}
            };

            return bookList;
        }
    }
}