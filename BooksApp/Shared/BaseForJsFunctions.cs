using BooksApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApp.Shared
{
    public abstract class BaseForJsFunctions : ComponentBase
    {
        [Inject]
        internal IJSRuntime jsRuntime { get; private set; }
        protected virtual async Task SweetMessageBox(string message = "", string icon = "info", string redirectTo = "", int delayMilliSeconds = 1500, bool Reload = false)
        {
            await JsInteropUtils.SweetMessageBox(jsRuntime, message, icon, redirectTo, delayMilliSeconds,Reload);
        }
        protected virtual async Task BlockPage()
        {
            await JsInteropUtils.BlockPage(jsRuntime);
           
        }
        protected virtual async Task UnBlockPage()
        {
            await JsInteropUtils.UnBlockPage(jsRuntime);
           
        }
    }
}
