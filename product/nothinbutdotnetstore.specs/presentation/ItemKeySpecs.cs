using nothinbutdotnetstore.presentation;
using NUnit.Framework;

namespace nothinbutdotnetstore.specs.presentation
{
    public class ItemKeySpecs
    {
        public class when_implicitly_converted_to_a_string
        {
            string result;
            string key_name;
            ItemKey sut;

            [SetUp]
            protected void arrange()
            {
                key_name = "blah";
                sut = new ItemKey(key_name);
            }

            [Test]
            public void should_return_the_name_of_the_key()
            {
                result = sut;

                Assert.AreEqual(key_name,result);
            }

            [Test]
            public void should_return_the_name_of_the_key_when_rendered_as_a_string()
            {
                result = sut.ToString();

                Assert.AreEqual(key_name,sut.ToString());
 
            }

        } 
    }
}