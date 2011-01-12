using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ECommerce2010.CMS
{
    public partial class FileManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["location"] != null)
            {
                string location = Request.Params["location"].ToString();
                switch (location)
                {
                    case "books":
                        this.FileManager1.location = "~/Upload/Books/";
                        break;
                    case "excel":
                        this.FileManager1.location = "~/Upload/Excels/";
                        break;
                    case "file":
                        this.FileManager1.location = "~/Upload/Files/";
                        break;
                    case "other":
                        this.FileManager1.location = "~/Upload/Books/";
                        break;
                }
            }
        }
    }
}
