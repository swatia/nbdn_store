using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.presentation;
using nothinbutdotnetstore.tasks;
using NUnit.Framework;

namespace nothinbutdotnetstore.specs.presentation
{
    public class ProductBrowserPresenterSpecs
    {
        public class when_initialized
        {
            OurProductBrowserView view;
            IEnumerable<Product> results_to_be_returned_by_the_repository;
            ProductsByDepartmentRepository default_product_by_dept_repository;

            [Test]
            public void should_tell_the_view_to_display_the_products_retrieved_by_the_products_by_department_repository()
            {
                view = new OurProductBrowserView();
                results_to_be_returned_by_the_repository = Enumerable.Range(1, 10).Select(x => new Product()).ToList();
                default_product_by_dept_repository = new OurProductRepository(results_to_be_returned_by_the_repository);

                var sut = new ProductBrowserPresenter(view, default_product_by_dept_repository);

                sut.initialize(0);

                Assert.AreEqual(results_to_be_returned_by_the_repository, view.products);
            }
        }
    }

    public class OurProductRepository : ProductsByDepartmentRepository
    {
        IEnumerable<Product> return_this;

        public OurProductRepository(IEnumerable<Product> return_this)
        {
            this.return_this = return_this;
        }

        public IEnumerable<Product> get_products_for_department(int department_id)
        {
            return return_this;
        }

    }

    class OurProductBrowserView : ProductBrowserView
    {
        public IEnumerable<Product> products { get; set; }

        public void display(IEnumerable<Product> products)
        {
            this.products = products;
        }
    }

}