using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApp.Services;
using BooksApp.Entities;
using Microsoft.JSInterop;
using BooksApp.Shared;
namespace BooksApp.Pages.Books
{
    public partial class Index : BaseForJsFunctions
    {
        //[Inject]
        //internal IJSRuntime jsRuntime { get; private set; }
        [Inject]
        BooksService booksService { get; set; }
        IEnumerable<Book> books { get; set; } = new List<Book>();
        [Parameter]
        public Book Book { get; set; } = new Book();
        //void Clear() => books = null;


        protected override async Task OnInitializedAsync()
        {
           
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await BlockPage();
                books = await booksService.Get();
                await UnBlockPage();
            }
            StateHasChanged();
        }

        async Task CreateOrEdit(int idBook = -1)
        {
            if (idBook > 0)
            {
                //var book = await booksService.Get(idBook);
                await BlockPage();
                Book = books.Where(m => m.id == idBook).FirstOrDefault();
                await UnBlockPage();
            }
            else
            {
                this.Book = new Book();
            }
            await JsInteropUtils.ShowModal(jsRuntime, "#ModalCreateOrEdit");
        }
        async Task SaveOrUpdateBook()
        {
            if (this.Book.id <= 0)
            {
                await BlockPage();
                await booksService.SaveBook(this.Book);

            }
            else
            {
                await BlockPage();
                await booksService.UpdateBook(this.Book);
            }
            await UnBlockPage();
            await SweetMessageBox("Datos Guardados Correctamente", "success", "", 1500, true);

        }
        async Task DeleteBook(int id)
        {
            if (id > 0)
            {
                await BlockPage();
                await booksService.DeleteBook(id);
                await UnBlockPage();
                await SweetMessageBox("Datos Eliminados Correctamente", "success", "", 1500, true);
            }

            
        }
        void RaiseInvalidSubmit()
        {

        }
    }
}
