///*
// * This file is part of the Buildings and Habitats object Model (BHoM)
// * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
// *
// * Each contributor holds copyright over their respective contributions.
// * The project versioning (Git) records all such contribution source information.
// *                                           
// *                                                                              
// * The BHoM is free software: you can redistribute it and/or modify         
// * it under the terms of the GNU Lesser General Public License as published by  
// * the Free Software Foundation, either version 3.0 of the License, or          
// * (at your option) any later version.                                          
// *                                                                              
// * The BHoM is distributed in the hope that it will be useful,              
// * but WITHOUT ANY WARRANTY; without even the implied warranty of               
// * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
// * GNU Lesser General Public License for more details.                          
// *                                                                            
// * You should have received a copy of the GNU Lesser General Public License     
// * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
// */

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
    public static partial class Create
    {

        [Description("Creates an empty matrix")]
        [Input("Size", "Integer greater than or equal to 1.")]
        [Output("EmptyMatrix", "Factorial of the integer")]
        public static Matrix NullMatrix(this int size)
        {
            Matrix id = new Matrix();

            for (int i = 0; i < size; i++)
            {
                List<double> row = new List<double>();
                for (int j = 0; j < size; j++)
                {
                    row.Add(0);
                }
                id.Values.Add(row);
            }

            return id;
        }

        [Description("Creates an empty matrix")]
        [Input("Size", "Integer greater than or equal to 1.")]
        [Output("IdentityMatrix", "IdentityMatrix")]
        public static Matrix IdentityMatrix(this int size)
        {
            Matrix id = new Matrix();

            for (int i = 0; i < size; i++)
            {
                List<double> row = new List<double>();
                for (int j = 0; j < size; j++)
                {
                    if (i == j)
                    {
                        row.Add(1);
                    }
                    else
                    {
                        row.Add(0);
                    }
                }
                id.Values.Add(row);
            }

            return id;
        }

    }
}

