using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FrontEnd.Pages
{
    public class IndexModel : PageModel
    {
        public Task OnGetAsync()
        {
            return Task.CompletedTask;
        }
    }
}
