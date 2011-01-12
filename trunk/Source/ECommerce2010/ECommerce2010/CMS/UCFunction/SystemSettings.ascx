<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SystemSettings.ascx.cs"
    Inherits="ECommerce2010.CMS.UCFunction.SystemSettings" %>
<div id="right">
    <div class="box">
        <div class="title">
            <h5>
                Management Settings</h5>
            <div class="search">
                <div class="input">
                    <input type="text" id="search" name="search" />
                </div>
                <div class="button">
                    <input type="submit" name="submit" value="Search" />
                </div>
            </div>
        </div>
        <!-- end box / title -->
        <div class="table">
            <table>
                <thead>
                    <tr>
                        <th class="left">
                            Name
                        </th>
                        <th>
                            Value
                        </th>
                        <th style="width: 70px;">
                            Edit
                        </th>
                        <th class="selected last">
                            <input type="checkbox" class="checkall" />
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td class="name">
                            Item on a Page
                        </td>
                        <td class="value">
                            <%=itemUser %>
                        </td>
                        <td align="center" class="edit">
                            <a href="Default.aspx?do=setting&type=ItemperPageUser">
                                <img src="../Images/edit.jpg" height="12px" alt="Chỉnh sửa" /></a>
                        </td>
                        <td class="selected last">
                            <input type="checkbox" />
                        </td>
                    </tr>
                    <tr>
                        <td class="name">
                            Item on a Administrator page
                        </td>
                        <td class="value">
                            <%=itemAdmin %>
                        </td>
                        <td align="center" class="edit">
                            <a href="Default.aspx?do=setting&type=ItemperPageAdmin">
                                <img src="../Images/edit.jpg" height="12px" alt="Chỉnh sửa" /></a>
                        </td>
                        <td class="selected last">
                            <input type="checkbox" />
                        </td>
                    </tr>
                    <tr>
                        <td class="name">
                            Root Address User
                        </td>
                        <td class="value">
                            <%=rootURL%>
                        </td>
                        <td align="center" class="edit">
                            <a href="Default.aspx?do=setting&type=RootURL">
                                <img src="../Images/edit.jpg" height="12px" alt="Chỉnh sửa" /></a>
                        </td>
                        <td class="selected last">
                            <input type="checkbox" />
                        </td>
                    </tr>
                    <tr>
                        <td class="name">
                            Root Address Admin
                        </td>
                        <td class="value">
                            <%=rootAdmin%>
                        </td>
                        <td align="center" class="edit">
                            <a href="Default.aspx?do=setting&type=AdminSiteURL">
                                <img src="../Images/edit.jpg" height="12px" alt="Chỉnh sửa" /></a>
                        </td>
                        <td class="selected last">
                            <input type="checkbox" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <div class="action">
                <select name="action">
                    <option value="" class="locked">Comming soon</option>
                    <option value="" class="unlocked">Comming soon</option>
                    <option value="" class="folder-open">Comming soon</option>
                </select>
                <div class="button">
                    <input type="submit" name="submit" value="Thực thi lựa chọn" />
                </div>
            </div>
            <!-- end table action -->
        </div>
        <!--Edit Value-->
    </div>
    <asp:UpdatePanel ID="upPanel" runat="server">
        <ContentTemplate>
                <asp:Panel ID="pnItemUser" runat="server" Visible="false">
                    <div class="box">
                        <div class="title">
                            <h5>
                                Edit Settings</h5>
                        </div>
                        <div class="form">
                            <div class="fields">
                                <div class="field">
                                    <div class="label">
                                        <label for="input-medium">
                                            Input Value:</label>
                                    </div>
                                    <div class="input">
                                        <asp:TextBox ID="txtPages" runat="server" CssClass="medium"></asp:TextBox>
                                        &nbsp;&nbsp;
                                        <asp:RequiredFieldValidator ID="rfvUrl" runat="server" ControlToValidate="txtPages"
                                            SetFocusOnError="True" ErrorMessage="*!" Font-Bold="True" ValidationGroup="UsersGroup"></asp:RequiredFieldValidator>
                                        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Value &gt;0!"
                                            ControlToValidate="txtPages" MaximumValue="10000" MinimumValue="0" Type="Integer"
                                            Display="Dynamic" ValidationGroup="UsersGroup"></asp:RangeValidator>
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
                                            $("#ctl00_Content_ctl00_txtPages").Value = "";
                                        })
                                    });
                                </script>

                            </div>
                        </div>
                    </div>
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
<!-- end table -->
