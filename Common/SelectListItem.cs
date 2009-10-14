using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class SelectListItem
    {
        //根据值确定选择项
        public static void SelectDropDownListItemByText(System.Web.UI.WebControls.DropDownList ddlist, string selecttext)
        {

            foreach (System.Web.UI.WebControls.ListItem item in ddlist.Items)
            {
                if (item.Text == selecttext)
                {
                    item.Selected = true;
                }
                else
                {
                    item.Selected = false;
                }
            }
        }
        public static void SelectDropDownListItemByValue(System.Web.UI.WebControls.DropDownList ddlist, string selectvalue)
        {

            foreach (System.Web.UI.WebControls.ListItem item in ddlist.Items)
            {
                if (item.Value == selectvalue)
                {
                    item.Selected = true;
                }
                else
                {
                    item.Selected = false;
                }
            }
        }
    }
}
