using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ECommerce2010.Core;

namespace ECommerce2010.CMS.UCFunction
{
    public partial class Pager : System.Web.UI.UserControl
    {
        public int totalObjects;
        public int objectsPerPage = 5;
        public string objectsName = "objects";
        public bool displayAll = true;
        int currentPage;
        int totalPage;
        string url;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (totalObjects <= 0)
                return;
            totalPage = GetTotalPage();
            url = Utils.HandleURL(Request.Url.PathAndQuery, "page");
            if (totalPage == 0)
                return;
            else
            {
                currentPage = GetCurrentPage();
                this.lblRight.Text = HandlePages(currentPage);
            }
        }
        public int GetCurrentPage()
        {
            int curr = 1;
            if (Request.Params["page"] != null)
                curr = int.Parse(Request.Params["page"]);
            return curr;
        }
        public int GetTotalPage()
        {
            int result = 0;
            if (totalObjects % objectsPerPage == 0)
                result = totalObjects / objectsPerPage;
            else
                result = totalObjects / objectsPerPage + 1;
            return result;
        }
        public string HandlePages(int page)
        {
            string result = "";
            int next = page + 3;
            int previous = page - 3;
            if (next > totalPage)
                next = totalPage;
            if (previous < 1)
                previous = 1;

            if (page > 1)
            {
                result += "<a class=\"baPager\" href=\"" + url + "page=" + previous + "\">Trước</a> ";
                page--;
                result += "<a href=\"" + url + "page=" + page + "\">" + page + "</a> ";
                page++;
                result += "<span class=\"pagerCurrentPage\">" + page + "</span> ";
                if (page < totalPage)
                {
                    page++;
                    result += "<a href=\"" + url + "page=" + page + "\">" + page + "</a> ";
                }
                if (currentPage + 1 < totalPage)
                    result += "<span class=\"baPager\">. . .</span> ";
                result += "<a class=\"baPager\" href=\"" + url + "page=" + next + "\">Sau</a> ";
            }
            else if (page == 1)
            {
                result += "<span class=\"pagerCurrentPage\">" + page + "</span> ";
                page++;
                if (page < totalPage)
                {
                    result += "<a href=\"" + url + "page=" + page + "\">" + page + "</a> ";
                    page++;
                }
                if (page < totalPage + 1)
                {
                    result += "<a href=\"" + url + "page=" + page + "\">" + page + "</a> ";
                    if (currentPage + 2 < totalPage)
                        result += "<span class=\"baPager\">...</span> ";
                }
                result += "<a class=\"baPager\" href=\"" + url + "page=" + next + "\">Sau</a> ";
            }
            return result;
        }
    }
}