using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace heurtin.Loader.Loader
{
    class DllAnalyser : IDllAnalyser
    {
        public event EventHandler<DLLAnalyseEventParam> AnalyseTerminated;

        public void Analyse(string dllPath)
        {
            Assembly dll = Assembly.LoadFrom(dllPath);
            Type myType = dll.GetTypes()
                .Where(t => t.GetInterface("IZeus") != null ).First(); //should have only one class implementing the interface

            

            IList<ApiDescription> result = new List<ApiDescription>();
            foreach(MethodInfo methods in myType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {

                ApiDescription apiDescription = new ApiDescription()
                {
                    MethodName = methods.Name,
                    Parameters = string.Join(";", methods.GetParameters().Select(x => x.Name)),  
                   ParametersType = string.Join(";", methods.GetParameters().Select(x => x.ParameterType.ToString()))

                };

                result.Add(apiDescription);
            }

            AnalyseTerminated?.Invoke(this, new DLLAnalyseEventParam(result));
        }


    }
}
