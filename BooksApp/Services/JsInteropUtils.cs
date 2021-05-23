using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApp.Services
{
    public class JsInteropUtils
    {
        public static Task ShowModal(IJSRuntime JsRuntime, string id) => Task.Run(async () => await JsRuntime.InvokeAsync<string>("ShowModal", new string[] { id }));
        public static Task<bool> SweetMessageBox(IJSRuntime jsRuntime, string message, string icon, string redirectTo = "", int delayMilliSeconds = 1500,bool Reload = false) => Task.Run(async () => await jsRuntime.InvokeAsync<bool>("SweetMessageBox", message, icon, redirectTo, delayMilliSeconds, Reload));
        public static Task<bool> BlockPage(IJSRuntime jsRuntime) => Task.Run(async () => await jsRuntime.InvokeAsync<bool>("BlockPage"));
        public static Task<bool> UnBlockPage(IJSRuntime jsRuntime) => Task.Run(async () => await jsRuntime.InvokeAsync<bool>("UnBlockPage"));
    }
}
