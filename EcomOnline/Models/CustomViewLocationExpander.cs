using Microsoft.AspNetCore.Mvc.Razor;

namespace EcomOnline.Models
{
    public class CustomViewLocationExpander : IViewLocationExpander
    {
        private readonly IConfiguration iconfig;

        //public CustomViewLocationExpander(IConfiguration iconfig)
        //{
        //    this.iconfig = iconfig;
        //}
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {


            //IConfigurationRoot config = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //    .Build();

            string value = "x";//iconfig.("Theme");

            Console.WriteLine(value);

            //return viewLocations;

            return new[]
            {
            "~/Themes/ThemeA/Home/Index.cshtml",
            "~/Themes/ThemeA/Shared/{0}.cshtml",
            "~/NewViewLocation/{0}.cshtml"
            };
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            throw new NotImplementedException();
        }
    }
}
