/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * The BHoM is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Lesser General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * The BHoM is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Lesser General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Lesser General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
 */

using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.Tests.Maths
{
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

