﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop.Filters
{
    public class GreyScaleParameters : IParameters
    {
        public ParameterInfo[] GetDescription()
        {
            return new ParameterInfo[0];
        }

        public void Parse(double[] parameters)
        {
            return;
        }
    }
}
