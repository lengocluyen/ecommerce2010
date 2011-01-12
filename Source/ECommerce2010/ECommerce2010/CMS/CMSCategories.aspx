<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CMS/Admin.Master"
    CodeBehind="CMSCategories.aspx.cs" Inherits="ECommerce2010.CMS.CMSCategories" %>

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
                    List Category</h5>
                <div class="search">
                    <div class="input">
                        <input type="text" id="search" name="search" />
                    </div>
                    <div class="button">
                        <input type="submit" value="Search" />
                    </div>
                </div>
            </div>
            <!-- end box / title -->
            <div class="table">
                <table>
                    <thead>
                        <tr>
                            <th class="left">
                                OrderNo
                            </th>
                            <th>
                                Name
                            </th>
                            <th>
                                Parent
                            </th>
                            <th style="width: 80px;">
                                Active
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
                    <asp:Repeater ID="rptCategories" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="orderNo">
                                    <%#DataBinder.Eval(Container.DataItem, "OrderNo")%>
                                </td>
                                <td class="email">
                                    <%#DataBinder.Eval(Container.DataItem, "Name")%>
                                </td>
                                <td class="parent">
                                    <%# this.GetCategoryByID(DataBinder.Eval(Container.DataItem, "ParentID"))%>
                                </td>
                                <td align="center" class="enable">
                                    <asp:RadioButton ID="rdButton" runat="server" Checked='<%#DataBinder.Eval(Container.DataItem, "IsActive")%>' />
                                </td>
                                <td align="center" class="edit">
                                    <a href="CMSCategories.aspx?do=edit&aid=<%#DataBinder.Eval(Container.DataItem,"CategoryID")%>">
                                        <img src="../Images/edit.jpg" height="12px" alt="Chỉnh sửa" /></a>
                                </td>
                                <td align="center" class="delete">
                                    <a href="CMSCategories.aspx?do=del&aid=<%#DataBinder.Eval(Container.DataItem,"CategoryID")%>">
                                        <img src="../Images/delete.jpg" height="15px" alt="Xóa" /></a>
                                </td>
                                <td class="selected last">
                                    <asp:CheckBox ID="idCheck" runat="server" CssClass="delitem" />
                                    <asp:HiddenField ID="idHiddenField" Value='<%#DataBinder.Eval(Container.DataItem,"CategoryID")%>'
                                        runat="server" />
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
                    <div class="action" style="margin-top: 0px;">
                        <asp:DropDownList ID="ddlAct" runat="server">
                            <asp:ListItem>Xóa item đánh dấu</asp:ListItem>
                            <asp:ListItem>Kích hoạt item đánh dấu</asp:ListItem>
                            <asp:ListItem>Hủy kích hoạt item đánh dấu</asp:ListItem>
                        </asp:DropDownList>
                        <%-- <select name="action" id="ddlAction" runat="server">
                            <option value="" class="locked">Xóa item đánh dấu</option>
                            <option value="" class="unlocked">Kích hoạt item đánh dấu</option>
                            <option value="" class="folder-open">...</option>
                        </select>--%>
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
        <asp:PlaceHolder ID="phAddEditCategory" runat="server" />
    </div>
</asp:Content>
