using LibraryZh.Models;
using LibraryZh.Repository;

namespace LibraryZh.Logic;

public class LibraryService
{
    private readonly LibraryRepository repository;

    public LibraryService(LibraryRepository repository)
    {
        this.repository = repository;
    }

    // 1. 2000 után megjelent könyvek cím szerint rendezve

    public IEnumerable<Book> task1()
    {
        return repository.ReadAllBooks()
            .Where(x => x.PublishedYear > 2000)
            .OrderBy(x => x.Title)
            .ToList();
    }

    // 2. Jelenleg kikölcsönzött könyvek a kölcsönzõ nevével

    public IEnumerable<LoanedBooks> task2()
    {
        return repository.ReadAllLoans()
            .Where(x => x.ReturnedAt == null)
            .Select(x => new LoanedBooks(x.Book!.Title, x.BorrowerName)) // a felkiáltójel utána azt jeletni, hogy nem lehet null
            .ToList();
    }

    // 3. A három legtöbbször kölcsönzött könyv, cím és kölcsönzésszám visszaadásával

    public IEnumerable<MostLoanedBooks> task3()
    {
        return repository.ReadAllBooks()
            .OrderByDescending(x => x.Loans.Count)
            .Take(3)
            .Select(x => new MostLoanedBooks(x.Title, x.Loans.Count))
            .ToList();
    }
}

