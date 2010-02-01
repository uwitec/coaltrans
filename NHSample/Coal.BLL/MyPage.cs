using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Coal.Util;
using Coal.DAL;

namespace Coal.BLL
{
    public  class MyPage : System.Web.UI.Page
    {
        /// <summary>
        /// 函数构造
        /// </summary>
        public MyPage()
        { 
            
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(PageBase_Load);

        }
        private void PageBase_Load(object sender, EventArgs e)
        {
            MessageBox.Show("dsadas");
        }
    }
}
