<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ProductSite.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	CategoryLv1
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div style="float:left;">
		<a href="#">Home</a>
		<span class="bullet1"></span> 
		Testing category
	</div>

	<div class="clearall"></div>

    <h3>Popular Products</h3>
	<div class="box" style="width:100%;">
		<div class="item" style="width:196px; margin:0; height:220px; text-align:center;">
			<img src="../../Content/Images/baterie-lazienkowe.jpg" />
			<div style="margin:auto;">
				<a href="#">Testing product</a>
			</div>
			<div style="width:151px; margin:10px auto 0 auto; text-align:left; color:#4f4e4e;">
				Price: <span class="price">45$</span>
			</div>
			<div style="width:151px; margin:5px auto 10px auto; text-align:left; color:#4f4e4e;">
				Rate: <span class="staron"></span><span class="staron"></span><span class="staron"></span><span class="staroff"></span><span class="staroff"></span>
			</div>
			<div class="clearall"></div>
			<div style="width:151px; margin:auto; text-align:center;">
				<span class="button1" style="margin:auto;">Detail</span>
				<span class="button1" style="margin-left:5px;">Buy</span>
			</div>
		</div>
		<div class="item" style="width:196px; margin:0; height:220px; text-align:center;">
			<img src="../../Content/Images/baterie-lazienkowe.jpg" />
			<div style="margin:auto;">
				<a href="#">Testing product</a>
			</div>
			<div style="width:151px; margin:10px auto 0 auto; text-align:left; color:#4f4e4e;">
				Price: <span class="price">45$</span>
			</div>
			<div style="width:151px; margin:5px auto 10px auto; text-align:left; color:#4f4e4e;">
				Rate: <span class="staron"></span><span class="staron"></span><span class="staron"></span><span class="staroff"></span><span class="staroff"></span>
			</div>
			<div class="clearall"></div>
			<div style="width:151px; margin:auto; text-align:center;">
				<span class="button1" style="margin:auto;">Detail</span>
				<span class="button1" style="margin-left:5px;">Buy</span>
			</div>
		</div>
		<div class="item" style="width:196px; margin:0; height:220px; text-align:center;">
			<img src="../../Content/Images/baterie-lazienkowe.jpg" />
			<div style="margin:auto;">
				<a href="#">Testing product</a>
			</div>
			<div style="width:151px; margin:10px auto 0 auto; text-align:left; color:#4f4e4e;">
				Price: <span class="price">45$</span>
			</div>
			<div style="width:151px; margin:5px auto 10px auto; text-align:left; color:#4f4e4e;">
				Rate: <span class="staron"></span><span class="staron"></span><span class="staron"></span><span class="staroff"></span><span class="staroff"></span>
			</div>
			<div class="clearall"></div>
			<div style="width:151px; margin:auto; text-align:center;">
				<span class="button1" style="margin:auto;">Detail</span>
				<span class="button1" style="margin-left:5px;">Buy</span>
			</div>
		</div>
		<div class="item" style="width:196px; margin:0; height:220px; text-align:center;">
			<img src="../../Content/Images/baterie-lazienkowe.jpg" />
			<div style="margin:auto;">
				<a href="#">Testing product</a>
			</div>
			<div style="width:151px; margin:10px auto 0 auto; text-align:left; color:#4f4e4e;">
				Price: <span class="price">45$</span>
			</div>
			<div style="width:151px; margin:5px auto 10px auto; text-align:left; color:#4f4e4e;">
				Rate: <span class="staron"></span><span class="staron"></span><span class="staron"></span><span class="staroff"></span><span class="staroff"></span>
			</div>
			<div class="clearall"></div>
			<div style="width:151px; margin:auto; text-align:center;">
				<span class="button1" style="margin:auto;">Detail</span>
				<span class="button1" style="margin-left:5px;">Buy</span>
			</div>
		</div>
		<div class="itemLast" style="width:195px; margin:0; height:220px;">
			<img src="../../Content/Images/baterie-lazienkowe.jpg" />
			<div style="margin:auto;">
				<a href="#">Testing product</a>
			</div>
			<div style="width:151px; margin:10px auto 0 auto; text-align:left; color:#4f4e4e;">
				Price: <span class="price">45$</span>
			</div>
			<div style="width:151px; margin:5px auto 10px auto; text-align:left; color:#4f4e4e;">
				Rate: <span class="staron"></span><span class="staron"></span><span class="staron"></span><span class="staroff"></span><span class="staroff"></span>
			</div>
			<div class="clearall"></div>
			<div style="width:151px; margin:auto; text-align:center;">
				<span class="button1" style="margin:auto;">Detail</span>
				<span class="button1" style="margin-left:5px;">Buy</span>
			</div>
		</div>
	</div>
	<div class="clearall"></div>
	<p>
		Detail breakdown: <a class="categoryLink" href="#">Testing category</a>
	</p>
	<div style="float:left; width:187px; margin:10px 0 0 10px;">
		<div style="float:left; width:9px; padding-top:3px;"><img src="../../Content/Images/icon_bullet.gif" /></div>
		<div style="float:left; margin-left:10px; width:166px"><a href="#">Child category 1</a></div>
	</div>
	<div style="float:left; width:187px; margin:10px 0 0 10px;">
		<div style="float:left; width:9px; padding-top:3px;"><img src="../../Content/Images/icon_bullet.gif" /></div>
		<div style="float:left; margin-left:10px; width:166px"><a href="#">Child category 2</a></div>
	</div>
	<div style="float:left; width:187px; margin:10px 0 0 10px;">
		<div style="float:left; width:9px; padding-top:3px;"><img src="../../Content/Images/icon_bullet.gif" /></div>
		<div style="float:left; margin-left:10px; width:166px"><a href="#">Child category 3</a></div>
	</div>
	<div style="float:left; width:187px; margin:10px 0 0 10px;">
		<div style="float:left; width:9px; padding-top:3px;"><img src="../../Content/Images/icon_bullet.gif" /></div>
		<div style="float:left; margin-left:10px; width:166px"><a href="#">Child category 4</a></div>
	</div>
	<div style="float:left; width:187px; margin:10px 0 0 10px;">
		<div style="float:left; width:9px; padding-top:3px;"><img src="../../Content/Images/icon_bullet.gif" /></div>
		<div style="float:left; margin-left:10px; width:166px"><a href="#">Child category 5</a></div>
	</div>
	<div style="float:left; width:187px; margin:10px 0 0 10px;">
		<div style="float:left; width:9px; padding-top:3px;"><img src="../../Content/Images/icon_bullet.gif" /></div>
		<div style="float:left; margin-left:10px; width:166px"><a href="#">Child category 6</a></div>
	</div>
	<div style="float:left; width:187px; margin:10px 0 0 10px;">
		<div style="float:left; width:9px; padding-top:3px;"><img src="../../Content/Images/icon_bullet.gif" /></div>
		<div style="float:left; margin-left:10px; width:166px"><a href="#">Child category 7</a></div>
	</div>
	<div style="float:left; width:187px; margin:10px 0 0 10px;">
		<div style="float:left; width:9px; padding-top:3px;"><img src="../../Content/Images/icon_bullet.gif" /></div>
		<div style="float:left; margin-left:10px; width:166px"><a href="#">Child category 8</a></div>
	</div>

	<div class="clearall"></div>
	<div class="box" style="width:100%; margin-top:15px;">
		<div class="item" style="width:196px; margin:0; height:220px; text-align:center;">
			<img src="../../Content/Images/baterie-lazienkowe.jpg" />
			<div style="margin:auto;">
				<a href="#">Testing product</a>
			</div>
			<div style="width:151px; margin:10px auto 0 auto; text-align:left; color:#4f4e4e;">
				Price: <span class="price">45$</span>
			</div>
			<div style="width:151px; margin:5px auto 10px auto; text-align:left; color:#4f4e4e;">
				Rate: <span class="staron"></span><span class="staron"></span><span class="staron"></span><span class="staroff"></span><span class="staroff"></span>
			</div>
			<div class="clearall"></div>
			<div style="width:151px; margin:auto; text-align:center;">
				<span class="button1" style="margin:auto;">Detail</span>
				<span class="button1" style="margin-left:5px;">Buy</span>
			</div>
		</div>
		<div class="item" style="width:196px; margin:0; height:220px; text-align:center;">
			<img src="../../Content/Images/baterie-lazienkowe.jpg" />
			<div style="margin:auto;">
				<a href="#">Testing product</a>
			</div>
			<div style="width:151px; margin:10px auto 0 auto; text-align:left; color:#4f4e4e;">
				Price: <span class="price">45$</span>
			</div>
			<div style="width:151px; margin:5px auto 10px auto; text-align:left; color:#4f4e4e;">
				Rate: <span class="staron"></span><span class="staron"></span><span class="staron"></span><span class="staroff"></span><span class="staroff"></span>
			</div>
			<div class="clearall"></div>
			<div style="width:151px; margin:auto; text-align:center;">
				<span class="button1" style="margin:auto;">Detail</span>
				<span class="button1" style="margin-left:5px;">Buy</span>
			</div>
		</div>
		<div class="item" style="width:196px; margin:0; height:220px; text-align:center;">
			<img src="../../Content/Images/baterie-lazienkowe.jpg" />
			<div style="margin:auto;">
				<a href="#">Testing product</a>
			</div>
			<div style="width:151px; margin:10px auto 0 auto; text-align:left; color:#4f4e4e;">
				Price: <span class="price">45$</span>
			</div>
			<div style="width:151px; margin:5px auto 10px auto; text-align:left; color:#4f4e4e;">
				Rate: <span class="staron"></span><span class="staron"></span><span class="staron"></span><span class="staroff"></span><span class="staroff"></span>
			</div>
			<div class="clearall"></div>
			<div style="width:151px; margin:auto; text-align:center;">
				<span class="button1" style="margin:auto;">Detail</span>
				<span class="button1" style="margin-left:5px;">Buy</span>
			</div>
		</div>
		<div class="item" style="width:196px; margin:0; height:220px; text-align:center;">
			<img src="../../Content/Images/baterie-lazienkowe.jpg" />
			<div style="margin:auto;">
				<a href="#">Testing product</a>
			</div>
			<div style="width:151px; margin:10px auto 0 auto; text-align:left; color:#4f4e4e;">
				Price: <span class="price">45$</span>
			</div>
			<div style="width:151px; margin:5px auto 10px auto; text-align:left; color:#4f4e4e;">
				Rate: <span class="staron"></span><span class="staron"></span><span class="staron"></span><span class="staroff"></span><span class="staroff"></span>
			</div>
			<div class="clearall"></div>
			<div style="width:151px; margin:auto; text-align:center;">
				<span class="button1" style="margin:auto;">Detail</span>
				<span class="button1" style="margin-left:5px;">Buy</span>
			</div>
		</div>
		<div class="itemLast" style="width:195px; margin:0; height:220px;">
			<img src="../../Content/Images/baterie-lazienkowe.jpg" />
			<div style="margin:auto;">
				<a href="#">Testing product</a>
			</div>
			<div style="width:151px; margin:10px auto 0 auto; text-align:left; color:#4f4e4e;">
				Price: <span class="price">45$</span>
			</div>
			<div style="width:151px; margin:5px auto 10px auto; text-align:left; color:#4f4e4e;">
				Rate: <span class="staron"></span><span class="staron"></span><span class="staron"></span><span class="staroff"></span><span class="staroff"></span>
			</div>
			<div class="clearall"></div>
			<div style="width:151px; margin:auto; text-align:center;">
				<span class="button1" style="margin:auto;">Detail</span>
				<span class="button1" style="margin-left:5px;">Buy</span>
			</div>
		</div>
		<div class="item" style="width:196px; margin:0; height:220px; text-align:center;">
			<img src="../../Content/Images/baterie-lazienkowe.jpg" />
			<div style="margin:auto;">
				<a href="#">Testing product</a>
			</div>
			<div style="width:151px; margin:10px auto 0 auto; text-align:left; color:#4f4e4e;">
				Price: <span class="price">45$</span>
			</div>
			<div style="width:151px; margin:5px auto 10px auto; text-align:left; color:#4f4e4e;">
				Rate: <span class="staron"></span><span class="staron"></span><span class="staron"></span><span class="staroff"></span><span class="staroff"></span>
			</div>
			<div class="clearall"></div>
			<div style="width:151px; margin:auto; text-align:center;">
				<span class="button1" style="margin:auto;">Detail</span>
				<span class="button1" style="margin-left:5px;">Buy</span>
			</div>
		</div>
		<div class="item" style="width:196px; margin:0; height:220px; text-align:center;">
			<img src="../../Content/Images/baterie-lazienkowe.jpg" />
			<div style="margin:auto;">
				<a href="#">Testing product</a>
			</div>
			<div style="width:151px; margin:10px auto 0 auto; text-align:left; color:#4f4e4e;">
				Price: <span class="price">45$</span>
			</div>
			<div style="width:151px; margin:5px auto 10px auto; text-align:left; color:#4f4e4e;">
				Rate: <span class="staron"></span><span class="staron"></span><span class="staron"></span><span class="staroff"></span><span class="staroff"></span>
			</div>
			<div class="clearall"></div>
			<div style="width:151px; margin:auto; text-align:center;">
				<span class="button1" style="margin:auto;">Detail</span>
				<span class="button1" style="margin-left:5px;">Buy</span>
			</div>
		</div>
		<div class="item" style="width:196px; margin:0; height:220px; text-align:center;">
			<img src="../../Content/Images/baterie-lazienkowe.jpg" />
			<div style="margin:auto;">
				<a href="#">Testing product</a>
			</div>
			<div style="width:151px; margin:10px auto 0 auto; text-align:left; color:#4f4e4e;">
				Price: <span class="price">45$</span>
			</div>
			<div style="width:151px; margin:5px auto 10px auto; text-align:left; color:#4f4e4e;">
				Rate: <span class="staron"></span><span class="staron"></span><span class="staron"></span><span class="staroff"></span><span class="staroff"></span>
			</div>
			<div class="clearall"></div>
			<div style="width:151px; margin:auto; text-align:center;">
				<span class="button1" style="margin:auto;">Detail</span>
				<span class="button1" style="margin-left:5px;">Buy</span>
			</div>
		</div>
		<div class="item" style="width:196px; margin:0; height:220px; text-align:center;">
			<img src="../../Content/Images/baterie-lazienkowe.jpg" />
			<div style="margin:auto;">
				<a href="#">Testing product</a>
			</div>
			<div style="width:151px; margin:10px auto 0 auto; text-align:left; color:#4f4e4e;">
				Price: <span class="price">45$</span>
			</div>
			<div style="width:151px; margin:5px auto 10px auto; text-align:left; color:#4f4e4e;">
				Rate: <span class="staron"></span><span class="staron"></span><span class="staron"></span><span class="staroff"></span><span class="staroff"></span>
			</div>
			<div class="clearall"></div>
			<div style="width:151px; margin:auto; text-align:center;">
				<span class="button1" style="margin:auto;">Detail</span>
				<span class="button1" style="margin-left:5px;">Buy</span>
			</div>
		</div>
		<div class="itemLast" style="width:195px; margin:0; height:220px;">
			<img src="../../Content/Images/baterie-lazienkowe.jpg" />
			<div style="margin:auto;">
				<a href="#">Testing product</a>
			</div>
			<div style="width:151px; margin:10px auto 0 auto; text-align:left; color:#4f4e4e;">
				Price: <span class="price">45$</span>
			</div>
			<div style="width:151px; margin:5px auto 10px auto; text-align:left; color:#4f4e4e;">
				Rate: <span class="staron"></span><span class="staron"></span><span class="staron"></span><span class="staroff"></span><span class="staroff"></span>
			</div>
			<div class="clearall"></div>
			<div style="width:151px; margin:auto; text-align:center;">
				<span class="button1" style="margin:auto;">Detail</span>
				<span class="button1" style="margin-left:5px;">Buy</span>
			</div>
		</div>
		<div class="item" style="width:196px; margin:0; height:220px; text-align:center;">
			<img src="../../Content/Images/baterie-lazienkowe.jpg" />
			<div style="margin:auto;">
				<a href="#">Testing product</a>
			</div>
			<div style="width:151px; margin:10px auto 0 auto; text-align:left; color:#4f4e4e;">
				Price: <span class="price">45$</span>
			</div>
			<div style="width:151px; margin:5px auto 10px auto; text-align:left; color:#4f4e4e;">
				Rate: <span class="staron"></span><span class="staron"></span><span class="staron"></span><span class="staroff"></span><span class="staroff"></span>
			</div>
			<div class="clearall"></div>
			<div style="width:151px; margin:auto; text-align:center;">
				<span class="button1" style="margin:auto;">Detail</span>
				<span class="button1" style="margin-left:5px;">Buy</span>
			</div>
		</div>
		<div class="item" style="width:196px; margin:0; height:220px; text-align:center;">
			<img src="../../Content/Images/baterie-lazienkowe.jpg" />
			<div style="margin:auto;">
				<a href="#">Testing product</a>
			</div>
			<div style="width:151px; margin:10px auto 0 auto; text-align:left; color:#4f4e4e;">
				Price: <span class="price">45$</span>
			</div>
			<div style="width:151px; margin:5px auto 10px auto; text-align:left; color:#4f4e4e;">
				Rate: <span class="staron"></span><span class="staron"></span><span class="staron"></span><span class="staroff"></span><span class="staroff"></span>
			</div>
			<div class="clearall"></div>
			<div style="width:151px; margin:auto; text-align:center;">
				<span class="button1" style="margin:auto;">Detail</span>
				<span class="button1" style="margin-left:5px;">Buy</span>
			</div>
		</div>
		<div class="item" style="width:196px; margin:0; height:220px; text-align:center;">
			<img src="../../Content/Images/baterie-lazienkowe.jpg" />
			<div style="margin:auto;">
				<a href="#">Testing product</a>
			</div>
			<div style="width:151px; margin:10px auto 0 auto; text-align:left; color:#4f4e4e;">
				Price: <span class="price">45$</span>
			</div>
			<div style="width:151px; margin:5px auto 10px auto; text-align:left; color:#4f4e4e;">
				Rate: <span class="staron"></span><span class="staron"></span><span class="staron"></span><span class="staroff"></span><span class="staroff"></span>
			</div>
			<div class="clearall"></div>
			<div style="width:151px; margin:auto; text-align:center;">
				<span class="button1" style="margin:auto;">Detail</span>
				<span class="button1" style="margin-left:5px;">Buy</span>
			</div>
		</div>
		<div class="item" style="width:196px; margin:0; height:220px; text-align:center;">
			<img src="../../Content/Images/baterie-lazienkowe.jpg" />
			<div style="margin:auto;">
				<a href="#">Testing product</a>
			</div>
			<div style="width:151px; margin:10px auto 0 auto; text-align:left; color:#4f4e4e;">
				Price: <span class="price">45$</span>
			</div>
			<div style="width:151px; margin:5px auto 10px auto; text-align:left; color:#4f4e4e;">
				Rate: <span class="staron"></span><span class="staron"></span><span class="staron"></span><span class="staroff"></span><span class="staroff"></span>
			</div>
			<div class="clearall"></div>
			<div style="width:151px; margin:auto; text-align:center;">
				<span class="button1" style="margin:auto;">Detail</span>
				<span class="button1" style="margin-left:5px;">Buy</span>
			</div>
		</div>
		<div class="itemLast" style="width:195px; margin:0; height:220px;">
			<img src="../../Content/Images/baterie-lazienkowe.jpg" />
			<div style="margin:auto;">
				<a href="#">Testing product</a>
			</div>
			<div style="width:151px; margin:10px auto 0 auto; text-align:left; color:#4f4e4e;">
				Price: <span class="price">45$</span>
			</div>
			<div style="width:151px; margin:5px auto 10px auto; text-align:left; color:#4f4e4e;">
				Rate: <span class="staron"></span><span class="staron"></span><span class="staron"></span><span class="staroff"></span><span class="staroff"></span>
			</div>
			<div class="clearall"></div>
			<div style="width:151px; margin:auto; text-align:center;">
				<span class="button1" style="margin:auto;">Detail</span>
				<span class="button1" style="margin-left:5px;">Buy</span>
			</div>
		</div>
	</div>
	<div class="clearall"></div>
	<div class="pagination">
		<div class="results">
			<span>Results 1 - 15 of 198</span>
		</div>
		<ul class="pager">
			<li class="current">1</li>
			<li><a href="#">2</a></li>
			<li><a href="#">&rsaquo; Next</a></li>
			<li><a href="#">&raquo; Last</a></li>
		</ul>
	</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptCSSContent" runat="server">
</asp:Content>
