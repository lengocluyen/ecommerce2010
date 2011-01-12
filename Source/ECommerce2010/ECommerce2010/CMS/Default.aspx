<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CMS/Admin.Master" CodeBehind="Default.aspx.cs" Inherits="ECommerce2010.CMS.Default" %>
<%@ Register Src="~/CMS/UserControl/ContentDemo.ascx" TagName="ContentDemo" TagPrefix="UC" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="icontent" ContentPlaceHolderID="Content" runat="server">
<asp:PlaceHolder ID="phContent" runat="server"></asp:PlaceHolder>
</asp:Content>