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
    <div style="float: left; margin-left: 10px;">
        <img class="small" src=" <%# LoadDefault().Image %>" />
        <p>
            Photos: 1</p>
    </div>
    <div class="productDetail" style="width: 500px; height: auto; float: left; margin-left: 30px;
        text-align: left; line-height: 21px; margin-right: 0px;">
        Name: <%# LoadDefault().Name %>
        <h4 style="display: inline;">
            </h4>
        <br />
        Price: <span class="price"> <%# LoadDefault().Price %></span><br />
        Description:  
        <br />
        <div class="expandField">
            <div class="productDescription" style="float: left; font-size: 11px; overflow: hidden;">
                <p><%# LoadDefault().Description %></p>
            </div>
        </div>
        <a href="#" class="button">+ Add to card</a><br />
        <div class="clearall" style="clear: both">
      
        </div>
        <span class="staron"></span><span class="staron"></span><span class="staron"></span>
        <span class="staroff"></span><span class="staroff"></span><a href="#" style="font-size: 11px;">
            (21 opinions)</a>
    </div>
</div>
