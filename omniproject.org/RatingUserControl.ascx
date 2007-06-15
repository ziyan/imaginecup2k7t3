<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RatingUserControl.ascx.cs" Inherits="RatingUserControl" %>
<%@ Register Assembly="Spaanjaars.Toolkit" Namespace="Spaanjaars.Toolkit" TagPrefix="isp" %>
<isp:ContentRating ID="contentRating" runat="server" OnRated="contentRating_Rated"
    OnRating="contentRating_Rating" Visible="true" LegendText="" />
