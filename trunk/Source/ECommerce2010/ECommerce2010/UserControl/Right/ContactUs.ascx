<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContactUs.ascx.cs" Inherits="ECommerce2010.UserControl.Right.ContactUs" %>
<div class="Contacts">
<div id="messError" runat="server"></div>
    <div class="titleTop">
        <asp:Label ID="lblTitle" runat="server"></asp:Label>
    </div>
    <!---Name--> 
    <div style="margin-top:10px;" class="infoField1 infoField11">
        <asp:Label ID="lblName" runat="server"></asp:Label>:</div>
    <div style="margin-top:10px;" class="infoField2 infoField22">
        <asp:TextBox ID="txtName" runat="server" Width="450px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="*" ControlToValidate="txtName"
            ValidationGroup="Contacts" Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
    <!---Address-->
    <div class="infoField1 infoField11">
        <asp:Label ID="lblAddress" runat="server"></asp:Label>:</div>
    <div class="infoField2 infoField22">
        <asp:TextBox ID="txtAddress" runat="server" Width="450px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="*" ControlToValidate="txtAddress"
            ValidationGroup="Contacts" Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
    <!---Phone-->
    <div class="infoField1 infoField11">
        <asp:Label ID="lblPhone" runat="server"></asp:Label>:</div>
    <div class="infoField2 infoField22">
        <asp:TextBox ID="txtPhone" runat="server" Width="450px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ErrorMessage="*" ControlToValidate="txtPhone"
            ValidationGroup="Contacts" Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
    <!---Email-->
    <div class="infoField1 infoField11">
        <asp:Label ID="lblEmail" runat="server"></asp:Label>:</div>
    <div class="infoField2 infoField22">
        <asp:TextBox ID="txtEmail" runat="server" Width="450px"></asp:TextBox>
        <asp:RegularExpressionValidator ID="rfvEmail" runat="server" ErrorMessage="*" ControlToValidate="txtEmail"
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Contacts"
            Display="Dynamic"></asp:RegularExpressionValidator>
    </div>
    <!---Content-->
    <div class="infoField1 infoField11">
        <asp:Label ID="lbleContent" runat="server"></asp:Label>:</div>
        <div class="clear"></div>
    <div class="infoField2 infoField22" style="padding-left:50px;text-align:center;">
        <asp:TextBox ID="txtContent" runat="server" runat="server" Width="600px" Height="300px"
            TextMode="MultiLine"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvContent" runat="server" ErrorMessage="*" ControlToValidate="txtContent"
            ValidationGroup="Contacts" Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
    <!---Submit-->
    <div style="float: left; width: 100%; padding-top: 15px; text-align: center">
        <asp:Button ID="btButtonHK" CssClass="button1" runat="server" OnClick="btButton_Click" OnClientClick="tinyMCE.triggerSave(false,true);"
            ValidationGroup="Contacts" />
    </div>

    <script type="text/javascript">
        tinyMCE.init({
            mode: "textareas",
            theme: "simple"
        });
    </script>

</div>
