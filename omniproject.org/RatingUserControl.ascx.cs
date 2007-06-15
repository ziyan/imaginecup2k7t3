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

public partial class RatingUserControl : System.Web.UI.UserControl
{
    private int ans_id = 0;
    private bool rated = false;
    public int Ans_Id
    {
        get { return ans_id; }
        set { ans_id = value; }
    }
    public bool Rated
    {
        get { return rated; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
            refresh();
    }
    private void refresh()
    {
        int[] data = new int[] { 0, 0, 0, 0, 0 };
        contentRating.DataSource = data;
        //get rating
        int rating = Omni.Web.Common.GetWebService().TransAnsRateGetById(Omni.Web.Common.GetCurrentUser() == null ? 0 : Omni.Web.Common.GetCurrentUser().id, ans_id);
        if (rating < 0)
        {
            contentRating.Enabled = false;
            rating = -rating;
            rated = false;
        }
        else
        {
            contentRating.Enabled = true;
            rated = true;
        }
        if (rating <= 0) rating = 1;
        if (rating > 5) rating = 5;
        data[rating-1] = 1;
        contentRating.DataSource = data;
        contentRating.ItemId = Guid.NewGuid();
        contentRating.DataBind();
        
    }
    protected void contentRating_Rating(object sender, Spaanjaars.Toolkit.RateEventArgs e)
    {
        if (rated||e.HasRated) e.Cancel = true;
    }
    protected void contentRating_Rated(object sender, Spaanjaars.Toolkit.RateEventArgs e)
    {
        rated = true;
        Omni.Web.Common.GetWebService().TransAnsRateById(Omni.Web.Common.GetCurrentUser() == null ? 0 : Omni.Web.Common.GetCurrentUser().id, ans_id, Convert.ToInt16(e.RateValue));
        refresh();
    }
}
