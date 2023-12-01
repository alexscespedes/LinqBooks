using LinqBooks;
using System.Text.RegularExpressions;

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

// BookCount
//Console.WriteLine(queries.BookCount());


// BookMinMax
//Console.WriteLine(queries.BookMinMax());

// BookMinMaxBy
//var book = queries.BookMinMaxBy();
//Console.WriteLine(book.Title + " - " + book.PublishedDate.ToShortDateString());

// BookSum
//Console.WriteLine(queries.BookSum());

// BookAggregate
//Console.WriteLine(queries.BookAggregate());

// BookAverage
//Console.WriteLine(queries.BookAverage());

// BooksGroupBy
//PrintGroup(queries.BooksGroupBy());

//DictBooksLooksUp
//var dictBook = queries.DictBooksLooksUp();
//printDictionary(dictBook, 'S');

// BooksJoin
PrintValues(queries.BooksJoin());



void PrintValues(IEnumerable<Book> listOfBooks)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Title", "Pages", "Published Date");

    foreach (var book in listOfBooks)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
    }
}

void PrintGroup(IEnumerable<IGrouping<int, Book>> listOfGroups)
{
    foreach (var group in listOfGroups)
    {
        Console.WriteLine("");
        Console.WriteLine($"Group: {group.Key}");
        Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Title", "N. Pages", "Published Date");
        foreach (var item in group)
        {
            Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
        }
    }
}

void printDictionary(ILookup<char, Book> listBooks, char letter)
{
    char letterUpper = Char.ToUpper(letter);
    if (listBooks[letterUpper].Count() == 0)
    {
        Console.WriteLine($"No hay libros que inicien con la letra '{letterUpper}'");
    }
    else
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Título", "Nro. Páginas", "Fecha de Publicación");
        foreach (var book in listBooks[letterUpper])
        {
            Console.WriteLine("{0, -60} {1, 15} {2, 15}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
        }
    }
}

