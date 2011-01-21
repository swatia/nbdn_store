using nothinbutdotnetstore.tasks;

namespace nothinbutdotnetstore.presentation
{
    public class ProductBrowserPresenter
    {
        protected ProductsRepository repository { get; set; }
        protected ProductBrowserView view { get; set; }

        public ProductBrowserPresenter(ProductBrowserView view)
            : this(view, new DefaultProductsRepository())
        {
        }

        public ProductBrowserPresenter(ProductBrowserView view, ProductsRepository product_repository)
        {
            this.repository = product_repository;
            this.view = view;
        }

        public void initialize()
        {
            view.display(repository.get_products_for_department(int.Parse(view.payload[QueryStrings.DepartmentId])));
        }
    }
}