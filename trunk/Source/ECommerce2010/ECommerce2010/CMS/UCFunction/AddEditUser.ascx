<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddEditUser.ascx.cs"
    Inherits="ECommerce2010.CMS.UCFunction.AddEditUser" %>
<!-- forms -->
<div class="box">
    <!-- box / title -->
    <div class="title">
        <h5>
            Thêm người dùng</h5>
    </div>
    <!-- end box / title -->
    <div class="form">
        <div class="fields">
            <div runat="server" visible="false" id="idNotice">
                <div id="message-notice" class="message message-notice">
                    <div class="image">
                        <img src="../../resources/images/icons/notice.png" alt="Notice" height="32" />
                    </div>
                    <div class="text">
                        <h6>
                            Thông báo</h6>
                        <span>Email đã tồn tại trong hệ thống.</span>
                    </div>
                    <div class="dismiss">
                        <a href="#message-notice"></a>
                    </div>
                </div>
            </div>
            
            <div class="field">
                <div class="label">
                    <label for="input-medium">
                        Email:</label>
                </div>
                <div class="input">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="medium"></asp:TextBox>&nbsp;&nbsp;
                    <span style="padding-top: 20px;">
                        <asp:RequiredFieldValidator CssClass="require" ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                            Display="Dynamic" ErrorMessage="Chưa nhập!" Font-Bold="True" SetFocusOnError="True"
                            ValidationGroup="UsersGroup"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator CssClass="require" ID="RegularExpressionValidatorEmail"
                            runat="server" ControlToValidate="txtEmail" ErrorMessage="Định dạng email không đúng!"
                            Font-Bold="True" ValidationGroup="UsersGroup" ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?"
                            Display="Dynamic"></asp:RegularExpressionValidator></span>
                </div>
            </div>
            <div class="field">
                <div class="label">
                    <label for="input-medium">
                        Mật khẩu:</label>
                </div>
                <div class="input">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="medium"></asp:TextBox>&nbsp;&nbsp;
                    <span style="padding-top: 20px;">
                        <asp:RequiredFieldValidator CssClass="require" ID="rfgPassword" ErrorMessage="Chưa nhập!"
                            runat="server" ControlToValidate="txtEmail" Display="Dynamic" Font-Bold="True"
                            SetFocusOnError="True" ValidationGroup="UsersGroup"></asp:RequiredFieldValidator>
                    </span>
                </div>
            </div>
            <div class="field">
                <div class="label">
                    <label for="select">
                        Quyền Người dùng:</label>
                </div>
                <div class="select">
                    <asp:DropDownList ID="ddlRoles" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="field">
                <div class="label label-checkbox">
                    <label>
                        Hoạt động:</label>
                </div>
                <div class="checkboxes">
                    <div class="checkbox">
                        <asp:CheckBox ID="cbActive" runat="server" />
                    </div>
                </div>
            </div>
            <div class="buttons">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                    ValidationGroup="UsersGroup" />
                <input type="reset" id="ireset" name="reset" value="Reset" />
            </div>

            <script type="text/javascript">
                $(document).ready(function() {
                    $("#ireset").Click(function() {
                        $("#ctl00_Content_ctl00_txtEmail").Value = "";
                        $("#ctl00_Content_ctl00_txtPassword").Value = "";
                        $("#ctl00_Content_ctl00_cbActive").Checked = false;
                    })
                });
            </script>

        </div>
    </div>
</div>
<!-- end forms -->
