using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heurtin.Loader.Loader
{
    public class DllParser : IDllParser
    {
        


        public event EventHandler<DllParserEventParam> DllParserEvent;

        //check extension
        public void Parse(string folderPath)
        {
            var result = ParseFolder(folderPath);
            DllParserEvent?.Invoke(this, new DllParserEventParam(result));

        }

        private IEnumerable<DLLProperties> ParseFolder(string folderPath)
        {
            IList<DLLProperties> result = new List<DLLProperties>();
            foreach(string str in Directory.GetFiles(folderPath))
            {
                result.Add(new DLLProperties()
                {
                    Name = Path.GetFileName(str),
                    Modified = File.GetLastWriteTime(str),
                    FullPath = str
                }
                );
            }

            return result;
        }
    }
}
