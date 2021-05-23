using System;
using Xunit;
using System.Collections.Generic;
using BooksAPI.Servicios.Entidades;
using BooksAPI.Servicios;
namespace Books.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async void GetBooks()
        {

            var datos = await BooksService.Get();
            var agua = "";
        }
        [Fact]
        public async void PostBook()
        {
            Book book = new Book
            {
                title = "este es el titulo",
                description = "Hola",
                publishDate = DateTime.Now
            };
            var datos = await BooksService.Post(book);
            var agua = "";
        }
        [Fact]
        public async void PutBook()
        {
            Book book = new Book
            {
                id = 3,
                title = "este es el titulo",
                description = "Hola",
                publishDate = DateTime.Now
            };
            var datos = await BooksService.Put(book);
            var agua = "";
        }
        [Fact]
        public async void Delete()
        {
            var datos = await BooksService.Delete(1);
            var agua = "";
        }
    }
}
