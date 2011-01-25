<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="ECommerce2010.UserControl.Left.Login" %>
<div class="mini_portfolio_item">
    <div class="headitems">
        <div class="ribbon">
            <span id="tLeftTitle2" runat="server"></span>
        </div>
    </div>
    <div class="miditems">
        <asp:Panel ID="pnLogin" runat="server">
            <div runat="server" id="MsgClient">
            </div>
            <div>
                <div class="loginField">
                    <asp:Label ID="lbEmail" runat="server"></asp:Label>:
                </div>
                <asp:TextBox ID="txtEmail" runat="server" Width="188px"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtEmail" ErrorMessage="*" ValidationGroup="Login"
                    Display="Dynamic" />
            </div>
            <div>
                <div class="loginField">
                    <asp:Label ID="lbPassword" runat="server"></asp:Label>:
                </div>
                <asp:TextBox ID="txtPassword" runat="server" Width="188px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtPassword" ErrorMessage="*" ValidationGroup="Login"
                    Display="Dynamic" />
            </div>
            <div style="height: 5px;">
            </div>
            <div style="text-align: center;">
                <asp:Button CssClass="button1" ValidationGroup="Login" ID="btlogin" runat="server"
                    OnClick="btlogin_Click" />
            </div>
        </asp:Panel>
        <asp:Panel ID="pnInfoUser" runat="server" Visible=false>
            <div>
                <div class="loginField">
                   <asp:Label ID="lWelcome" runat="server"></asp:Label>:
                </div>
                 <b><asp:Label ID="lblEmail" runat="server"></asp:Label></b>
            </div>
            <div>
                <div class="loginField">
                    <asp:Label ID="lTime" runat="server"></asp:Label>:
                </div>
                <b> <asp:Label ID="lblTime" runat="server"></asp:Label></b>
            </div>
            <div style="height: 5px;">
            </div>
            <div style="text-align: center;">
                <asp:Button ID="btLogout" CssClass="button1" runat="server" OnClick="btLogout_Click" />
            </div>
        </asp:Panel>
    </div>
    <div class="footitems">
    </div>
</div>
