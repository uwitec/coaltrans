using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHSample.Domain;
using NHSample.Domain.Entities;
using NHibernate;

namespace NHTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            GongdanMailInfo mailinfo = GongdanMailInfo.finder.FindById(63);
            Console.Write(mailinfo.Gongdan_id.ToString());

            //using (ISession session = Session.Open())
            //{
            //    var mail = new GongdanMailInfo();
            //    mail.Gongdan_id = 88888;
            //    mail.Creation_date = DateTime.Now;
            //    mail.Send_date = DateTime.Now;
            //    session.Save(mail);
            //}
        }
    }
}
