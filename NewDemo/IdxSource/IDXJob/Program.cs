using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdxSource;
using IdolACINet;

namespace IDXJobApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //IDXJob s = new IDXJob();
            //s.save();

            IdolACIHelper aci = new IdolACINet.IdolACIHelper();
            //aci.Select("News", "text=旱情&FieldText=SUBSTRING%7B旱情%7D:MYKEYWORD", "\\autn:id");
            aci.Select("News", "Querytext=旱情&FieldText=SUBSTRING{旱情}MYKEYWORD", @"\\autn:id");
        }
    }
}
