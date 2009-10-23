using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;

namespace NHSample.Domain
{
    public class Session
    {
        private static ISessionFactory _sessionFactory = (new Configuration()).Configure().BuildSessionFactory();

        public static ISession Open()
        {
            return _sessionFactory.OpenSession();
        }
    }
}
