using System;
using System.Collections.Generic;

namespace heurtin.Loader.Loader
{
    class DLLAnalyseEventParam : EventArgs
    {
        public IEnumerable<ApiDescription> parap { get; private set; }


        public DLLAnalyseEventParam(IEnumerable<ApiDescription> para)
        {
            parap = para;
        }
    }
}
