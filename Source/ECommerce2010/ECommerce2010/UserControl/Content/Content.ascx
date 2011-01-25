<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Content.ascx.cs" Inherits="ECommerce2010.UserControl.Content.Content" %>
<%@ Register Src="../Left/Left.ascx" TagName="Left" TagPrefix="uc1" %>
<%@ Register Src="../Right/Right.ascx" TagName="Right" TagPrefix="uc2" %>
<%@ Register Src="../Right/DetailProduct.ascx" TagName="DetailProduct" TagPrefix="uc3" %>
<%--<%@ Register Src="../YourCart.ascx" TagName="YourCart" TagPrefix="uc4" %>--%>
<div class="content_area" class="block">
    <div class="headcontent">
        <div class="title">
            <span id="ttitleContent" runat="server"></span>
        </div>
    </div>
    <!-- Nội dung sản phẩm -->
    <div class="block_inside">
        <asp:PlaceHolder ID="phContent" runat="server" />
        <%--<uc2:Right ID="Right1" runat="server" />
        <%--<uc3:DetailProduct ID="DetailProduct1" runat="server" />--%>
        <%--<uc4:YourCart ID="YourCart1" runat="server" />--%>
    </div>
    <div class="footcontent">
    </div>
</div>
