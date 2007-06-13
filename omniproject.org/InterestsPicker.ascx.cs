using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
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

        // don't overwrite when sending new data
        if (interestsTreeView.Nodes.Count != 0) return; 

        WebService service = Common.GetWebService();

        Interest[] userInterests = new Interest[0];
        if (Common.GetCurrentUser() != null)
        {
            userInterests = service.UserInterestList(Common.GetCurrentUser().id);
        }
        
        Interest[] categories = service.InterestLangList(0, preferredLanguageId);
        foreach (Interest category in categories)
        {
            TreeNode categoryNode = new TreeNode(category.name, category.id.ToString());
            categoryNode.ShowCheckBox = true;
            foreach (Interest userInterest in userInterests)
            {
                if (userInterest.id == category.id)
                {
                    categoryNode.Checked = true;
                    break;
                }
            }

            bool categoryCollapse = true;
            Interest[] interests = 
                    service.InterestLangList(category.id, preferredLanguageId);
            foreach (Interest interest in interests)
            {
                TreeNode interestNode = new TreeNode(interest.name, interest.id.ToString());
                interestNode.ShowCheckBox = true;
                
                foreach (Interest userInterest in userInterests)
                {
                    if (userInterest.id == interest.id)
                    {
                        interestNode.Checked = true;
                        categoryCollapse = false;
                        break;
                    }
                }
                interestNode.SelectAction = TreeNodeSelectAction.None;
                categoryNode.ChildNodes.Add(interestNode);
            }

            if (categoryCollapse)
            {
                categoryNode.Collapse();
            }
            categoryNode.SelectAction = TreeNodeSelectAction.None;
            interestsTreeView.Nodes.Add(categoryNode);
        }
    }

    public int[] GetSelectedInterests()
    {
        List<int> selectedInterests = new List<int>();

        List<TreeNode> nodeQueue = new List<TreeNode>();
        foreach (TreeNode node in interestsTreeView.Nodes)
        {
            nodeQueue.Add(node);
        }
        while (nodeQueue.Count != 0)
        {
            TreeNode currentNode = nodeQueue[0];
            nodeQueue.RemoveAt(0);
            foreach (TreeNode node in currentNode.ChildNodes)
            {
                nodeQueue.Add(node);
            }
            if (currentNode.Checked)
            {
                selectedInterests.Add(Convert.ToInt32(currentNode.Value));
            }
        }

        return selectedInterests.ToArray();
    }

    public void SaveInterestsToUser(int userId)
    {
        int[] interestIds = GetSelectedInterests();
        Interest[] userInterests = Common.GetWebService().UserInterestList(userId);
        List<int> userInterestIds = new List<int>();
        foreach (Interest userInterest in userInterests)
        {
            userInterestIds.Add(userInterest.id);
        }

        foreach (int interestId in interestIds)
        {
            if (userInterestIds.Contains(interestId)) // unchanged
            {
                userInterestIds.Remove(interestId);
                continue;
            }
            // else we have to add it
            Common.GetWebService().UserInterestAddById(userId, interestId);
        }
        foreach (int interestId in userInterestIds)
        {
            Common.GetWebService().UserInterestDeleteById(userId, interestId);
        }

        interestsTreeView.Nodes.Clear(); // reload it
    }
}
