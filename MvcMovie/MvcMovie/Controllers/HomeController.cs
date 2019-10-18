using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class HomeController : Controller
    {
        public IEnumerable<KeyValuePair<string, string>> FilteredConfiguration { get; private set; }

        public Starship Starship { get; private set; }

        public TvShow TvShow { get; private set; }

        public ArrayExample ArrayExample { get; private set; }

        public JsonArrayExample JsonArrayExample { get; private set; }
        // [FromServices] Specifies that an action parameter should be bound using the request services.
        public IActionResult Index([FromServices]IConfiguration cfg)
        {
            var configEntryFilter = new string[] { "ASPNETCORE_", "urls", "Logging", "ENVIRONMENT", "contentRoot", "AllowedHosts", "applicationName", "CommandLine" };
            var config = cfg.AsEnumerable();
            FilteredConfiguration = config.Where(
               kvp => config.Any(
                   i => configEntryFilter.Any(prefix => kvp.Key.StartsWith(prefix))));
            var starship = new Starship();
            cfg.GetSection("starship").Bind(starship);
            Starship = starship;
            TvShow = cfg.GetSection("tvshow").Get<TvShow>();
            ArrayExample = cfg.GetSection("array").Get<ArrayExample>();
            JsonArrayExample = cfg.GetSection("json_array").Get<JsonArrayExample>();
            Customer customer = cfg.GetSection("customer").Get<Customer>();
            var value1 = cfg.GetValue<object>("name", "read error");
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
