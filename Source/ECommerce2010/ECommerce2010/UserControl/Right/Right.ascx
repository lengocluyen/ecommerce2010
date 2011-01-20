<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Right.ascx.cs" Inherits="ECommerce2010.UserControl.Right.Right" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <a href="../../DetailProduct.aspx?act=detailprodct&id=<%#Eval("ProductID")%>">
                    <div class="Sp">
                        <h4 class="NameProduct">
                            <%# Eval("Name") %>
                        </h4>
                        <img src="<%# Eval("Image") %>" />
                        <p class="price">
                            Price:
                            <%# Eval("Price") %>
                        </p>
                    </div>
                </a>
            </ItemTemplate>
        </asp:Repeater>
    </ContentTemplate>
</asp:UpdatePanel>
