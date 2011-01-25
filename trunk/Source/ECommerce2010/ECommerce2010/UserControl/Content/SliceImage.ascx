<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SliceImage.ascx.cs"
    Inherits="ECommerce2010.UserControl.Content.SliceImage" %>
<div class="block_inside2">
    <div class="sliceimg">
        <div class="gallery gallery2">
            <div class="holder">
                <ul>
                <asp:Repeater ID="rptImage" runat="server">
                <ItemTemplate>
                <li><a href="Default.aspx?lang=<%=language%>&do=productdetail&value=<%#Eval("ProductID")%>"><img src="<%#Eval("Image") %>" alt="<%#GetObjectByLanguage(Eval("Name")) %>" /></a></li>
                </ItemTemplate>
                </asp:Repeater>
                    </ul>
            </div>
        </div>
    </div>
</div>
