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

using BH.oM.Base;

using BH.oM.Base.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using MathNet.Numerics;
using BH.oM.Maths;

namespace BH.Engine.Maths
{
    public static partial class Compute
    {

        //[Description("Computes the factorial of an integer accurately up until 170 where it will overflow.")]
        //[Input("Int", "Integer greater than or equal to 1.")]
        //[Output("Factorial", "Factorial of the integer")]
        public static Matrix Addition(this Matrix m1, Matrix m2)
        {
            if (m1.IsValid() == false || m2.IsValid() == false)
            {
                BH.Engine.Base.Compute.RecordError("These are not all valid matrices.");
                return null;
            }
            if (BH.Engine.Maths.Query.CompareElements(m1, m2) == false)
            {
                BH.Engine.Base.Compute.RecordError("These matrices are not the same size.");
                return null;
            }

            Matrix sum = new Matrix();

            
            for (int i = 0; i < m1.Values.Count(); i++)
            {
                List<double> currentRow = new List<double>();
                for (int j = 0; j < m1.Values.Count(); j++)
                {
                    currentRow.Add(m1.Values[i][j] + m2.Values[i][j]);
                }
                sum.Values.Add(currentRow);
            }

            return sum;
        }

    }
}

