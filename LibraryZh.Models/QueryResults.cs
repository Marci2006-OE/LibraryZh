using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryZh.Models;

public record LoanedBooks(string Title, string BorrowerName);
public record MostLoanedBooks(string Title, int Loans_number);
