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
using StackExchange.Redis;

namespace BookStore.Controllers
{
    public class SearchController : Controller
    {
        private readonly SearchIndexClient _playerClient;
        private readonly SearchIndexClient _booksClient;
        private IDatabase _cache;

        public SearchController()
        {
            var indexClient = AzureHelpers.CreateSearchServiceClient();
            
            _playerClient = indexClient.Indexes.GetClient(AzureHelpers.PlayersIndexName);
            _booksClient = indexClient.Indexes.GetClient(AzureHelpers.BooksIndexName);

            var redisConnection = AzureHelpers.CreateRedisConnection();
            _cache = redisConnection.GetDatabase();

        }

        // GET: Search
        public ActionResult Search(string term)
        {

            var cached = _cache.StringGet(term);
            if (cached.HasValue)
            {
                var cachedObject = JsonConvert.DeserializeObject<BooksAndPlayersSearchResults>(cached.ToString());
                return View(cachedObject);
            }

            var query = $"name={term}&$top = 5";


            var players = _playerClient.Documents.Search<Player>(query);
            var books = _booksClient.Documents.Search<Book>(query);

            var searchResult = new BooksAndPlayersSearchResults()
            {
                PlayerResults = players.Results.Select(t=>t.Document),
                BookResults = books.Results.Select(t=>t.Document),
            };

            _cache.StringSet(term, JsonConvert.SerializeObject(searchResult), TimeSpan.FromSeconds(20));

            return View(searchResult);
        }
    }
}