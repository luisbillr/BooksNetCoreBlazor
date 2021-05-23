using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BooksApp.Entities;

namespace BooksApp.Services
{
    public class BooksService : ServiceBase
    {
        string apiUrl = "books";
        //JsonGlobalParam JsonGlobalParam = new JsonGlobalParam();
        public async Task<IEnumerable<Book>> Get()
        {
            try
            {
                var result = await GetAsync<Book>(apiUrl, null);
                return result;
            }
            catch (Exception ex)
            {

                throw  new Exception("Error al obtener los datos", ex);
            }
           
        }
        public async Task<IEnumerable<Book>> Get(int id = -1)
        {
            try
            {
                var result = await GetAsync<Book>(apiUrl + "/" + id, null);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los datos", ex);
                
            }
     
        }

        public BooksService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory, configuration)
        {

        }

        public async Task SaveBook(Book book)
        {
            try
            {
                await PostAsync<Book>(apiUrl, book);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar", ex);
            }

        }
        public async Task UpdateBook(Book book)
        {
            try
            {
                await PutAsync<Book>($"{apiUrl}/{book.id}", book);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar", ex);
            }

        }
        public async Task DeleteBook(int id)
        {
            try
            {
                await DeleteAsync<Book>($"{apiUrl}/{id}", null);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar", ex);
            }

        }
    }
}
