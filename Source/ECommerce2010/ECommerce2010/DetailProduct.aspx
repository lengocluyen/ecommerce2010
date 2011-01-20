<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ECommerce2010.DetailProduct" %>
<%@ Register src="UserControl/Right/DetailProduct.ascx" tagname="DetailProduct" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    Detail Product
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <uc1:DetailProduct ID="DetailProduct1" runat="server" />
</asp:Content>
