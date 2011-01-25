<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DetailProduct.ascx.cs"
    Inherits="ECommerce2010.UserControl.Right.DetailProduct" %>
<div class="box" style="width: 700px; padding: 10px 0 10px 0; height: auto">
     <div style="float: left; margin-left: 10px;">
        <img class="small" src=" <%= products.Image %>" />
        <p>
            <asp:Label ID="lblPhoto" runat="server"></asp:Label>: 1</p>
    </div>
    <div class="productDetail" style="width: 500px; height: auto; float: left; margin-left: 30px;
        text-align: left; line-height: 21px; margin-right: 0px;">
        <asp:Label ID="lblName" runat="server"></asp:Label>:
        <%= GetObjectByLanguage(products.Name)%>
        <h4 style="display: inline;">
        </h4>
        <br />
        <asp:Label ID="lblPrice" runat="server"></asp:Label>: <span class="price">
            <%= products.Price%></span><br />
        <asp:Label ID="lblDescription" runat="server"></asp:Label>:
        <br />
        <div class="expandField">
            <div class="productDescription" style="float: left; font-size: 11px; overflow: hidden;">
                <p>
                    <%=GetObjectByLanguage(products.Description)%></p>
            </div>
        </div>
        <div style="clear: both">
        </div>
        <asp:Button ID="Button1" runat="server" Text="Add your cart" CssClass="btn blue"  
            onclick="Button1_Click" />
        <div class="clearall" style="clear: both">
        </div>
    </div>
</div>
