<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddEditRole.ascx.cs" Inherits="ECommerce2010.CMS.UCFunction.AddEditRole" %>
<!-- forms -->
<div class="box">
    <!-- box / title -->
    <div class="title">
        <h5>
            Thêm Quyền</h5>
    </div>
    <!-- end box / title -->
    <div class="form">
        <div class="fields">
            <div class="field">
                <div class="label">
                    <label for="input-medium">
                        Tên quyền:</label>
                </div>
                <div class="input">
                    <asp:TextBox ID="txtName" runat="server" CssClass="medium"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="require" ID="rfvName" runat="server" ControlToValidate="txtName"
                        Display="Dynamic" Font-Bold="True" SetFocusOnError="True" ValidationGroup="UsersGroup"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="buttons">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="UsersGroup" />
                <input type="reset" id="ireset" name="reset" value="Reset" />
            </div>
            <script type="text/javascript">
                $(document).ready(function() {
                    $("#ireset").Click(function() {
                        $("#ctl00_Content_ctl00_txtName").Value = "";
                    })
                });
            </script>
        </div>
    </div>
</div>
<!-- end forms -->
