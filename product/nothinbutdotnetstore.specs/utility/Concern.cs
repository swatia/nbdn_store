using NUnit.Framework;
using Rhino.Mocks;

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

        protected Dependency an<Dependency>() where Dependency : class
        {
            return MockRepository.GenerateStub<Dependency>();
        }

        protected abstract void act();

        protected virtual void arrange()
        {

        }
    }
}