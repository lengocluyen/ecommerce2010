<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Content.ascx.cs" Inherits="ECommerce2010.UserControl.Content.Content" %>
<%@ Register Src="../Left/Left.ascx" TagName="Left" TagPrefix="uc1" %>
<%@ Register Src="../Right/Right.ascx" TagName="Right" TagPrefix="uc2" %>
<div class="content_area" class="block">
    <div class="headcontent">
        <div class="title">
            >> OTHER PRODUCTS &nbsp;</div>
    </div>
    <!-- Nội dung sản phẩm -->
    <div class="block_inside">
        <uc2:Right ID="Right1" runat="server" />
    </div>
    <div class="footcontent">
    </div>
</div>
