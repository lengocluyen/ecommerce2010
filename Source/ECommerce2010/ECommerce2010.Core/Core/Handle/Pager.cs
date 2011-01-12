#region // using Directives
using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
#endregion

[assembly: TagPrefix("ECommerce2010.Core", "UCPager")]
namespace ECommerce2010.Core
{
    [ToolboxData("<{0}:Pager ID=\"pager\" runat=\"server\"></{0}:Pager>")]
    public class Pager : WebControl, IPostBackEventHandler, INamingContainer
    {
        #region // Save/Load Control State
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Page.RegisterRequiresControlState(this);
        }

        protected override object SaveControlState()
        {
            object[] objState = new object[2];
            objState[0] = CurrentIndex;
            objState[1] = PageSize;

            return objState;
        }

        protected override void LoadControlState(object state)
        {
            object[] savedState = (object[])state;
            CurrentIndex = (int)savedState[0];
            PageSize = (int)savedState[1];
        }
        #endregion

        #region // PostBack Stuff
        const string PAGE_SIZE_PREFIX = "PS_";
        private readonly int[] pageSizeArray = { 5, 10, 15, 25, 50, 100, 200, 500 };
        private static readonly object EventCommand = new object();

        public event CommandEventHandler Command
        {
            add { Events.AddHandler(EventCommand, value); }
            remove { Events.RemoveHandler(EventCommand, value); }
        }

        protected virtual void OnCommand(CommandEventArgs e)
        {
            CommandEventHandler clickHandler = (CommandEventHandler)Events[EventCommand];
            if (clickHandler != null) clickHandler(this, e);
        }

        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
        {
            if (eventArgument.StartsWith(PAGE_SIZE_PREFIX))
            {
                CurrentIndex = 1;
                PageSize = Convert.ToInt32(eventArgument.Substring(PAGE_SIZE_PREFIX.Length));
                OnCommand(new CommandEventArgs(this.UniqueID, 1));
            }
            else
            {
                CurrentIndex = Convert.ToInt32(eventArgument);
                OnCommand(new CommandEventArgs(this.UniqueID, CurrentIndex));
            }
        }

        #endregion

        #region // Accessors (Behavioural)

        /// <summary>
        /// Gets or sets total number of rows.
        /// </summary>
        //private double _itemCount;
        //[Browsable(false)]
        //public double ItemCount
        //{
        //    get { return _itemCount; }
        //    set
        //    {
        //        _itemCount = value;

        //        double divide = ItemCount / PageSize;
        //        double ceiled = System.Math.Ceiling(divide);
        //        PageCount = Convert.ToInt32(ceiled);
        //    }
        //}
        [Browsable(false)]
        public double ItemCount
        {
            get { return ViewState["ItemCount"] == null ? 0 : (double)ViewState["ItemCount"]; }
            set
            {
                ViewState["ItemCount"] = value;

                double divide = value / PageSize;
                double ceiled = System.Math.Ceiling(divide);
                PageCount = Convert.ToInt32(ceiled);
            }
        }
        /// <summary>
        /// Gets or sets current page index.
        /// </summary>
        private int _currentIndex = 1;
        [Browsable(false)]
        public int CurrentIndex
        {
            get { return _currentIndex; }
            set { _currentIndex = value; }
        }

        /// <summary>
        /// Gets or sets page size (results per page).
        /// </summary>
        //private int _pageSize = 15;
        //[Category("Behavioural")]
        //public int PageSize
        //{
        //    get { return _pageSize; }
        //    set { _pageSize = value; }
        //}
        private int _pageSize;
        [Category("Behavioural")]
        public int PageSize
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["PageSize"] == null)
                {
                    Configuration a = new Configuration();
                    System.Web.HttpContext.Current.Session["PageSize"] = a.ItemperPageAdmin;
                }
                if (System.Web.HttpContext.Current.Session["PageSize"] != null)
                    _pageSize = (int)System.Web.HttpContext.Current.Session["PageSize"];
                return _pageSize;
            }
            set
            {
                System.Web.HttpContext.Current.Session["PageSize"] = value;
            }
        }
        /// <summary>
        /// Gets or sets the total number of pages.
        /// </summary>
        //private int _pageCount;
        //[Browsable(false)]
        //private int PageCount
        //{
        //    get { return _pageCount; }
        //    set { _pageCount = value; }
        //}

        // private int _pageCount;
        [Browsable(false)]
        private int PageCount
        {
            get
            {
                return ViewState["PageCount"] == null
                    ? 0 : (int)ViewState["PageCount"];
            }
            set
            {
                ViewState["PageCount"] = value;
            }
        }
        /// <summary>
        /// Gets or sets the value that indicates whether the Next and Last clause is rendered as UI on page.
        /// </summary>
        private bool _showFirstLast = false;
        [Category("Behavioural")]
        public bool GenerateFirstLastSection
        {
            get { return _showFirstLast; }
            set { _showFirstLast = value; }
        }

        /// <summary>
        /// Gets or sets the value that indicates whether the SmartShortcuts are rendered as UI on page.
        /// </summary>
        private bool _enableSSC = true;
        [Category("Behavioural")]
        public bool GenerateSmartShortCuts
        {
            get { return _enableSSC; }
            set { _enableSSC = value; }
        }

        /// <summary>
        /// Gets or sets the value that will be used to calculate SmartShortcuts.
        /// </summary>
        private double _sscRatio = 3.0D;
        [Category("Behavioural")]
        public double SmartShortCutRatio
        {
            get { return _sscRatio; }
            set { _sscRatio = value; }
        }

        /// <summary>
        /// Gets or sets maximum number of SmartShortcuts that can be rendered.
        /// </summary>
        private int _maxSmartShortCutCount = 6;
        [Category("Behavioural")]
        public int MaxSmartShortCutCount
        {
            get { return _maxSmartShortCutCount; }
            set { _maxSmartShortCutCount = value; }
        }

        /// <summary>
        /// Gets or sets a value that to have the SmartShortcuts rendered, the page count must be greater that this value.
        /// </summary>
        private int _sscThreshold = 30;
        [Category("Behavioural")]
        public int SmartShortCutThreshold
        {
            get { return _sscThreshold; }
            set { _sscThreshold = value; }
        }

        /// <summary>
        /// Gets or sets the number of rendered page numbers in compact mode.
        /// </summary>
        private int _firstCompactedPageCount = 10;
        [Category("Behavioural")]
        public int CompactModePageCount
        {
            get { return _firstCompactedPageCount; }
            set { _firstCompactedPageCount = value; }
        }

        /// <summary>
        /// Gets or sets the number of rendered page numbers in standard mode.
        /// </summary>
        private int _notCompactedPageCount = 15;
        [Category("Behavioural")]
        public int NormalModePageCount
        {
            get { return _notCompactedPageCount; }
            set { _notCompactedPageCount = value; }
        }

        /// <summary>
        /// Gets or sets a value that indicates whether Pager renders Alt tooltip.
        /// </summary>
        private bool _altEnabled = true;
        [Category("Behavioural")]
        public bool GenerateToolTips
        {
            get { return _altEnabled; }
            set { _altEnabled = value; }
        }
        /// <summary>
        /// Gets or sets a value that indicates whether Pager renders PageSize section is redered.
        /// </summary>
        private bool _pageSizeVisible = false;
        [Category("Behavioural")]
        public bool GeneratePageSizeSection
        {
            get { return _pageSizeVisible; }
            set { _pageSizeVisible = value; }
        }

        /// <summary>
        /// Gets or sets a value that indicates whether Pager information cell is rendered.
        /// </summary>
        private bool _infoCellVisible = true;
        [Category("Behavioural")]
        public bool GeneratePagerInfoSection
        {
            get { return _infoCellVisible; }
            set { _infoCellVisible = value; }
        }

        /// <summary>
        /// Gets or sets a value that indicats whether GoTo section is rendered.
        /// </summary>
        private bool _generateGoToSection = false;
        [Category("Behavioural")]
        public bool GenerateGoToSection
        {
            get { return _generateGoToSection; }
            set { _generateGoToSection = value; }
        }

        /// <summary>
        /// Gets or sets a value that indicates whether hidden hyperlinks should render.
        /// </summary>
        private bool _generateHiddenHyperlinks = false;
        [Category("Behavioural")]
        public bool GenerateHiddenHyperlinks
        {
            get { return _generateHiddenHyperlinks; }
            set { _generateHiddenHyperlinks = value; }
        }

        /// <summary>
        /// Gets or sets the hidden hyperlinks' QueryString parameter name.
        /// </summary>
        private string _queryStringParameterName = "pagerControlCurrentPageIndex";
        [Category("Behavioural")]
        public string QueryStringParameterName
        {
            get { return _queryStringParameterName; }
            set { _queryStringParameterName = value; }
        }

        #endregion

        #region // Accessors (Globalization)

        /// <summary>
        /// Gets or sets the text caption displayed as "go" in the pager control.
        /// Default value: go
        /// </summary>
        private string _GO = "đến";
        [Category("Globalization")]
        public string GoClause
        {
            get { return _GO; }
            set { _GO = value; }
        }

        /// <summary>
        /// Gets or sets the text caption displayed as "of" in the pager control.
        /// Default value: of
        /// </summary>
        private string _OF = " / ";
        [Category("Globalization")]
        public string OfClause
        {
            get { return _OF; }
            set { _OF = value; }
        }

        /// <summary>
        /// Gets or sets the text caption displayed as "from" in the pager control.
        /// Default value: From
        /// </summary>
        private string _FROM = "từ";
        [Category("Globalization")]
        public string FromClause
        {
            get { return _FROM; }
            set { _FROM = value; }
        }

        /// <summary>
        /// Gets or sets the text caption displayed as "page" in the pager control.
        /// Default value: Page
        /// </summary>
        private string _PAGE = "Trang";
        [Category("Globalization")]
        public string PageClause
        {
            get { return _PAGE; }
            set { _PAGE = value; }
        }

        /// <summary>
        /// Gets or sets the text caption displayed as "to" in the pager control.
        /// Default value: to
        /// </summary>
        private string _TO = "to";
        [Category("Globalization")]
        public string ToClause
        {
            get { return _TO; }
            set { _TO = value; }
        }

        /// <summary>
        /// Gets or sets the text caption displayed as "Showing Results" in the pager control.
        /// Default value: Showing Results
        /// </summary>
        private string _SHOWING_RESULT = "đang...";
        [Category("Globalization")]
        public string ShowingResultClause
        {
            get { return _SHOWING_RESULT; }
            set { _SHOWING_RESULT = value; }
        }

        /// <summary>
        /// Gets or sets the text caption displayed as "Show Result" in the pager control.
        /// Default value: Show Result
        /// </summary>
        private string _SHOW_RESULT = "Kết quả";
        [Category("Globalization")]
        public string ShowResultClause
        {
            get { return _SHOW_RESULT; }
            set { _SHOW_RESULT = value; }
        }

        /// <summary>
        /// Gets or sets the text caption displayed as "to First Page" in the pager control.
        /// Default value: to First Page
        /// </summary>
        private string _BACK_TO_FIRST = "Trang đầu";
        [Category("Globalization")]
        public string BackToFirstClause
        {
            get { return _BACK_TO_FIRST; }
            set { _BACK_TO_FIRST = value; }
        }

        /// <summary>
        /// Gets or sets the text caption displayed as "to Last Page" in the pager control.
        /// Default value: to Last Page
        /// </summary>
        private string _GO_TO_LAST = "Trang cuối";
        [Category("Globalization")]
        public string GoToLastClause
        {
            get { return _GO_TO_LAST; }
            set { _GO_TO_LAST = value; }
        }

        /// <summary>
        /// Gets or sets the text caption displayed as "Back to Page" in the pager control.
        /// Default value: Back to Page
        /// </summary>
        private string _BACK_TO_PAGE = "Trở lại";
        [Category("Globalization")]
        public string BackToPageClause
        {
            get { return _BACK_TO_PAGE; }
            set { _BACK_TO_PAGE = value; }
        }

        /// <summary>
        /// Gets or sets the text caption displayed as "Next to Page" in the pager control.
        /// Default value: Next to Page
        /// </summary>
        private string _NEXT_TO_PAGE = "Trang kế";
        [Category("Globalization")]
        public string NextToPageClause
        {
            get { return _NEXT_TO_PAGE; }
            set { _NEXT_TO_PAGE = value; }
        }

        /// <summary>
        /// Gets or sets the text caption displayed as "Last Page" in the pager control.
        /// Default value: &gt;&gt;
        /// </summary>
        private string _LAST = "&gt;&gt;";
        [Category("Globalization")]
        public string LastClause
        {
            get { return _LAST; }
            set { _LAST = value; }
        }

        /// <summary>
        /// Gets or sets the text caption displayed as "First Page" in the pager control.
        /// Default value: &lt;&lt;
        /// </summary>
        private string _FIRST = "&lt;&lt;";
        [Category("Globalization")]
        public string FirstClause
        {
            get { return _FIRST; }
            set { _FIRST = value; }
        }

        /// <summary>
        /// Gets or sets the text caption displayed as "Previous Page" in the pager control.
        /// Default value: &lt;
        /// </summary>
        private string _previous = "&lt;";
        [Category("Globalization")]
        public string PreviousClause
        {
            get { return _previous; }
            set { _previous = value; }
        }

        /// <summary>
        /// Gets or sets the text caption displayed as "Next Page" in the pager control.
        /// Default value: &gt;
        /// </summary>
        private string _next = "&gt;";
        [Category("Globalization")]
        public string NextClause
        {
            get { return _next; }
            set { _next = value; }
        }

        /// <summary>
        /// Gets or sets a value that indicates whether pager control should render RTL or LTR.
        /// </summary>
        private bool _rightToLeft = false;
        [Category("Globalization")]
        public bool RTL
        {
            get { return _rightToLeft; }
            set { _rightToLeft = value; }
        }


        #endregion

        #region // Render Utilities
        private string GenerateAltMessage(int pageNumber)
        {
            StringBuilder altGen = new StringBuilder();
            altGen.Append(pageNumber == CurrentIndex ? ShowingResultClause : ShowResultClause);
            altGen.Append(" ");
            altGen.Append(((pageNumber - 1) * PageSize) + 1);
            altGen.Append(" ");
            altGen.Append(ToClause);
            altGen.Append(" ");
            altGen.Append(pageNumber == PageCount ? ItemCount : pageNumber * PageSize);
            altGen.Append(OfClause);
            altGen.Append(ItemCount);

            return altGen.ToString();
        }

        private string GetAlternativeText(int pageNumber)
        {
            return GenerateToolTips ? string.Format(" title=\"{0}\"", GenerateAltMessage(pageNumber)) : "";
        }

        private string RenderFirst()
        {
            string templateCell = "<span><a class=\"PagerHyperlinkStyle First\" href=\"{0}\" title=\"" + BackToFirstClause + "\"> " + FirstClause + " </a></span>";
            return String.Format(templateCell, Page.ClientScript.GetPostBackClientHyperlink(this, " 1"));
        }

        private string RenderLast()
        {
            string templateCell = "<span><a class=\"PagerHyperlinkStyle Last\" href=\"{0}\" title=\"" + GoToLastClause + "\"> " + LastClause + " </a></span>";
            return String.Format(templateCell, Page.ClientScript.GetPostBackClientHyperlink(this, PageCount.ToString()));
        }

        private string RenderBack()
        {
            string templateCell = "<span><a class=\"PagerHyperlinkStyle Back\" href=\"{0}\" title=\""
                + string.Format(BackToPageClause, CurrentIndex - 1) + "\"> " + PreviousClause + " </a></span>";
            return String.Format(templateCell, Page.ClientScript.GetPostBackClientHyperlink(this, (CurrentIndex - 1).ToString()));
        }

        private string RenderNext()
        {
            string templateCell = "<span><a class=\"PagerHyperlinkStyle Next\" href=\"{0}\" title=\""
                + string.Format(NextToPageClause, CurrentIndex + 1) + "\"> " + NextClause + " </a></span>";
            return String.Format(templateCell, Page.ClientScript.GetPostBackClientHyperlink(this, (CurrentIndex + 1).ToString()));
        }

        private string RenderCurrent()
        {
            return "<span class=\"Current\" " + GetAlternativeText(CurrentIndex) + " ><strong> " + CurrentIndex.ToString() + " </strong></span>";
        }

        private string RenderOther(int pageNumber)
        {
            string templateCell = "<span><a class=\"PagerHyperlinkStyle\" href=\"{0}\" " + GetAlternativeText(pageNumber) + "&nbsp;>&nbsp;" + pageNumber.ToString() + " </a></span>";
            return String.Format(templateCell, Page.ClientScript.GetPostBackClientHyperlink(this, pageNumber.ToString()));
        }

        private string RenderSSC(int pageNumber)
        {
            string templateCell = "<span><a class=\"PagerHyperlinkStyle\" href=\"{0}\" " + GetAlternativeText(pageNumber) + "&nbsp;>&nbsp;" + pageNumber.ToString() + " </a></span>";
            return String.Format(templateCell, Page.ClientScript.GetPostBackClientHyperlink(this, pageNumber.ToString()));
        }

        private string RenderGoTo()
        {
            string templateCell = "<input id=\"goto_img\" onclick=\"handleGoToVisibility()\" type=\"button\" class=\"GoToArrow\"/>&nbsp;<div id=\"div_goto\" style=\"display:none;\"><select class=\"GoToSelect\" name=\"ddlTes\" id=\"ddlTes\" onchange=\"javascript:handleGoto(this);\">{0}</select></div>";
            string listItemTemplate = "<option {0} value=\"{1}\">{2}</option>";

            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= this.PageCount; i++)
            {
                sb.Append(string.Format(listItemTemplate, i == CurrentIndex ? "selected=\"selected\" class=\"GoToSelectedOption\"" : "", Page.ClientScript.GetPostBackClientHyperlink(this, i.ToString()), i));
            }
            return string.Format(templateCell, sb.ToString());
        }

        private string RenderGoToScript()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"
                                function handleGoto(selectObj) {
                                    eval(selectObj.options[selectObj.selectedIndex].value);
                                }

                                function handleGoToVisibility() {
                                    var gotoElem = document.getElementById('div_goto');
                                    gotoElem.style.display = gotoElem.style.display == 'none' ? 'inline' : 'none';
                                    var gotoImg = document.getElementById('goto_img');
                                ");

            sb.AppendFormat("gotoImg.className = gotoElem.style.display == 'none' ? '{0}' : '{1}';",
                                    "GoToArrow",
                                    "GoToArrowLeft");
            sb.Append("}");

            string goToScript = "<script type=\"text/javascript\">{0}</script>";

            return string.Format(goToScript, sb.ToString());
        }


        private string RenderPageSize()
        {
            string templateCell = "<span class=\"PageSize\"><select class=\"PageSizeSelect\" name=\"ddlPS\" id=\"ddlPS\" onchange=\"javascript:handleGoto(this);\">{0}</select></span>";
            string listItemTemplate = "<option {0} value=\"{1}\">{2}</option>";

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.pageSizeArray.Length; i++)
            {
                sb.Append(string.Format(listItemTemplate, pageSizeArray[i] == PageSize ? "selected=\"selected\" class=\"GoToSelectedOption\"" : "",
                    Page.ClientScript.GetPostBackClientHyperlink(this, PAGE_SIZE_PREFIX + pageSizeArray[i]), pageSizeArray[i]));
            }
            return string.Format(templateCell, sb.ToString());
        }
        #endregion

        #region // Smart ShortCut Stuff

        private List<int> _smartShortCutList;
        private List<int> SmartShortCutList
        {
            get { return _smartShortCutList; }
            set { _smartShortCutList = value; }
        }

        private void CalculateSmartShortcutAndFillList()
        {
            _smartShortCutList = new List<int>();
            double shortCutCount = this.PageCount * SmartShortCutRatio / 100;
            double shortCutCountRounded = System.Math.Round(shortCutCount, 0);
            if (shortCutCountRounded > MaxSmartShortCutCount) shortCutCountRounded = MaxSmartShortCutCount;
            if (shortCutCountRounded == 1) shortCutCountRounded++;

            for (int i = 1; i < shortCutCountRounded + 1; i++)
            {
                int calculatedValue = (int)(System.Math.Round((this.PageCount * (100 / shortCutCountRounded) * i / 100) * 0.1, 0) * 10);
                if (calculatedValue >= this.PageCount) break;
                SmartShortCutList.Add(calculatedValue);
            }
        }

        /* smart shortcut list calculator and list */
        private void RenderSmartShortCutByCriteria(int basePageNumber, bool getRightBand, HtmlTextWriter writer)
        {
            if (IsSmartShortCutAvailable())
            {

                List<int> lstSSC = this.SmartShortCutList;

                int rVal = -1;
                if (getRightBand)
                {
                    for (int i = 0; i < lstSSC.Count; i++)
                    {
                        if (lstSSC[i] > basePageNumber)
                        {
                            rVal = i;
                            break;
                        }
                    }
                    if (rVal >= 0)
                    {
                        for (int i = rVal; i < lstSSC.Count; i++)
                        {
                            if (lstSSC[i] != basePageNumber)
                            {
                                writer.Write(RenderSSC(lstSSC[i]));
                            }
                        }
                    }
                }
                else if (!getRightBand)
                {

                    for (int i = 0; i < lstSSC.Count; i++)
                    {
                        if (basePageNumber > lstSSC[i])
                        {
                            rVal = i;
                        }
                    }

                    if (rVal >= 0)
                    {
                        for (int i = 0; i < rVal + 1; i++)
                        {
                            if (lstSSC[i] != basePageNumber)
                            {
                                writer.Write(RenderSSC(lstSSC[i]));
                            }
                        }
                    }
                }
            }
        }

        bool IsSmartShortCutAvailable()
        {
            return this.GenerateSmartShortCuts && this.SmartShortCutList != null && this.SmartShortCutList.Count != 0;
        }
        #endregion

        #region // Render "SearchEngineFriendly" hyperlinks in HiddenDiv
        private string RenderHiddenDiv()
        {
            System.Text.RegularExpressions.Regex regEx;
            Uri theURL = System.Web.HttpContext.Current.Request.Url;
            bool hasQueryStringParam = !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.ServerVariables["QUERY_STRING"]) ? true : false;
            string tempHyperlink = "<a href=\"{0}\">Trang {1}</a>";
            string tempDiv = "<div style=\"display:none;\">{0}</div>";
            StringBuilder sb = new StringBuilder();

            if (hasQueryStringParam && System.Web.HttpContext.Current.Request.QueryString[this.QueryStringParameterName] != null)
            {
                regEx = new Regex(this.QueryStringParameterName + @"\=\d*", RegexOptions.Compiled | RegexOptions.Singleline);
                for (int i = 0; i < this.NormalModePageCount; i++)
                {
                    sb.Append(string.Format(tempHyperlink,
                                regEx.Replace(theURL.ToString(), this.QueryStringParameterName + "=" + (i + this.CurrentIndex)), i + this.CurrentIndex)
                        );
                }
            }
            else
            {
                string qsParameterName = "";
                for (int i = 0; i < this.NormalModePageCount; i++)
                {
                    qsParameterName = string.Format("{0}={1}", this.QueryStringParameterName, i + this.CurrentIndex);
                    sb.Append(string.Format(tempHyperlink,
                                hasQueryStringParam ? theURL.ToString() + "&" + qsParameterName : theURL.ToString() + "?" + qsParameterName,
                                i + this.CurrentIndex)
                            );
                }

            }

            return string.Format(tempDiv, sb.ToString());
        }
        #endregion

        #region // Override Control's Render operation
        protected override void Render(HtmlTextWriter writer)
        {
            if (PageCount == 0)
                return;

            if (Page != null) Page.VerifyRenderingInServerForm(this);

            if (this.PageCount > this.SmartShortCutThreshold && GenerateSmartShortCuts)
            {
                CalculateSmartShortcutAndFillList();
            }

          

            writer.AddAttribute(HtmlTextWriterAttribute.Class, "Pager");
            if (RTL) writer.AddAttribute(HtmlTextWriterAttribute.Dir, "rtl");

            writer.RenderBeginTag(HtmlTextWriterTag.Div);

           

            if (GeneratePagerInfoSection)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "PagerInfo");
                writer.RenderBeginTag(HtmlTextWriterTag.Span);
                writer.Write(PageClause + " " + CurrentIndex.ToString() + OfClause + PageCount.ToString());
                writer.RenderEndTag();
            }

            if (GenerateFirstLastSection && CurrentIndex != 1)
                writer.Write(RenderFirst());

            if (CurrentIndex != 1)
                writer.Write(RenderBack());

            if (CurrentIndex < CompactModePageCount)
            {

                if (CompactModePageCount > PageCount) CompactModePageCount = PageCount;

                for (int i = 1; i < CompactModePageCount + 1; i++)
                {
                    if (i == CurrentIndex)
                    {
                        writer.Write(RenderCurrent());
                    }
                    else
                    {
                        writer.Write(RenderOther(i));
                    }
                }

                RenderSmartShortCutByCriteria(CompactModePageCount, true, writer);

            }
            else if (CurrentIndex >= CompactModePageCount && CurrentIndex < NormalModePageCount)
            {

                if (NormalModePageCount > PageCount) NormalModePageCount = PageCount;

                for (int i = 1; i < NormalModePageCount + 1; i++)
                {
                    if (i == CurrentIndex)
                    {
                        writer.Write(RenderCurrent());
                    }
                    else
                    {
                        writer.Write(RenderOther(i));
                    }
                }

                RenderSmartShortCutByCriteria(NormalModePageCount, true, writer);

            }
            else if (CurrentIndex >= NormalModePageCount)
            {
                int gapValue = NormalModePageCount / 2;
                int leftBand = CurrentIndex - gapValue;
                int rightBand = CurrentIndex + gapValue;


                RenderSmartShortCutByCriteria(leftBand, false, writer);

                for (int i = leftBand; (i < rightBand + 1) && i < PageCount + 1; i++)
                {
                    if (i == CurrentIndex)
                    {
                        writer.Write(RenderCurrent());
                    }
                    else
                    {
                        writer.Write(RenderOther(i));
                    }
                }

                if (rightBand < this.PageCount)
                {

                    RenderSmartShortCutByCriteria(rightBand, true, writer);
                }
            }

            if (CurrentIndex != PageCount)
                writer.Write(RenderNext());

            if (GenerateFirstLastSection && CurrentIndex != PageCount)
                writer.Write(RenderLast());



            if (GeneratePageSizeSection)
                writer.Write(RenderPageSize());

            if (GenerateGoToSection)
                writer.Write(RenderGoTo());

            writer.RenderEndTag();


            if (GenerateGoToSection || GeneratePagerInfoSection)
                writer.Write(RenderGoToScript());

            if (GenerateHiddenHyperlinks)
                writer.Write(RenderHiddenDiv());
        }
        #endregion
    }
}