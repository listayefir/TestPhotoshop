﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public class SimpleParametersHandler<TParameters> : IParametersHandler<TParameters>
        where TParameters:IParameters, new()
    {
        public TParameters CreateParameters(double[] values)
        {
            var parameters = new TParameters();

            var properties = parameters
               .GetType()
               .GetProperties()
               .Where(x => x.GetCustomAttributes(typeof(ParameterInfo), false).Length > 0)
               .ToArray();

            for (int i = 0; i < values.Length; i++)
            {
                properties[i].SetValue(parameters, values[i], new object[0]);
            }

            return parameters;
        }

        public ParameterInfo[] GetDescription()
        {
            return typeof(TParameters)                
                .GetProperties()
                .Select(x => x.GetCustomAttributes(typeof(ParameterInfo), false))
                .Where(x => x.Length > 0)
                .Select(x => x[0])
                .Cast<ParameterInfo>()
                .ToArray();
        }
    }
}
