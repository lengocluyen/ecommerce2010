<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeftContent.ascx.cs"
    Inherits="ECommerce2010.CMS.UserControl.LeftContent" %>
<!-- end content / left -->
<div id="left">
    <div id="menu">
        <h6 id="h-menu-ebook" class='<%=ebook%>'>
            <a href="#ebook"><span>Product</span></a></h6>
        <ul id="menu-ebook" class='<%=actebook%>'>
            <li><a href="../CMS/CMSBooks.aspx">List Product</a></li>
            <li><a href="../CMS/CMSBooks.aspx?do=add">Add new Product</a></li>
        </ul>
        <h6 id="h-menu-category" class='<%=category %>'>
            <a href="#category"><span>Category</span></a></h6>
        <ul id="menu-category" class='<%=actcategroy %>'>
            <li><a href="../CMS/CMSCategories.aspx">List Category</a></li>
            <li><a href="../CMS/CMSCategories.aspx?do=add">Add new Category</a></li>
        </ul>
        <h6 id="h-menu-user" class='<%=user %>'>
            <a href="#user"><span>User</span></a></h6>
        <ul id="menu-user" class='<%=actuser %>'>
            <li><a href="../CMS/CMSUsers.aspx">List User</a></li>
            <li class="last"><a href="../CMS/CMSUsers.aspx?do=add">Add new User</a></li>
        </ul>
        <h6 id="h-menu-role" class='<%=roles %>'>
            <a href="#role"><span>Role</span></a></h6>
        <ul id="menu-role" class='<%=actroles %>'>
            <li><a href="../CMS/CMSRoles.aspx">List Role</a></li>
            <li class="last"><a href="../CMS/CMSRoles.aspx?do=add">Add new Role</a></li>
        </ul>
        <h6 id="h-menu-settings">
            <a href="#settings"><span>Settings</span></a></h6>
        <ul id="menu-settings" class='closed'>
            <li class="last"><a href="../CMS/Default.aspx?do=setting">Manage Settings</a></li>
        </ul>
    </div>
    <div id="date-picker">
    </div>
</div>
<!-- end content / left -->
