using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using itbook.Dtos;
using itbook.Helpers;
using itbook.Interfaces;
using RestSharp;

namespace itbook.Services
{
    public class BookService : IBookService
    {
        private readonly string itbook_api_url;

        public BookService(IConfiguration configuration)
        {
            itbook_api_url = configuration.GetRequiredConfig("ITBOOK_API_URL");
        }

        public async Task<BookResponseDto?> GetAllAsync(string query, int page = 1)
        {
            try
            {
                // Declare client
                var client = new RestClient(itbook_api_url);
                var request = new RestRequest($"/search/{query}/{page}");
                // Get all books from api
                var response = await client.ExecuteGetAsync<BookResponseDto>(request);
                // Response books from api
                return response.IsSuccessful ? response.Data : null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<BookDto?> GetByIsbnAsync(string isbn)
        {
            try
            {
                // Declare client
                var client = new RestClient(itbook_api_url);
                var request = new RestRequest($"/books/{isbn}");
                // Get book by isbn from api
                var response = await client.ExecuteGetAsync<BookDto>(request);
                // Response book from api
                return response.IsSuccessful ? response.Data : null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
