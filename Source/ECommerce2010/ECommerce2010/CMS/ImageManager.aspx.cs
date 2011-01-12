using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ECommerce2010.CMS
{
    public partial class ImageManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["location"] != null)
            {
                string location = Request.Params["location"].ToString();
                switch (location)
                {
                    case "images":
                        this.ImagesManager1.location = "~/Upload/Images/";
                        break;
                    case "books":
                        this.ImagesManager1.location = "~/Upload/Books/";
                        break;
                    case "other":
                        this.ImagesManager1.location = "~/Upload/";
                        break;
                }
            }
        }
    }
}
