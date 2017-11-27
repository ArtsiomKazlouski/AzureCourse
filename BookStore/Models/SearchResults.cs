using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class BooksAndPlayersSearchResults
    {
        public BooksAndPlayersSearchResults()
        {
            BookResults = Enumerable.Empty<Book>();
            PlayerResults = Enumerable.Empty<Player>();
        }

        public IEnumerable<Book> BookResults{ get; set; }
        public IEnumerable<Player> PlayerResults{ get; set; }
    }
}