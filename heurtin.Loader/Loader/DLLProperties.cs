using System;

namespace heurtin.Loader.Loader
{
    public class DLLProperties
    {
        public string Name { get; set; }
        public DateTime Modified { get; internal set; }
        public string FullPath { get; set; }
    }
}