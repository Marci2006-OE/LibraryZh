using System.Xml;

using LibraryZh.Logic;
using LibraryZh.Repository;

using Microsoft.EntityFrameworkCore.Query.Internal;

namespace LibraryZh.ConsoleClient;

internal class Program
{
    private static void Main(string[] args)
    {
        var context = new LibraryDbContext();
        var repository = new LibraryRepository(context);
        var service = new LibraryService(repository);

        repository.ImportJson("Data/books.json");

        Console.WriteLine("1. feladat\n");

        foreach (var x in service.task1())
        {
            Console.WriteLine($"{x.Title} | {x.PublishedYear}");
        }

        Console.WriteLine("\n2. feladat\n");

        foreach (var x in service.task2())
        {
            Console.WriteLine($"{x.Title} | {x.BorrowerName}"); 
        }

        Console.WriteLine("\n3. feladat\n");

        foreach(var item in service.task3())
        {
            Console.WriteLine($"{item.Title} | {item.Loans_number}");
        }
    }
}
