/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2024, the respective contributors. All rights reserved.
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

using BH.Engine.Base;
using BH.oM.Maths;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.Engine.Maths;
using Shouldly;

namespace BH.Tests.Maths
{
    public class MatrixAddition
    {
        [SetUp]
        public void SetUp()
        {
            BH.Engine.Base.Compute.ClearCurrentEvents();
        }

        [Test]
        public void AddSimpleMatrix()
        {
            List<List<double>> matrixValues = new List<List<double>>();

            matrixValues.Add(new List<double>() { 1, 2, 3 });
            matrixValues.Add(new List<double>() { 4, 5, 6 });
            matrixValues.Add(new List<double>() { 7, 8, 9 });

            Matrix leftMatrix = new Matrix() { Values = matrixValues };
            Matrix rightMatrix = new Matrix() { Values = matrixValues };

            Matrix result = leftMatrix.Addition(rightMatrix);

            result.ShouldNotBe(null);

            result.Values.Count.ShouldBe(3);
            if (result.Values.Count == 3)
            {
                result.Values[0].Count.ShouldBe(3);
                result.Values[1].Count.ShouldBe(3);
                result.Values[2].Count.ShouldBe(3);

                if (result.Values[0].Count == 3)
                {
                    result.Values[0][0].ShouldBe(2);
                    result.Values[0][1].ShouldBe(4);
                    result.Values[0][2].ShouldBe(6);
                }

                if (result.Values[1].Count == 3)
                {
                    result.Values[1][0].ShouldBe(8);
                    result.Values[1][1].ShouldBe(10);
                    result.Values[1][2].ShouldBe(12);
                }

                if (result.Values[2].Count == 3)
                {
                    result.Values[2][0].ShouldBe(14);
                    result.Values[2][1].ShouldBe(16);
                    result.Values[2][2].ShouldBe(18);
                }
            }
        }

        [Test]
        public void AddComplexMatrix()
        {
            List<List<double>> leftMatrixValues = new List<List<double>>();
            leftMatrixValues.Add(new List<double>() { 1, 2, 3 });
            leftMatrixValues.Add(new List<double>() { 4, 5, 6 });
            leftMatrixValues.Add(new List<double>() { 7, 8, 9 });

            Matrix leftMatrix = new Matrix() { Values = leftMatrixValues };

            List<List<double>> rightMatrixValues = new List<List<double>>();
            rightMatrixValues.Add(new List<double>() { 43, 12, 9 });
            rightMatrixValues.Add(new List<double>() { 98, 354, 874 });
            rightMatrixValues.Add(new List<double>() { 100, 843, 453 });
            Matrix rightMatrix = new Matrix() { Values = rightMatrixValues };

            Matrix result = leftMatrix.Addition(rightMatrix);

            result.ShouldNotBe(null);

            result.Values.Count.ShouldBe(3);
            if (result.Values.Count == 3)
            {
                result.Values[0].Count.ShouldBe(3);
                result.Values[1].Count.ShouldBe(3);
                result.Values[2].Count.ShouldBe(3);

                if (result.Values[0].Count == 3)
                {
                    result.Values[0][0].ShouldBe(44);
                    result.Values[0][1].ShouldBe(14);
                    result.Values[0][2].ShouldBe(12);
                }

                if (result.Values[1].Count == 3)
                {
                    result.Values[1][0].ShouldBe(102);
                    result.Values[1][1].ShouldBe(359);
                    result.Values[1][2].ShouldBe(880);
                }

                if (result.Values[2].Count == 3)
                {
                    result.Values[2][0].ShouldBe(107);
                    result.Values[2][1].ShouldBe(851);
                    result.Values[2][2].ShouldBe(462);
                }
            }
        }

        [Test]
        public void AddRandomMatrix()
        {
            Random rand = new Random();

            List<List<double>> leftMatrixValues = new List<List<double>>();
            leftMatrixValues.Add(new List<double>() { rand.Next(0, 1000), rand.Next(0, 1000), rand.Next(0, 1000) });
            leftMatrixValues.Add(new List<double>() { rand.Next(0, 1000), rand.Next(0, 1000), rand.Next(0, 1000) });
            leftMatrixValues.Add(new List<double>() { rand.Next(0, 1000), rand.Next(0, 1000), rand.Next(0, 1000) });

            Matrix leftMatrix = new Matrix() { Values = leftMatrixValues };

            List<List<double>> rightMatrixValues = new List<List<double>>();
            rightMatrixValues.Add(new List<double>() { rand.Next(0, 1000), rand.Next(0, 1000), rand.Next(0, 1000) });
            rightMatrixValues.Add(new List<double>() { rand.Next(0, 1000), rand.Next(0, 1000), rand.Next(0, 1000) });
            rightMatrixValues.Add(new List<double>() { rand.Next(0, 1000), rand.Next(0, 1000), rand.Next(0, 1000) });
            Matrix rightMatrix = new Matrix() { Values = rightMatrixValues };

            Matrix result = leftMatrix.Addition(rightMatrix);

            result.ShouldNotBe(null);

            result.Values.Count.ShouldBe(3);
            if (result.Values.Count == 3)
            {
                result.Values[0].Count.ShouldBe(3);
                result.Values[1].Count.ShouldBe(3);
                result.Values[2].Count.ShouldBe(3);

                if (result.Values[0].Count == 3)
                {
                    result.Values[0][0].ShouldBe(leftMatrixValues[0][0] + rightMatrixValues[0][0]);
                    result.Values[0][1].ShouldBe(leftMatrixValues[0][1] + rightMatrixValues[0][1]);
                    result.Values[0][2].ShouldBe(leftMatrixValues[0][2] + rightMatrixValues[0][2]);
                }

                if (result.Values[1].Count == 3)
                {
                    result.Values[1][0].ShouldBe(leftMatrixValues[1][0] + rightMatrixValues[1][0]);
                    result.Values[1][1].ShouldBe(leftMatrixValues[1][1] + rightMatrixValues[1][1]);
                    result.Values[1][2].ShouldBe(leftMatrixValues[1][2] + rightMatrixValues[1][2]);
                }

                if (result.Values[2].Count == 3)
                {
                    result.Values[2][0].ShouldBe(leftMatrixValues[2][0] + rightMatrixValues[2][0]);
                    result.Values[2][1].ShouldBe(leftMatrixValues[2][1] + rightMatrixValues[2][1]);
                    result.Values[2][2].ShouldBe(leftMatrixValues[2][2] + rightMatrixValues[2][2]);
                }
            }
        }

        [Test]
        public void UnableToAddUnequalRows()
        {
            List<List<double>> leftMatrixValues = new List<List<double>>();
            leftMatrixValues.Add(new List<double>() { 1, 2, 3 });
            leftMatrixValues.Add(new List<double>() { 4, 5, 6 });
            leftMatrixValues.Add(new List<double>() { 7, 8, 9 });

            Matrix leftMatrix = new Matrix() { Values = leftMatrixValues };

            List<List<double>> rightMatrixValues = new List<List<double>>();
            rightMatrixValues.Add(new List<double>() { 43, 12, 9 });
            rightMatrixValues.Add(new List<double>() { 98, 354, 874 });
            Matrix rightMatrix = new Matrix() { Values = rightMatrixValues };

            Matrix result = leftMatrix.Addition(rightMatrix);

            result.ShouldBe(null);

            var error = BH.Engine.Base.Query.CurrentEvents().LastOrDefault();
            error.Type.ShouldBe(oM.Base.Debugging.EventType.Error);
            error.Message.ShouldBe("These matrices are not the same size.");
        }

        [Test]
        public void UnableToAddUnequalColumns()
        {
            List<List<double>> leftMatrixValues = new List<List<double>>();
            leftMatrixValues.Add(new List<double>() { 1, 2 });
            leftMatrixValues.Add(new List<double>() { 4, 5, 6 });
            leftMatrixValues.Add(new List<double>() { 7, 8, 9 });

            Matrix leftMatrix = new Matrix() { Values = leftMatrixValues };

            List<List<double>> rightMatrixValues = new List<List<double>>();
            rightMatrixValues.Add(new List<double>() { 43, 12, 9 });
            rightMatrixValues.Add(new List<double>() { 98, 354, 874 });
            rightMatrixValues.Add(new List<double>() { 98, 354, 874 });
            Matrix rightMatrix = new Matrix() { Values = rightMatrixValues };

            Matrix result = leftMatrix.Addition(rightMatrix);

            result.ShouldBe(null);

            var error = BH.Engine.Base.Query.CurrentEvents().LastOrDefault();
            error.Type.ShouldBe(oM.Base.Debugging.EventType.Error);
            error.Message.ShouldBe("These are not all valid matrices.");
        }

    }
}


