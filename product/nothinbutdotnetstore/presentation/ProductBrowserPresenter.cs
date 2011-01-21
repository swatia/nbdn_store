using System.Collections.Specialized;
using nothinbutdotnetstore.tasks;

namespace nothinbutdotnetstore.presentation
{
    public class ProductBrowserPresenter
    {
        protected ProductsRepository repository { get; set; }
        protected ProductBrowserView view { get; set; }
        DisplayView display_view;

        public ProductBrowserPresenter(ProductBrowserView view, DisplayView display_view) : this(display_view,
                                                                                                 new DefaultProductsRepository
                                                                                                     (), view)
        {
        }

        public ProductBrowserPresenter(DisplayView display_view, ProductsRepository repository, ProductBrowserView view)
        {
            this.display_view = display_view;
            this.repository = repository;
            this.view = view;
        }

        public void initialize()
        {
            if (there_is_a_department_in(view.payload))
            {
                view.display(repository.get_products_for_department(QueryStrings.DepartmentId.map_from(view.payload)));
                return;
            }
            display_view(Views.Department);
        }

        bool there_is_a_department_in(NameValueCollection payload)
        {
            return ! string.IsNullOrEmpty(payload[QueryStrings.DepartmentId]);
        }
    }
}