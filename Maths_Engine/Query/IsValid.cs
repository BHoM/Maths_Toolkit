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
using BH.oM.Base;
using BH.oM.Base.Attributes;
using BH.oM.Maths;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace BH.Engine.Maths
{
    public static partial class Query
    {
        [Description("Checks if the matrix is valid")]
        [Input("mat", "A Matrix")]
        [Output("IsValid", "The number of coloumns in a matrix")]
        public static bool IsValid(this Matrix mat)
        {
            if (mat.Values == null && mat.Values.Count() == 0)
            {
                BH.Engine.Base.Compute.RecordError("This is a null matrix.");
                return false;
            }

            int length = mat.Values[0].Count;

            foreach (List<double> row in mat.Values)
            {
                if (row.Count != length) 
                {
                    BH.Engine.Base.Compute.RecordError("This is not a valid matrix.");
                    return false;
                }
            }
            
            return true;

        }

    }
}


