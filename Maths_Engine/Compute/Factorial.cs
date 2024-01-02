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

using BH.oM.Base;

using BH.oM.Base.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using MathNet.Numerics;

namespace BH.Engine.Maths
{
    public static partial class Compute
    {

        [Description("Computes the factorial of an integer accurately up until 170 where it will overflow.")]
        [Input("number", "Integer greater than or equal to 1.")]
        [Output("Factorial", "Factorial of the integer")]
        public static double Factorial(int number)
        {
            if (number < 0)
            {
                BH.Engine.Base.Compute.RecordError("Number must be greater than or equal to 0.");
            }
            if (number > 170)
            {
                BH.Engine.Base.Compute.RecordWarning("Factorial is too large, and will overflow.");
            }
            return MathNet.Numerics.SpecialFunctions.Factorial(number);
        }

    }
}


