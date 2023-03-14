using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.Tests.Maths
{
    [TestFixture]
    public class FactorialTests
    {
        [SetUp]
        public void Setup()
        {
            BH.Engine.Base.Compute.ClearCurrentEvents();
        }

        [Test]
        public void ZeroEqualsOne()
        {
            double result = BH.Engine.Maths.Compute.Factorial(0);
            result.ShouldBe(1.0);
        }

        [Test]
        public void OneEqualsOne()
        {
            double result = BH.Engine.Maths.Compute.Factorial(1);
            result.ShouldBe(1.0);
        }

        [Test]
        public void LessThanZero()
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException),() => BH.Engine.Maths.Compute.Factorial(-1));
            var warning = BH.Engine.Base.Query.CurrentEvents().LastOrDefault();
            warning.Type.ShouldBe(oM.Base.Debugging.EventType.Error);
            warning.Message.ShouldBe("Number must be greater than or equal to 0.");
        }

        [Test]
        public void PositiveNumber()
        {
            double result = BH.Engine.Maths.Compute.Factorial(5);
            result.ShouldBe(120.0);

        }

        [Test]
        public void MaxAccurateValue()
        {
            double result = BH.Engine.Maths.Compute.Factorial(170);
            result.ShouldBe(7.257415615307994E+306);
        }

        [Test]
        public void AboveMaxAccurateValue()
        {
            double result = BH.Engine.Maths.Compute.Factorial(171);
            result.ShouldBe(double.PositiveInfinity);
            var warning = BH.Engine.Base.Query.CurrentEvents().LastOrDefault();
            warning.Type.ShouldBe(oM.Base.Debugging.EventType.Warning);
            warning.Message.ShouldBe("Factorial is too large, and will overflow.");
        }

    }
}
