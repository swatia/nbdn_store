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

            [Test]
            public void should_return_the_name_of_the_key()
            {
                key_name = "blah";

                var sut = new ItemKey(key_name);

                result = sut;

                Assert.AreEqual(key_name,result);
            } 
        } 
    }
}