using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Helpers;
using BookStore.Models;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using Newtonsoft.Json;

namespace BookStore.Controllers
{
    public class SearchController : Controller
    {
        private readonly SearchIndexClient _playerClient;
        private readonly SearchIndexClient _booksClient;

        public SearchController()
        {
            var indexClient = AzureHelpers.CreateSearchServiceClient();
            
            _playerClient = indexClient.Indexes.GetClient(AzureHelpers.PlayersIndexName);
            _booksClient = indexClient.Indexes.GetClient(AzureHelpers.BooksIndexName);
        }

        // GET: Search
        public ActionResult Search(string term)
        {
            var query = $"name={term}&$top = 5";


            var players = _playerClient.Documents.Search<Player>(query);
            var books = _booksClient.Documents.Search<Book>(query);

            var searchResult = new BooksAndPlayersSearchResults()
            {
                PlayerResults = players.Results.Select(t=>t.Document),
                BookResults = books.Results.Select(t=>t.Document),
            };

            return View(searchResult);
        }
    }
}