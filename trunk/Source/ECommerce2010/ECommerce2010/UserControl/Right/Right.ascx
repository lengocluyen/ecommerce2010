<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Right.ascx.cs" Inherits="ECommerce2010.UserControl.Right.Right" %>
<%@ Register TagPrefix="UCPager" Namespace="ECommerce2010.Core" Assembly="ECommerce2010.Core" %>
<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>--%>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <a href="Default.aspx?lang=<%=language%>&do=productdetail&value=<%#Eval("ProductID")%>">
                    <div class="Sp">
                        <h4 class="NameProduct">
                            <%# GetObjectByLanguage(Eval("Name"))%>
                        </h4>
                        <img border="0" src="<%# Eval("Image") %>" />
                        <p class="price">
                            Price:
                            <%# Eval("Price") %>
                        </p>
                    </div>
                </a>
            </ItemTemplate>
        </asp:Repeater>
        <div class="clear"></div>
        <div class="results">
            <UCPager:Pager ID="pager" runat="server" />
        </div>
   <%-- </ContentTemplate>
</asp:UpdatePanel>--%>
