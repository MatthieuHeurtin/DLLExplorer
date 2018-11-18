using System;

namespace heurtin.Loader.Loader
{
    internal interface IDllAnalyser
    {
        void Analyse(string dllPath);
        event EventHandler<DLLAnalyseEventParam> AnalyseTerminated;
    }
}