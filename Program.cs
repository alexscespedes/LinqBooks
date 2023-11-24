using LinqBooks;

LinqQueries queries = new LinqQueries();

//PrintValues(queries.AllCollection());

// All the collection
//PrintValues(queries.AllCollection());

// Books After 2000
//PrintValues(queries.BooksAfter2000());

// Books Page Tittle
//PrintValues(queries.BooksPageTitle());

// Books Status
//Console.WriteLine(queries.AllBooksCollection());

// Books 2005
//Console.WriteLine(queries.AllBooks2005());

// Python Books
//PrintValues(queries.PythonBooks());

// JavaBooksByName
//PrintValues(queries.JavaBooksByNameAsc());

// BooksByPageDesc
//PrintValues(queries.BooksByPageDesc());

// BooksTakeOperator
//PrintValues(queries.BooksTakeOperator());

// BooksSkipOperator
//PrintValues(queries.BooksSkipOperator());

// SelectBooks
//PrintValues(queries.SelectBooks());

void PrintValues(IEnumerable<Book> listOfBooks)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Title", "Pages", "Published Date");

    foreach (var book in listOfBooks)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
    }
}