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

        public ProductBrowserPresenter(ProductBrowserView view, ProductsRepository product_by_dept_repository)
        {
            this.view = view;
            this.repository = product_by_dept_repository;
        }

        public void initialize(int DepartmentID)
        {
            view.display(repository.get_products_for_department(DepartmentID));
        }
    }
}