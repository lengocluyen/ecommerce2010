<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddEditCategory.ascx.cs" Inherits="ECommerce2010.CMS.UCFunction.AddEditCategory" %>
<!-- forms -->
<div class="box">
    <!-- box / title -->
    <div class="title">
        <h5>
            Thêm danh mục sách</h5>
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
                        <span>Danh mục sách này đã có trong hệ thống!</span>
                    </div>
                    <div class="dismiss">
                        <a href="#message-notice"></a>
                    </div>
                </div>
            </div>
            
            <div class="field">
                <div class="label">
                    <label for="input-medium">
                        Tên Category:</label>
                </div>
                <div class="input">
                    <asp:TextBox ID="txtName" runat="server" CssClass="medium"></asp:TextBox>&nbsp;&nbsp;
                    <span style="padding-top: 20px;">
                        <asp:RequiredFieldValidator CssClass="require" ID="rfvName" runat="server" ControlToValidate="txtName"
                            Display="Dynamic" ErrorMessage="Chưa nhập!" Font-Bold="True" SetFocusOnError="True"
                            ValidationGroup="UsersGroup"></asp:RequiredFieldValidator>
                        </span>
                </div>
            </div>
            <div class="field">
                <div class="label">
                    <label for="input-medium">
                        Số thứ tự:</label>
                </div>
                <div class="input">
                    <asp:DropDownList ID="ddlOrderNo" runat="server" />
                </div>
            </div>
            <div class="field">
                <div class="label">
                    <label for="select">
                        Thể loại:</label>
                </div>
                <div class="select">
                    <asp:DropDownList ID="ddlParent" runat="server">
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
                        $("#ctl00_Content_ctl00_txtName").Value = "";
                        $("#ctl00_Content_ctl00_cbActive").Checked = false;
                    })
                });
            </script>

        </div>
    </div>
</div>
<!-- end forms -->