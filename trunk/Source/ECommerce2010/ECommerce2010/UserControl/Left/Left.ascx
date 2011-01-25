<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Left.ascx.cs" Inherits="ECommerce2010.UserControl.Left.Left" %>
<div class="mini_portfolio_item">
    <div class="headitems">
        <div class="ribbon">
            <span id="tLeftTitle1" runat="server"></span></div>
    </div>
    <div class="miditems">
        <ul class="Categories">
            <asp:Repeater ID="rptCategory" runat="server">
                <ItemTemplate>
                    <li><a href="javascript:void(0);" class="item">
                        <%#this.GetNameCategory(Eval("Name")) %></a></li>
                    <ul class="subCate">
                        <asp:Repeater ID="rtpSubCategory" runat="server" DataSource='<%#this.GetSubCategory(Eval("CategoryID"))%>'>
                            <ItemTemplate>
                                <li><a href='Default.aspx?lang=<%=language%>&do=category&value=<%#Eval("CategoryID")%>' class="active">
                                    <%#this.GetNameCategory(Eval("Name")) %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
         <script type="text/javascript">
            $(document).ready(function() {
                $(".opened").show();
                $(".closed").hide();
                $(".item").click(function() {
                    $(".subCate").hide();
                    $(this).next().slideToggle();
                })
            })
        </script>

    </div>
    <div class="footitems">
    </div>
</div>
