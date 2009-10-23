using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace NHSample.Domain.Entities
{
    public class GongdanMailInfo
    {
        public virtual int Id { get; set; }
        public virtual int Gongdan_id { get; set; }
        public virtual string Msg_sender { get; set; }
        public virtual string Msg_to { get; set; }
        public virtual string Msg_title { get; set; }
        public virtual string Msg_body { get; set; }
        public virtual int Status { get; set; }
        public virtual DateTime Creation_date { get; set; }
        public virtual DateTime Send_date { get; set; }

        public static Finder<GongdanMailInfo> finder = new Finder<GongdanMailInfo>();
    }
}
