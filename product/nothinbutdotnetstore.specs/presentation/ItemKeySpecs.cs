using System.Collections.Specialized;
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
            ItemKey<long> sut;

            [SetUp]
            protected void arrange()
            {
                key_name = "blah";
                sut = new ItemKey<long>(key_name);
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
        public class when_mapping_from_a_name_value_collection_and_the_value_is_in_the_payload
        {
            long result;
            string key_name;
            ItemKey<long> sut;
            NameValueCollection payload;
            long value;

            [SetUp]
            protected void arrange()
            {
                value = 42;
                key_name = "blah";
                payload = new NameValueCollection();
                payload.Add(key_name, value.ToString());

                sut = new ItemKey<long>(key_name);
            }

            [Test]
            public void should_return_the_mapped_value_as_the_correct_type_of_value()
            {
                result = sut.map_from(payload);

                Assert.AreEqual(value,result);
            }
        } 
    }
}