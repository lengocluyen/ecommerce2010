<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ECommerce2010.DetailYourCart" %>

<%@ Register src="UserControl/YourCart.ascx" tagname="YourCart" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    Detail Product
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    
    <uc1:YourCart ID="YourCart1" runat="server" />
    
</asp:Content>
