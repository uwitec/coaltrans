using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace NHSample.Domain
{
    public class Finder<T> : IFinder<T>
    {
        public T FindById(int id)
        {
            using (ISession session = Session.Open())
            {
                return session.Get<T>(id);
            }
        }
    }

    public interface IFinder<T>
    {
        T FindById(int id);
    }
}
