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

using Omni.Web;
using Omni.Web.org.omniproject;

public partial class InterestsPicker : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int preferredLanguageId = Common.GetPreferredLanguage();
        if (preferredLanguageId <= 0) return; // should not happen

        WebService service = Common.GetWebService();

        // UserGetUserInterest
        //Common.GetCurrentUser().id

        Interest[] categories = service.InterestList(0);
        foreach (Interest category in categories)
        {
            string categoryString = 
                    service.InterestNameQueryById(category.id, preferredLanguageId);
            TreeNode categoryNode = new TreeNode(categoryString);
            categoryNode.ShowCheckBox = true;

            Interest[] interests = service.InterestList(category.id);
            foreach (Interest interest in interests)
            {
                string interestString = service.InterestNameQueryById(interest.id, 
                        preferredLanguageId);

                TreeNode interestNode = new TreeNode(interestString);
                interestNode.ShowCheckBox = true;
                categoryNode.ChildNodes.Add(interestNode);
            }

            categoryNode.Collapse();
            allTreeView.Nodes.Add(categoryNode);
        }
    }
}
