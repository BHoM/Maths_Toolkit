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
        [Description("Returns the number of coloumns in a matrix")]
        [Input("mat", "A Matrix")]
        [MultiOutput(0, "n", "The number of coloumns in a matrix")]
        [MultiOutput(1, "m", "The number of rows in a matrix")]
        public static Output<int,int> MatrixSize(this Matrix mat)
        {
            Output<int, int> output = new Output<int,int>();

            output.Item1 = MatrixSizeColumns(mat);
            output.Item2 = MatrixSizeRows(mat);

            return output;
        }

        [Description("Returns the number of coloumns in a matrix")]
        [Input("mat", "A Matrix")]
        [Output("Coloumns", "The number of coloumns in a matrix")]
        public static int MatrixSizeRows(this Matrix mat)
        {
            if (mat.IsValid() == false)
            {
                BH.Engine.Base.Compute.RecordError("This is not a valid matrix.");
                return -1;
            }
            int cols = mat.Values.Count();
            return cols;
        }

        [Description("Returns the number of coloumns in a matrix")]
        [Input("mat", "A Matrix")]
        [Output("Rows", "The number of coloumns in a matrix")]
        public static int MatrixSizeColumns(this Matrix mat)
        {
            if (mat.IsValid() == false)
            {
                BH.Engine.Base.Compute.RecordError("This is not a valid matrix.");
                return -1;
            }
            int rows = mat.Values[0].Count();
            return rows;
        }

    }
}


