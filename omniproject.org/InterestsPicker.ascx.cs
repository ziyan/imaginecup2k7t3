using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class InterestsPicker : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // FIXME: get data from database
        if ((allListBox.Items.Count == 0) && (mineListBox.Items.Count == 0))
        {
            allListBox.Items.Add("Interest1");
            allListBox.Items.Add("Interest2");
            allListBox.Items.Add("Interest3");
            mineListBox.Items.Add("InterestA");
            mineListBox.Items.Add("InterestB");
        }
    }

    protected void Add_Click(object sender, EventArgs e)
    {
        if (allListBox.SelectedIndex == -1) return;

        ListItem selectedItem = allListBox.Items[allListBox.SelectedIndex];
        selectedItem.Selected = false;
        mineListBox.Items.Add(selectedItem);
        allListBox.Items.Remove(selectedItem);
    }

    protected void Remove_Click(object sender, EventArgs e)
    {
        if (mineListBox.SelectedIndex == -1) return;

        ListItem selectedItem = mineListBox.Items[mineListBox.SelectedIndex];
        selectedItem.Selected = false;
        allListBox.Items.Add(selectedItem);
        mineListBox.Items.Remove(selectedItem);
    }
}
