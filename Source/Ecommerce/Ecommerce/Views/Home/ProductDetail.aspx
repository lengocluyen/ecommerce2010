<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ProductSite.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ProductDetail
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div style="float:left;">
		<a href="#">Home</a>
		<span class="bullet1"></span> 
		<a href="#">Testing category</a>
		<span class="bullet1"></span> 
		Testing product
	</div>

	<div class="clearall"></div>

    <h3>Testing Product</h3>

	<div class="box" style="width:100%; padding:10px 0 10px 0;">
		<div style="float:left; margin-left:10px;">
			<img class="small" src="../../Content/Images/productToCategory.jpg" />
			<p>Photos: 1</p>
		</div>
		<div class="productDetail" style="float:left; margin-left:30px; text-align:left; line-height:21px;">
			Name: <h4 style="display:inline;">Testing Product</h4><br/>
			Price: <span class="price">45$</span><br />
			Description: <br />
			<div class="expandField">
				<div class="productDescription" style="float:left; width:800px; font-size:11px; overflow:hidden;">
					<p>
						Xbox 360 250 GB to najnowsza wersja konsoli Xbox 360 firmy Microsoft. Charakteryzuje się ona mniejszymi wymiarami (o 30 procent względem poprzedniczek) - 270 na 75 na 264 mm, waży zaledwie 2,9 kg (3,5 kg w przypadku wcześniejszych modeli) i wewnętrzny dysk twardy o pojemności 250 GB.<br /><br />
						Xbox 360 250 GB jako pierwszy model w historii Xbox 360 posiada także wbudowane WiFi w standardzie N - 802.11n, pozwalające na komunikację radiową padów i pilotów z częstotliwością 2,4 GHz.<br /><br />
						Na uwagę zasługuje fakt, że konsolę wyposażono w zasilacz 135 W pobierający mniej prądu. Zadbano również o cichszą pracę urządzenia. Pod obudową znajdziemy układy wykonane w technologii 45 nanometrów. Natomiast na obudowie dostępne są dodatkowe przyciski: on/off, przycisk wysuwania tacki z sygnałem dźwiękowym, a także port pozwalający na podłączenie kontrolera Kinect. Zwiększono również ilość dostępnych portów USB - 3 z tyłu i 2 z przodu.<br /><br />
						Xbox 360 250 GB może pochwalić się nowym designem - konsola jest dostępna wyłącznie w kolorze piano black.<br /><br />
						Najważniejsze cechy nowego modelu:<br /><br />
						<ul>
							<li>30% mniejszy do poprzednika</li>
							<li>30% mniejszy do poprzednika</li>
							<li>30% mniejszy do poprzednika</li>
							<li>30% mniejszy do poprzednika</li>
							<li>30% mniejszy do poprzednika</li>
						</ul>
					</p>
				</div>
			</div>
			<div class="clearall"></div>
			<span class="staron"></span><span class="staron"></span><span class="staron"></span><span class="staroff"></span><span class="staroff"></span>
			<a href="#" style="font-size:11px;">(21 opinions)</a>
		</div>
	</div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptCSSContent" runat="server">
	<script type="text/javascript" src="../../Scripts/CustomScripts/productDetail.js"></script>
</asp:Content>
