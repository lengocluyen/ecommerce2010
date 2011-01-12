<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageManager.aspx.cs" Inherits="ECommerce2010.CMS.ImageManager" %>
<%@ Register Src="~/CMS/UCFunction/ImageManager.ascx" TagName="ImagesManager" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Công viên Internet</title>
    
</head>
<body background="../Images/alt.jpg">
    <form id="form1" runat="server">
        <div>
            <center>
                <uc1:ImagesManager ID="ImagesManager1" runat="server"></uc1:ImagesManager>
            </center>
        </div>
    </form>
</body>
</html>
