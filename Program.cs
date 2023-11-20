using LinqBooks;

LinqQueries queries = new LinqQueries();

PrintValues(queries.AllCollection());


void PrintValues(IEnumerable<Book> listOfBooks)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Title", "Pages", "Published Date");

    foreach (var book in listOfBooks)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
    }
}