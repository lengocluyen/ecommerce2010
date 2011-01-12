<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ECommerce2010.CMS.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fashion Shop!</title>
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
    <!-- stylesheets -->
    <link rel="stylesheet" type="text/css" href="~/resources/css/reset.css" />
    <link rel="stylesheet" type="text/css" href="~/resources/css/style.css" media="screen" />
    <link id="color" rel="stylesheet" type="text/css" href="~/resources/css/colors/blue.css" />
    <!-- scripts (jquery) -->

    <script src="../Resources/scripts/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="../Resources/scripts/jquery-ui-1.8.custom.min.js" type="text/javascript"></script>

    <script src="../Resources/scripts/smooth.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function() {
            style_path = "../resources/css/colors";

            $("input.focus").focus(function() {
                if (this.value == this.defaultValue) {
                    this.value = "";
                }
                else {
                    this.select();
                }
            });

            $("input.focus").blur(function() {
                if ($.trim(this.value) == "") {
                    this.value = (this.defaultValue ? this.defaultValue : "");
                }
            });

            $("input:submit, input:reset").button();
        });
    </script>

</head>
<body>
    <div id="login">
        <!-- login -->
        <div class="title">
            <h5>
                Administrator Page Fashion Shop</h5>
            <div class="corner tl">
            </div>
            <div class="corner tr">
            </div>
        </div>
        <div class="messages" runat="server" id="divMessage" visible="false">
            <div id="message-error" class="message message-error">
                <div class="image">
                    <img src="../resources/images/icons/error.png" alt="Error" height="32" />
                </div>
                <div class="text">
                    <h6>
                        Annouce</h6>
                    <span>Email or Password was incorrect.</span>
                </div>
                <div class="dismiss">
                    <a href="#message-error"></a>
                </div>
            </div>
        </div>
        <div class="inner">
            <form id="form1" runat="server">
            <div class="form">
                <!-- fields -->
                <div class="fields">
                    <div class="field">
                        <div class="label">
                            <label for="username"> 
                                Email:</label>
                        </div>
                        <div class="input">
                            <asp:TextBox ID="txtMail" runat="server" CssClass="focus"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage=""
                                ControlToValidate="txtMail" Display="Dynamic" ValidationGroup="LoginGroup" />
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label for="password">
                                Password:</label>
                        </div>
                        <div class="input">
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="focus"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage=""
                                ControlToValidate="txtPassword" Display="Dynamic" ValidationGroup="LoginGroup" />
                        </div>
                    </div>
                    <div class="field">
                        <div class="checkbox">
                            <input type="checkbox" id="remember" name="remember" />
                            <label for="remember">
                                Remember me</label>
                        </div>
                    </div>
                    <div class="buttons">
                        <asp:Button ID="btnSubmit" runat="server" Text="Sign in" OnClick="btn_Click" ValidationGroup="LoginGroup" />
                    </div>
                </div>
                <!-- end fields -->
                <!-- links -->
                <div class="links">
                    <a href="../default.aspx">Forgot your password?</a>
                </div>
                <!-- end links -->
            </div>
            </form>
        </div>
        <!-- end login -->
        <div id="colors-switcher" class="color">
            <a href="" class="blue" title="Blue"></a><a href="" class="green" title="Green">
            </a><a href="" class="brown" title="Brown"></a><a href="" class="purple" title="Purple">
            </a><a href="" class="red" title="Red"></a><a href="" class="greyblue" title="GreyBlue">
            </a>
        </div>
    </div>
</body>
</html>
