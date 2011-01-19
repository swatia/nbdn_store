using NUnit.Framework;

namespace nothinbutdotnetstore.specs
{
    public static class AssertionExtensions
    {
        public static void should_equal<T>(this T actual, T expected)
        {
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}