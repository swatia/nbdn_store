using System.Collections.Generic;
using nothinbutdotnetstore.tasks;

namespace nothinbutdotnetstore.presentation
{
    public interface ProductBrowserView
    {
            void display(IEnumerable<Product> products);

    }
}