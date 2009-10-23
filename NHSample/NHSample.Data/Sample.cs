using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHSample.Domain.Entities;

namespace NHSample.Data
{
    public class Sample
    {
        protected ISession Session { get; set; }
        public Sample(ISession session)
        {
            Session = session;
        }

        public void CreateMail(GongdanMailInfo mail)
        {
            Session.Save(mail);
            Session.Flush();
        }
        public GongdanMailInfo GetGongdanMailInfoById(int mailId)
        {
            return Session.Get<GongdanMailInfo>(mailId);
        }
    }
}
