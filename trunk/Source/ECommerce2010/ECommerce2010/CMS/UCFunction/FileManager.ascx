<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FileManager.ascx.cs" Inherits="ECommerce2010.CMS.UCFunction.FileManager" %>
<%@ Register Src="~/CMS/UCFunction/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>
<div runat="server" id="MsgClient">
</div>
<div style="margin-bottom:20px;text-align: center; width: 100%">
    <table style="float: left;" width="30%">
        <tr>
            <td align="center">
                <b>Folder Data</b>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TreeView ID="MyTree" PathSeparator="|" OnTreeNodePopulate="PopulateNode" ExpandDepth="0"
                    runat="server" ImageSet="XPFileExplorer" NodeIndent="15" OnSelectedNodeChanged="MyTree_SelectedNodeChanged">
                    <SelectedNodeStyle BackColor="#B5B5B5"></SelectedNodeStyle>
                    <NodeStyle VerticalPadding="2" Font-Names="Tahoma" Font-Size="11pt" HorizontalPadding="2"
                        ForeColor="#000000"></NodeStyle>
                    <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA"></HoverNodeStyle>
                    <Nodes>
                        <asp:TreeNode Text="InternetPark" PopulateOnDemand="True" Value="~/Upload/" />
                    </Nodes>
                </asp:TreeView>
            </td>
        </tr>
    </table>
    <table style="float: left;" width="69%">
        <tr>
            <b>File Management</b>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="">
                <uc1:Pager ID="Pager1" runat="server" />
            </td>
        </tr>
    </table>
</div>
<div style="height:20px;width:100%;clear:both"></div>
<div style="width: 100%; text-align: center">
    <b>Upload File</b>
    <asp:FileUpload ID="FileUpload" runat="server" />
    <asp:Button ID="btnUpload" runat="server" Text="Upload" BackColor="#CECECE" Width="70px" OnClick="btnUpload_Click" />
</div>
