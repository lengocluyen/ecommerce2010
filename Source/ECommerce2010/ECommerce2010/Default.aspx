<%@ Page Language="C#" Culture="en-US" UICulture="en-US" MasterPageFile="~/MasterPage.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ECommerce2010.Default" %>

<%@ Register Src="~/UserControl/Content/Content.ascx" TagName="Content" TagPrefix="HK" %>
<asp:Content ContentPlaceHolderID="phContent" ID="contetn" runat="server">
    <HK:Content ID="idContent" runat="server"/>
    <HK:Content ID="idContentExtra" runat="server" Visible =false/>
</asp:Content>
