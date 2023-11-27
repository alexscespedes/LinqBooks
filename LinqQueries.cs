using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBooks
{
    public class LinqQueries
    {
        private List<Book> bookCollection = new List<Book>();

        public LinqQueries() 
        {
            using (StreamReader reader = new StreamReader("books.json"))
            {
                string json = reader.ReadToEnd();
                this.bookCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true})!;
            }
        }

        public IEnumerable<Book> AllCollection()
        {
            return this.bookCollection;
        }

        public IEnumerable<Book> BooksAfter2000() 
        {
            //extension method
            //return bookCollection.Where(p => p.PublishedDate.Year > 2000); 

            //query expression
            return from book in bookCollection where book.PublishedDate.Year > 2000 select book;

        }

        public IEnumerable<Book> BooksPageTitle()
        {
            //extension method
            //return bookCollection.Where(p => p.PageCount > 250 && p.Title.Contains("Action")); 

            //query expression
            return from book in bookCollection where book.PageCount > 250 && book.Title.Contains("Action") select book;

        }

        public bool AllBooksCollection()
        {
            return this.bookCollection.All(p=> p.Status!= string.Empty);
        }

        public bool AllBooks2005()
        {
            return this.bookCollection.Any(p => p.PublishedDate.Year == 2005);
        }

        public IEnumerable<Book> PythonBooks()
        {
            return bookCollection.Where(p => p.Categories.Contains("Python"));
        }

        public IEnumerable<Book> JavaBooksByNameAsc()
        {
            return bookCollection.Where(p => p.Categories.Contains("Java")).OrderBy(p => p.Title);
        }

        public IEnumerable<Book> BooksByPageDesc()
        {
            return bookCollection.Where(p => p.PageCount > 450).OrderByDescending(p => p.PageCount);
        }

        public IEnumerable<Book> BooksTakeOperator()
        {
            return bookCollection.Where(p => p.Categories.Contains("Java")).OrderByDescending(p => p.PublishedDate).Take(3);
        }

        public IEnumerable<Book> BooksSkipOperator()
        {
            return bookCollection.Where(p => p.PageCount > 400).Skip(2).Take(2);
        }

        public IEnumerable<Book> SelectBooks()
        {
            return bookCollection.Take(3).Select(p=> new Book() {Title = p.Title, PageCount = p.PageCount});
        }

        public int BookCount()
        {
            //return bookCollection.Where(p => p.PageCount > 199 && p.PageCount < 501).Count();
            return bookCollection.Count(p => p.PageCount > 199 && p.PageCount < 501);
        }

        public long BookLongCount()
        {
            return bookCollection.LongCount(p => p.PageCount > 199 && p.PageCount < 501);
        }

        public int BookMinMax()
        {
            //return bookCollection.Min(p => p.PublishedDate);
            return bookCollection.Max(p => p.PageCount);
        }

        public Book? BookMinMaxBy()
        {
            return bookCollection.MaxBy(p => p.PublishedDate);
            //return bookCollection.Where(p => p.PageCount > 0).MinBy(p => p.PageCount);
        }

        public int BookSum()
        {
            return bookCollection.Where(p => p.PageCount >= 0 && p.PageCount <= 500).Sum(p=> p.PageCount);
        }

        public string BookAggregate()
        {
            return bookCollection.Where(p => p.PublishedDate.Year > 2015).Aggregate("", (BookTitle, next) =>
            {
                if(BookTitle != null)
                {
                    BookTitle += " \n " + next.Title;
                } else
                {
                    BookTitle += next.Title;
                }

                return BookTitle;
            });
        }

        public double BookAverage()
        {
            return bookCollection.Average(p=> p.Title.Length);
        }
    }
}
