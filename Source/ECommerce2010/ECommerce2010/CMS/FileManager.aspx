<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileManager.aspx.cs" Inherits="ECommerce2010.CMS.FileManager" %>

<%@ Register Src="~/CMS/UCFunction/FileManager.ascx" TagName="FileManager" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Công viên Internet</title>
    <style type="text/css">
        /* -----------------------------------------------------------
	content -> right -> forms -> button
----------------------------------------------------------- */
        div.button
        {
            margin: 0;
            padding: 0 0 0 8px;
            float: left;
        }
        div.button input
        {
            margin: 0;
            color: #000000;
            font-family: Lucida Grande, Verdana, Lucida Sans Regular, Lucida Sans Unicode, Arial, sans-serif;
            font-size: 11px;
            font-weight: bold;
        }
        div.button .ui-state-default
        {
            margin: 0;
            padding: 6px 12px 6px 12px;
            background: #e5e3e3 url("../../resources/images/button.png") repeat-x;
            border-top: 1px solid #DDDDDD;
            border-left: 1px solid #c6c6c6;
            border-right: 1px solid #DDDDDD;
            border-bottom: 1px solid #c6c6c6;
            color: #515151;
            outline: none;
        }
        div.button .ui-state-hover
        {
            margin: 0;
            padding: 6px 12px 6px 12px;
            background: #b4b4b4 url("../../resources/images/button_selected.png") repeat-x;
            border-top: 1px solid #cccccc;
            border-left: 1px solid #bebebe;
            border-right: 1px solid #b1b1b1;
            border-bottom: 1px solid #afafaf;
            color: #515151;
            outline: none;
        }
        div.highlight
        {
            display: inline;
        }
        div.highlight .ui-state-default
        {
            margin: 0;
            padding: 6px 12px 6px 12px;
            background: #4e85bb url("../../resources/images/colors/blue/button_highlight.png") repeat-x;
            border-top: 1px solid #5c91a4;
            border-left: 1px solid #2a6f89;
            border-right: 1px solid #2b7089;
            border-bottom: 1px solid #1a6480;
            color: #FFFFFF;
        }
        div.highlight .ui-state-hover
        {
            margin: 0;
            padding: 6px 12px 6px 12px;
            background: #46a0c1 url("../../resources/images/colors/blue/button_highlight_selected.png") repeat-x;
            border-top: 1px solid #78acbf;
            border-left: 1px solid #34819e;
            border-right: 1px solid #35829f;
            border-bottom: 1px solid #257897;
            color: #FFFFFF;
        }
        /* -----------------------------------------------------------
	content -> right -> forms -> buttons
----------------------------------------------------------- */
        div.buttons
        {
            margin: 10px 0 0 200px;
            padding: 0;
        }
        div.buttons input
        {
            margin: 0;
            color: #000000;
            font-family: Lucida Grande, Verdana, Lucida Sans Regular, Lucida Sans Unicode, Arial, sans-serif;
            font-size: 11px;
            font-weight: bold;
        }
        /* -----------------------------------------------------------
	content -> right -> forms -> buttons (jquery styling)
----------------------------------------------------------- */
        div.buttons .ui-state-default
        {
            margin: 0;
            padding: 6px 12px 6px 12px;
            background: #e5e3e3 url("../../resources/images/button.png") repeat-x;
            border-top: 1px solid #DDDDDD;
            border-left: 1px solid #c6c6c6;
            border-right: 1px solid #DDDDDD;
            border-bottom: 1px solid #c6c6c6;
            color: #515151;
            outline: none;
        }
        div.buttons .ui-state-hover
        {
            margin: 0;
            padding: 6px 12px 6px 12px;
            background: #b4b4b4 url("../../resources/images/button_selected.png") repeat-x;
            border-top: 1px solid #cccccc;
            border-left: 1px solid #bebebe;
            border-right: 1px solid #b1b1b1;
            border-bottom: 1px solid #afafaf;
            color: #515151;
            outline: none;
        }
        div.buttons div.highlight
        {
            display: inline;
        }
        div.buttons div.highlight .ui-state-default
        {
            margin: 0;
            padding: 6px 12px 6px 12px;
            background: #4e85bb url("../../resources/images/colors/blue/button_highlight.png") repeat-x;
            border-top: 1px solid #5c91a4;
            border-left: 1px solid #2a6f89;
            border-right: 1px solid #2b7089;
            border-bottom: 1px solid #1a6480;
            color: #FFFFFF;
        }
        div.buttons div.highlight .ui-state-hover
        {
            margin: 0;
            padding: 6px 12px 6px 12px;
            background: #46a0c1 url("../../resources/images/colors/blue/button_highlight_selected.png") repeat-x;
            border-top: 1px solid #78acbf;
            border-left: 1px solid #34819e;
            border-right: 1px solid #35829f;
            border-bottom: 1px solid #257897;
            color: #FFFFFF;
        }
    </style>

    <script src="../Resources/scripts/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="../Resources/scripts/jquery-ui-1.8.custom.min.js" type="text/javascript"></script>

    <script src="../Resources/scripts/smooth.form.js" type="text/javascript"></script>

</head>
<body background="../Images/alt.jpg">
    <form id="form1" runat="server">
    <div>
        <center>
            <uc1:FileManager ID="FileManager1" runat="server"></uc1:FileManager>
        </center>
    </div>
    </form>
</body>
</html>
