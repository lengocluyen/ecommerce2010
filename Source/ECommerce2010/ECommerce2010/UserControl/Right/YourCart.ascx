<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="YourCart.ascx.cs" Inherits="ECommerce2010.UserControl.Right.YourCart" %>
<div id="divMess" runat="server"></div>
<div class="cart" style="margin-top: 10px; margin-bottom: 10px">
    <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
    <table cellpadding="1" cellspacing="0" border="1" class="tblCartinfo" style="border: solid 1px #ccc;
        width: 99%; border-collapse: collapse; width: 700px;">
        <tr>
            <th class="titleHeader" style="width: 25%">
                <asp:Label ID="lblImage" runat="server"></asp:Label>
            </th>
            <th class="titleHeader" style="width: 25%">
                <asp:Label ID="lblProductName" runat="server"></asp:Label>
            </th>
            <th class="titleHeader" style="width: 20%">
                <asp:Label ID="lblPrice" runat="server"></asp:Label>
            </th>
            <th class="titleHeader" style="width: 10%">
                <asp:Label ID="lblQualitity" runat="server"></asp:Label>
            </th>
            <th class="titleHeader" style="width: 15%">
                <asp:Label ID="lblUnitPrice" runat="server"></asp:Label>
            </th>
            <th class="titleHeader" style="width: 5%">
                <asp:Label ID="lblSelect" runat="server"></asp:Label>
            </th>
        </tr>
        <%--  <tr>
                            <td valign="top" colspan="7" align="center">
                                <label id="lblMesg" style="display: none; color: #ff0000;">
                                    Không có sản phẩm nào trong giỏ hàng của bạn</label>
                            </td>
                        </tr>--%>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr valign="middle">
                    <td valign="middle" class="title" style="width: auto;" align="center" style="width: 25%;padding:10px;">
                        <img src="<%# GetImage(Eval("Item"))%>">
                    </td>
                    <td valign="middle" class="title"  align="left"">
                        <a href="">
                            <%# GetObjectByLanguage(Eval("Item"))%></a>
                    </td>
                    <td valign="middle" class="title"  align="right" >
                        <span class="price">
                            <%# GetPrice(Eval("Item"))%></span>
                    </td>
                    <td valign="middle" class="title" align="right">
                        <asp:TextBox ID="txtQuantity" Width="20" Text='<%# Eval("Soluong")%>' runat="server"/>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtQuantity" ValidationGroup="YourCart" Display="Dynamic" MaximumValue="100" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                    </td>
                    <td valign="middle" class="title"  align="right">
                        <span class="price"><%# GetUnitPrice(Eval("Item"), Eval("Soluong"))%></span>
                    </td>
                    <td valign="middle" align="center" style="width: 5%">
                        <asp:CheckBox ID="chkChoice" runat="server" Checked =true />
                        <asp:HiddenField ID="dfID" runat="server" Value='<%#GetProductID(Eval("Item"))%>' />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td valign="top" colspan="7" align="right" class="title" style="padding:10px">
                <span class="price"><asp:Label ID="lblTotal" runat="server"></asp:Label>:&nbsp;&nbsp;<%=total %>$</span>
            </td>
        </tr>
        <tr>
            <td valign="middle" colspan="7" align="left" class="title" style="width: 97%;padding:10px">
                <div class="fl" align="left" style="float: left">
                    <asp:Button CssClass="button1" ID="btContinueShopping" runat="server" OnClick="btContinueShopping_Click" />
                    <asp:Button CssClass="button1" ID="btPayment" runat="server" OnClick="btPayment_Click" />
                    <asp:Button CssClass="button1" ID="btUpdate" runat="server" OnClick="btUpdate_Click" ValidationGroup="YourCart" />
                </div>
                <div class="fr" style="float: right">
                    <asp:Button CssClass="button1" ID="btDelete" runat="server" OnClick="btDelete_Click" />
                    <asp:Button CssClass="button1" ID="btDeleteAll" runat="server" OnClick="btDeleteAll_Click" />
                </div>
            </td>
        </tr>
    </table>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</div>
