using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Export2DMap;

namespace ExportApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Exporter export2DMap = new Exporter();
            export2DMap.Save();
        }
    }
}
