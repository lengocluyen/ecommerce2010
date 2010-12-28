using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Libs
{
    public class LibPager
    {
        //static string lblFirst = " First", lblPrev = " Prev", lblNext = "Next ", lblLast = "Last ";
        static string lblFirst = "Trang đầu", lblPrev = "Trang trước", lblNext = "Trang sau", lblLast = "Trang cuối";
        /// <summary>
        /// Gen link
        /// </summary>
        /// <param name="toltalItems">Total records set</param>
        /// <param name="pageSize">page size</param>
        /// <param name="itemsPerPage">number of records per page</param>
        /// <param name="currPage">current page</param>
        /// <returns>string of link, format: First Prev  1 2 3 4 5 6 Next Last </returns>
        public static string GenerateLink(int toltalItems, int pageSize, int itemsPerPage, int currPage)
        {
            string pageLink = "", pagingFisrt = "", pagingNum = "", pagingLast = "";

            int totalPage = (toltalItems % itemsPerPage == 0) ? (toltalItems / itemsPerPage) : (toltalItems / itemsPerPage + 1);
            if (toltalItems > itemsPerPage)//Upto 2 pages
            {
                /*---Show Fisrt Prev Page--*/
                if (currPage > 1)
                {
                    pagingFisrt += "<li><a href=\"#1\" page=\"1\">&laquo; " + lblFirst + "</a></li>";
                    pagingFisrt += "<li><a href=\"#" + (currPage-1) + "\" page=" + (currPage - 1) + ">&lsaquo; " + lblPrev + "</a></li>";
                }

                /*--Show page numbers--*/

                int start = currPage - (int)(pageSize / 2);
                int end = currPage + (int)((pageSize / 2) - 1);
                if (start < 1)
                {
                    start = 1; end = (pageSize > totalPage) ? totalPage : pageSize;
                }
                if (end > totalPage)
                {
                    end = totalPage; start = ((totalPage - pageSize + 1) > 1) ? (totalPage - pageSize + 1) : 1;
                }

                for (int i = start; i <= end; i++)
                {
                    if (i == currPage)
                        pagingNum += "<li class=\"current\">" + i + "</li>";
                    else
                        pagingNum += "<li><a href=\"#" + i + "\" page=\"" + i + "\">" + i + "</a></li>";
                }

                /*---Show Next Last Page--*/
                if (currPage < totalPage)
                {
                    pagingLast += "<li><a href=\"#" + (currPage + 1) + "\" page=" + (currPage + 1) + ">&rsaquo; " + lblNext + "</a></li>";
                    pagingLast += "<li><a href=\"#" + totalPage + "\" page=\"" + totalPage + "\">&raquo; " + lblLast + "</a></li>";
                }
            }
            //else has 1 page
            pageLink = pagingFisrt + pagingNum + pagingLast;
            return pageLink;
        }
        /// <summary>
        /// Gen link
        /// </summary>
        /// <param name="toltalItems">Total records set</param>
        /// <param name="pageSize">page size</param>
        /// <param name="itemsPerPage">number of records per page</param>
        /// <param name="currPage">current page</param>
        /// <param name="pageURL">current url in location</param>
        /// <returns>string of link, format: First Prev  1 2 3 4 5 6 Next Last </returns>
        public static string GenerateLink(int toltalItems, int pageSize, int itemsPerPage, int currPage, string pageURL)
        {
            if (pageURL.LastIndexOf('?') == -1)
                pageURL = pageURL + "?page=";
            else
            {
                int index = pageURL.LastIndexOf("page=");
                if (index == -1)
                    pageURL = pageURL + "&page=";
                else
                {
                    string newUrl = pageURL.Substring(index, pageURL.Length - index);
                    string[] lst = newUrl.Split('&');
                    pageURL = pageURL.Replace(lst[0], "") + "&page=";
                    pageURL = pageURL.Replace("&&", "&").Replace("?&", "?");
                }
            }
            return GenerateLink(toltalItems, pageSize, itemsPerPage, currPage).Replace("#", pageURL);
        }
    }
}
