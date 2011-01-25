<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Register.ascx.cs" Inherits="ECommerce2010.UserControl.Right.Register" %>
<div class="register">
    <div runat="server" id="scriptEpoch">
    </div>
    <div runat="server" id="MsgClient">
    </div>
    <div class="titleTop">
        <asp:Label ID="lbRegister" runat="server" />
    </div>
    <br />
    <!-- Name -->
    <div class="infoField1">
        <span id="tFirstName" runat="server" class="bold"></span>:
    </div>
    <div class="infoField2">
        <asp:TextBox CssClass="txt" ID="txtName" runat="server" Height="18px" Width="180px"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="require" ID="rfvName" runat="server" ControlToValidate="txtName"
            Display="Dynamic" Font-Bold="True" SetFocusOnError="True" ValidationGroup="Register"></asp:RequiredFieldValidator></div>
    <!-- LastName -->
    <div class="infoField1">
        <span id="tLastName" runat="server" class="bold"></span>:
    </div>
    <div class="infoField2">
        <asp:TextBox CssClass="txt" ID="txtLastName" runat="server" Height="18px" Width="180px"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="require" ID="rfvLastName" runat="server" ControlToValidate="txtLastName"
            Display="Dynamic" Font-Bold="True" SetFocusOnError="True" ValidationGroup="Register"></asp:RequiredFieldValidator>
    </div>
    <!-- Email -->
    <div class="infoField1">
        <span id="tEmail" runat="server" class="bold"></span>:
    </div>
    <div class="infoField2">
        <asp:TextBox CssClass="txt" ID="txtEmail" runat="server" Width="180px" Height="18px"></asp:TextBox>
        <asp:RegularExpressionValidator CssClass="require" ID="RegularExpressionValidatorEmail"
            runat="server" ControlToValidate="txtEmail" Font-Bold="True" ValidationGroup="Register"
            ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?"
            Display="Dynamic"></asp:RegularExpressionValidator>
    </div>
    <!-- Password -->
    <div class="infoField1">
        <span id="tPassword" runat="server" class="bold"></span>:
    </div>
    <div class="infoField2">
        <asp:TextBox CssClass="txt" ID="txtPassword" runat="server" TextMode="Password" Height="18px"
            Width="180px"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="require" ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
            Display="Dynamic" Font-Bold="True" SetFocusOnError="True" ValidationGroup="Register"></asp:RequiredFieldValidator>
    </div>
    <!-- Comfirm Password -->
    <div class="infoField1">
        <span id="tRePassword" runat="server" class="bold"></span>:
    </div>
    <div class="infoField2">
        <asp:TextBox CssClass="txt" ID="txtRetypePassword" runat="server" TextMode="Password"
            Height="18px" Width="180px"></asp:TextBox>
        <asp:CompareValidator CssClass="require" ID="cpvPassword" runat="server" ControlToValidate="txtRetypePassword"
            Font-Bold="True" SetFocusOnError="True" ValidationGroup="Register" ControlToCompare="txtPassword"></asp:CompareValidator>
    </div>
    <!-- Sex -->
    <div class="infoField1">
        <span id="tSex" runat="server" class="bold"></span>:
    </div>
    <div class="infoField2">
        <asp:RadioButtonList ID="rblSex" runat="server">
            <asp:ListItem Selected="True">&nbsp;
            </asp:ListItem><asp:ListItem>&nbsp;
            </asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <!-- Birth day -->
    <div class="infoField1">
        <span id="tBirthDay" runat="server" class="bold"></span>:
    </div>
    <div class="infoField2">
        <asp:TextBox CssClass="txt" runat="server" ID="popup_container" Height="18px" />
        <asp:RegularExpressionValidator CssClass="require" ID="RegularExpressionValidatorDate"
            runat="server" ControlToValidate="popup_container" Font-Bold="True" ValidationGroup="Register"
            Display="Dynamic"></asp:RegularExpressionValidator>
    </div>
    <!-- address -->
    <div class="infoField1">
        <span id="tAddress" runat="server" class="bold"></span>:
    </div>
    <div class="infoField2">
        <asp:TextBox CssClass="txt" ID="txtAddress" runat="server" Width="269px" Height="18px"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="require" ID="rfvAddress" runat="server" ControlToValidate="txtAddress"
            Display="Dynamic" Font-Bold="True" SetFocusOnError="True" ValidationGroup="Register"></asp:RequiredFieldValidator>
    </div>
    <!-- phone number -->
    <div class="infoField1">
        <span id="tPhone" runat="server" class="bold"></span>:
    </div>
    <div class="infoField2">
        <asp:TextBox CssClass="txt" ID="txtPhone" runat="server" Height="18px" Width="180px" />
    </div>
    <div class="clear"></div>
     <!-- Country -->
    <div class="infoField1">
        <span id="tCountry" runat="server" class="bold"></span>:
    </div>
    <div class="infoField2">
        <asp:DropDownList ID="ddlCountries" runat="server"></asp:DropDownList>
    </div>
    <div class="clear"></div>
    <!-- captcha -->
    <div class="infoField1" style="padding-top: 18px">
        <span id="tIndentify" runat="server" class="bold"></span>:
    </div>
    <div class="infoField2">
        <div style="float: left; padding-top: 7px;">
            <img height="25" alt="" src="../../Captcha1.aspx" width="80"></div>
        <div style="float: left; padding-top: 7px;">
            &nbsp;&nbsp;<asp:TextBox CssClass="txt" ID="txtCaptcha" runat="server" Width="181px"
                Height="18px" Font-Size="Medium"></asp:TextBox>
            <asp:Label ID="lbCaptcha" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
        </div>
    </div>
    <!-- button -->
    <div style="float: left; width: 100%; padding-top: 15px; text-align: center">
        <asp:Button CssClass="button1" ID="btButton" runat="server" ValidationGroup="Register" OnClick="btButton_Click" />
    </div>
    <div style="width: 518px; height: 2px; clear: both;">
    </div>
</div>
