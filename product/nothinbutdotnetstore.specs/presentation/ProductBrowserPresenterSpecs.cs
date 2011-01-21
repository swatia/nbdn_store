using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using nothinbutdotnetstore.presentation;
using nothinbutdotnetstore.tasks;
using NUnit.Framework;

namespace nothinbutdotnetstore.specs.presentation
{
    public class ProductBrowserPresenterSpecs
    {
        public class when_initialized_and_there_is_a_department_in_the_payload
        {
            OurProductBrowserView view;
            IEnumerable<Product> results_to_be_returned_by_the_repository;
            OurProductRepository product_repository;
            long department_number;
            NameValueCollection payload;

            [SetUp]
            public void setup()
            {
                view = new OurProductBrowserView();
                results_to_be_returned_by_the_repository = Enumerable.Range(1, 10).Select(x => new Product()).ToList();
                payload = new NameValueCollection();
                department_number = 34;
                product_repository = new OurProductRepository(results_to_be_returned_by_the_repository);

                payload.Add(QueryStrings.DepartmentId,department_number.ToString());

                view.payload = payload;
            }

            [Test]
            public void
                should_tell_the_view_to_display_the_products_retrieved_by_the_products_in_the_department_in_the_payload()
            {
                var sut = new ProductBrowserPresenter(view, product_repository);

                sut.initialize();

                Assert.AreEqual(results_to_be_returned_by_the_repository, view.products);
                Assert.AreEqual(department_number, product_repository.department_requested);
            }
        }
    }

    public class OurProductRepository : ProductsRepository
    {
        IEnumerable<Product> products_to_return;
        public int department_requested { get; set; }

        public OurProductRepository(IEnumerable<Product> products_to_return)
        {
            this.products_to_return = products_to_return;
        }

        public IEnumerable<Product> get_products_for_department(int department_id)
        {
            this.department_requested = department_id;
            return products_to_return;
        }
    }

    class OurProductBrowserView : ProductBrowserView
    {
        public NameValueCollection payload { get; set; }
        public IEnumerable<Product> products { get; set; }

        public void display(IEnumerable<Product> products)
        {
            this.products = products;
        }
    }
}