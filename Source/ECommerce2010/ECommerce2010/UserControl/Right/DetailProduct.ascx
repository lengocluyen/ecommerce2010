<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DetailProduct.ascx.cs"
    Inherits="ECommerce2010.UserControl.Right.DetailProduct" %>
<%@ Import Namespace="ECommerce2010.Core" %>
<%--<div style="text-align: left">
    <div style="float: left">
        <img class="imgsp" src="../../Image/img/1.JPG" />
    </div>
    <div style="float: left; padding-left:20px">
        <h4>
         Fujifilm FinePix HS10</h4>
        <p style="color: red">
            Price: 259.01$
        </p>
        <p> jdjdjd ddjdjdj djdjd </p>
         <div>
             <a class="button">Add to cart</a></div>
         </div>
    </div>--%>
<div class="box" style="width: 700px; padding: 10px 0 10px 0; height: auto">
    <% Product i = LoadDefault(); %>
    <div style="float: left; margin-left: 10px;">
        <img class="small" src=" <%= i.Image %>" />
        <p>
            Photos: 1</p>
    </div>
    <div class="productDetail" style="width: 500px; height: auto; float: left; margin-left: 30px;
        text-align: left; line-height: 21px; margin-right: 0px;">
        Name:
        <%= i.Name%>
        <h4 style="display: inline;">
        </h4>
        <br />
        Price: <span class="price">
            <%= i.Price%></span><br />
        Description:
        <br />
        <div class="expandField">
            <div class="productDescription" style="float: left; font-size: 11px; overflow: hidden;">
                <p>
                    <%=  i.Description%></p>
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
