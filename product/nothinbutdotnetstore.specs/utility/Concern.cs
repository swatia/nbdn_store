using NUnit.Framework;

namespace nothinbutdotnetstore.specs.utility
{
    [TestFixture]
    public abstract class BaseConcern
    {
        [SetUp]
        public void driver()
        {
            arrange();
            act();
        }

        protected abstract void act();

        protected virtual void arrange()
        {

        }
    }
}