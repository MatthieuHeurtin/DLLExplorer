using System;

namespace heurtin.Loader.Loader
{
    public interface IDllParser
    {
        void Parse(string folderPath);
        event EventHandler<DllParserEventParam> DllParserEvent;
    }
}