<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Statistics.ascx.cs"
    Inherits="ECommerce2010.CMS.UCFunction.Statistics" %>
<div id="right">
    <div class="box box-left">
        <!-- box / title -->
        <div class="title">
            <h5>
                Statistics website</h5>
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
                            Information
                        </th>
                        <th class="last">
                            Value
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td class="title">
                            Access Total
                        </td>
                        <td class="last">
                            <%=Application["totalvisits"]%>
                        </td>
                    </tr>
                    <tr>
                        <td class="title">
                            User Online
                        </td>
                        <td class="last">
                            <%=Application["online"]%>
                        </td>
                    </tr>
                    <tr>
                        <td class="title">
                            Access on a day
                        </td>
                        <td class="last">
                            <%=Application["totalvisitsday"]%>
                        </td>
                    </tr>
                    <tr>
                        <td class="title">
                            Access on a Week
                        </td>
                        <td class="last">
                            <%=Application["totalvisitsweek"]%>
                        </td>
                    </tr>
                    <tr>
                        <td class="title">
                            Access on a Month
                        </td>
                        <td class="last">
                            <%=Application["totalvisitsmonth"]%>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <div class="box box-right">
        <!-- box / title -->
        <div class="title">
            <h5>
                Statistic Product</h5>
            <div class="search">
                <div class="input">
                    <input type="text" id="Text1" name="search" />
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
                            Infomation
                        </th>
                        <th class="last">
                            Value
                        </th>
                    </tr>
                </thead>
               
                <asp:Repeater ID="rpCategory" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td class="title">
                                <%# DataBinder.Eval(Container.DataItem,"Name") %>
                            </td>
                            <td class="last">
                                <%# this.GetCountBookByCategory(DataBinder.Eval(Container.DataItem,"CategoryID")) %>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </div>
    <div class="box box-left">
    <!-- box / title -->
    <div class="title">
        <h5>
        User Information
            </h5>
      <div class="search">
                    <div class="input">
                        <input type="text" id="Text2" name="search" />
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
                        Infomation
                    </th>
                    <th class="last">
                        Value
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td class="title">
                        Email
                    </td>
                    <td class="last">
                   <%-- <%=this._userSession.CurrentMember.Email %>--%>
                    </td>
                </tr>
                <tr>
                    <td class="title">
                        Role
                    </td>
                    <td class="last">
                    <%--<%=this._userSession.RoleCurrentUser.Name %>--%>
                    </td>
                </tr>
                <tr>
                    <td class="title">
                        Time Login
                    </td>
                    <td class="last">
                    <%--<%= this._userSession.TimeUserLogin.ToString("hh:ss - dd/MM/yyyy")%>--%>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</div>
<%--<div class="box box-right">
    <!-- box / title -->
    <div class="title">
        <h5>
        Thống kê thông tin kho sách
            </h5>
      <div class="search">
                    <div class="input">
                        <input type="text" id="Text3" name="search" />
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
                        Thông tin
                    </th>
                    <th class="last">
                        Thông số
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td class="title">
                        Tổng số sách trong hệ thống
                    </td>
                    <td class="last">
                    <%=totalBook %>
                    </td>
                </tr>
                <tr>
                    <td class="title">
                        Tổng số lượt tải sách
                    </td>
                    <td class="last">
                    <%=totalDownload %>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</div>--%>
</div>
