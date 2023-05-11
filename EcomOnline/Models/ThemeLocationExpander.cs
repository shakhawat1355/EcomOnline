using Microsoft.AspNetCore.Mvc.Razor;

namespace EcomOnline.Models
{
    public class ThemeLocationExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            var themeViewLocations = new[]
            {
               "/Theme/ThemeA/{1}/{0}.cshtml",
            "/Theme/ThemeA/Shared/{0}.cshtml",
           "/Theme/ThemeB/{1}/{0}.cshtml",
            "/Theme/ThemeB/Shared/{0}.cshtml"
            };

            return themeViewLocations.Concat(viewLocations);
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
          
        }
    }
}
