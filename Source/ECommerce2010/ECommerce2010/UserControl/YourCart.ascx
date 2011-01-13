<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="YourCart.ascx.cs" Inherits="ECommerce2010.UserControl.YourCart" %>
<div class="cart" style="margin-top:10px;margin-bottom:10px">
    <table cellpadding="1" cellspacing="0" border="1" class="tblCartinfo" style="border:solid 1px #ccc; width:99%; border-collapse: collapse;width: 700px;">
        <tr>
            <th class="titleHeader" style="width: 5%">
                No.
            </th>
            <th class="titleHeader" style="width: 25%">
                Image
            </th>
            <th class="titleHeader" style="width: 20%">
                Product Name
            </th>
            <th class="titleHeader" style="width: 20%">
                Price
            </th>
            <th class="titleHeader" style="width: 15%">
                Số lượng
            </th>
            <th class="titleHeader" style="width: 15%">
                UnitPrice
            </th>
            <th class="titleHeader" style="width: 5%">
                Delete
            </th>
        </tr>
        <tr>
            <td valign="top" colspan="7" align="center">
                <label id="lblMesg" style="display: none; color: #ff0000;">
                    Không có sản phẩm nào trong giỏ hàng của bạn</label>
            </td>
        </tr>
        <tr valign="middle">
            <td valign="middle" align="center">
                1
            </td>
            <td valign="middle" class="title" style="width: auto;" align="center">
                <img alt="" src="../Image/img/2.JPG">
            </td>
            <td valign="middle" class="title" style="width: 100px;" align="left">
                <a href="#">Áo Khoác</a>
            </td>
            <td valign="middle" class="title" style="width: 100px;" align="right">
                <span class="price">90.000 VNĐ</span>
            </td>
            <td valign="middle" class="title" style="width: 45px;" align="right">
                <input type="text" name="txtQuantity" style="width: 20px;" value="1">
            </td>
            <td valign="middle" class="title" style="width: 90px;" align="right">
                <span class="price">90.000 VNĐ </span>
            </td>
            <td valign="middle" align="center">
                <input type="checkbox" name="chkChoice" value="4879">
            </td>
        </tr>
        <tr>
            <td valign="top" colspan="7" align="right" class="title">
                <span class="price">Tổng Cộng: 90.000 VNĐ</span>
            </td>
        </tr>
        <tr>
            <td valign="middle" colspan="7" align="left" class="title" style="width: 97%">
                <div class="fl" align="left" style="float:left">
                    <input type="button" value="Tiếp tục mua hàng"
                        causesvalidation="false" class="inputCart">
                    <input type="button" value="Thanh toán" name="btn_payment" id="btn_payment" class="inputCart">
                    <input type="button" name="btnUpdate" id="btnUpdate" class="inputCart" onclick="updateItem()"
                        value="Tính lại">
                </div>
                <div class="fr" align="right">
                    <input type="button" name="btndel" id="btndel" class="inputCart" value="Xóa"">
                    <input type="button" name="btndelall" id="btndelall"
                        class="inputCart" value="Xóa Hết">
                </div>
            </td>
        </tr>
    </table>
</div>
