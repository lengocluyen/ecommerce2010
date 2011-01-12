<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Content.ascx.cs" Inherits="ECommerce2010.UserControl.Content.Content" %>
<%@ Register src="../Left/Left.ascx" tagname="Left" tagprefix="uc1" %>
<%@ Register src="../Right/Right.ascx" tagname="Right" tagprefix="uc2" %>
<div id="block_portfolio">
                            <!--Menu Left-->
                            <div id="Left">
                              
                                <uc1:Left ID="Left1" runat="server" />
                              
                            </div>
                            <!--Right-->
                            <div id="content_area" class="block">
                                <div id="headcontent">
                                <div>
                                    HOT PRODUCTS &nbsp;</div>
                                </div>
                                <!-- Nội dung sản phẩm -->
                                <div class="block_inside">
                                    <uc2:Right ID="Right1" runat="server" />
                             
                                </div>
                                <div id="footcontent">
                                </div>
                            </div>
                        </div>