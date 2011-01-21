using System.Collections.Generic;
using System.Collections.Specialized;
using nothinbutdotnetstore.tasks;

namespace nothinbutdotnetstore.presentation
{
    public interface ProductBrowserView
    {
        void display(IEnumerable<Product> products);
        NameValueCollection payload { get;}
    }
}