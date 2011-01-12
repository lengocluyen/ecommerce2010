<%@ Page Language="C#" MasterPageFile="~/CMS/Admin.Master" AutoEventWireup="true"
    CodeBehind="CMSRoles.aspx.cs" Inherits="ECommerce2010.CMS.CMSRoles" %>

<%@ Register TagPrefix="UCPager" Namespace="ECommerce2010.Core" Assembly="ECommerce2010.Core" %>
<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="icontent" ContentPlaceHolderID="Content" runat="server">
    <div id="right" style="min-height: 550px;">
        <!-- table -->
        <div class="box">
            <!-- box / title -->
            <div class="title">
                <h5>
                   List Roles User</h5>
                <div class="search">
                    <div class="input">
                        <input type="text" id="search" name="search" />
                    </div>
                    <div class="button">
                        <input type="submit"  value="Search" />
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
                            <th style="width: 70px;">
                                Edit
                            </th>
                            <th style="width: 50px;">
                                Delete
                            </th>
                            <th class="selected last">
                                <input type="checkbox" class="checkall" />
                            </th>
                        </tr>
                    </thead>
                    <asp:Repeater ID="rptRoles" runat="server" 
                        onitemdatabound="rptRoles_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <td class="name">
                                    <%#DataBinder.Eval(Container.DataItem, "Name")%>
                                </td>
                                <td align="center" class="edit">
                                    <a href="CMSRoles.aspx?do=edit&aid=<%#DataBinder.Eval(Container.DataItem,"RoleID")%>">
                                        <img src="../Images/edit.jpg" height="12px" alt="Chỉnh sửa" /></a>
                                </td>
                                <td align="center" class="delete">
                                    <a href="CMSRoles.aspx?do=del&aid=<%#DataBinder.Eval(Container.DataItem,"RoleID")%>">
                                        <img src="../Images/delete.jpg" height="15px" alt="Xóa" /></a>
                                </td>
                                <td class="selected last">
                                    <asp:CheckBox ID="idCheck" runat="server" AutoPostBack="true" />
                                    <asp:HiddenField ID="idHiddenField" value=<%#DataBinder.Eval(Container.DataItem,"RoleID")%>  runat="server" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <!-- pagination -->
                <div class="pagination pagination-left">
                    <div class="results">
                        <UCPager:Pager ID="pager" runat="server" />
                    </div>
                    <!-- table action -->
                    <div class="action" style="margin-top:0px;">
                        <select name="action" id="ddlAction" runat="server">
                            <option value="" class="locked">Xóa tất cả</option>
                            <option value="" class="unlocked">....</option>
                            <option value="" class="folder-open">...</option>
                        </select>
                        <div class="button">
                            <asp:Button ID="btApply" runat="server" Text="Thực thi lựa chọn" OnClick="btApply_Click" />
                        </div>
                    </div>
                    <!-- end table action -->
                </div>
                <!-- end pagination -->
            </div>
        </div>
        <!-- end table -->
        <asp:PlaceHolder ID="phAddEditRole" runat="server" />
    </div>
</asp:Content>
