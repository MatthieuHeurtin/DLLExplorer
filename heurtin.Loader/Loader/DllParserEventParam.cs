using System;
using System.Collections.Generic;

namespace heurtin.Loader.Loader
{
    public class DllParserEventParam : EventArgs
    {
        public IEnumerable<DLLProperties> parap { get; private set; }


        public DllParserEventParam(IEnumerable<DLLProperties> para)
        {
            parap = para;
        }
    }
}
