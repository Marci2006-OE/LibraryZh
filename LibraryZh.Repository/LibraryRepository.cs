using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


using LibraryZh.Models;

namespace LibraryZh.Repository;
public class LibraryRepository
{
    private readonly LibraryDbContext _db;

    public LibraryRepository(LibraryDbContext db)
    {
        _db = db;
    }

    public IQueryable<Book> ReadAllBooks()
    {
        return _db.Books;
    }
    public IQueryable<Loan> ReadAllLoans()
    {
        return _db.Loans;
    }

    public void ImportJson(string filePath)
    {
        var lines = File.ReadAllText(filePath);
        var json = JsonSerializer.Deserialize<List<Book>>(lines);
        _db.Books.AddRange(json ?? throw new Exception("json file is empty"));
        _db.SaveChanges();
    }
}
