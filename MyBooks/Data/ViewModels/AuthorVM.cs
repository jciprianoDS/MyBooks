using System.Collections.Generic;

namespace MyBooks.Data.ViewModels
{
    public class AuthorVM
    {
        public string FullName { get; set; }
    }

    public class AuthorWithBooksVW
    {
        public string FullName { get; set; }
        public List<string> BookTitles { get; set; }

    }
}
