<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InfoCart.ascx.cs" Inherits="ECommerce2010.UserControl.Left.InfoCart" %>
<div class="mini_portfolio_item">
    <div class="headitems">
        <div class="ribbon">
            <span id="tLeftTitle1" runat="server"></span>
        </div>
    </div>
    <div class="miditems">
        <div style="width: 10px; height: auto; float: left; padding-top: 8px; padding-left: 5px;">
            <img src="../../Image/icon1.gif" alt="" /></div>
        <div style="padding-left: 5px;float:left">
          <asp:Label ID="lblTotalProduct" runat="server" />:&nbsp;&nbsp;<%=countProduct %>
        </div>
        <div class="clear">
        </div>
        <div style="width: 10px; float: left; padding-top: 8px; padding-left: 5px;">
            <img src="../../Image/icon1.gif" alt="" /></div>
        <div style="padding-left: 5px;float:left">
            <asp:Label ID="lblTotal" runat="server" />:&nbsp;&nbsp;<%=total %>$
        </div>
        <div class="clear">
        </div>
        <div class="active">
            <a id="adetailCart" class="active" runat="server"><asp:Label ID="lbldetailCart" runat="server" /> </a>
        </div>
    </div>
    <div class="footitems">
    </div>
</div>
