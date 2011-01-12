using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ECommerce2010.Core;

namespace ECommerce2010.CMS.UCFunction
{
    public partial class ImageManager : System.Web.UI.UserControl
    {
        public string location;
        public int row = 3;
        public int filePerRow = 5;

        protected void PopulateNode(Object source, TreeNodeEventArgs e)
        {
            TreeNode node = e.Node;
            string value = e.Node.Value;

            if (e.Node.Value == "~/Upload/")
            {
                e.Node.Value = Server.MapPath("~/Upload/");
            }
            
            String[] dirs = Directory.GetDirectories(node.Value);

            // Enumerate directories
            foreach (String dir in dirs)
            {
                TreeNode newNode = new TreeNode(Path.GetFileName(dir), dir);

                if (Directory.GetFiles(dir).Length > 0 || Directory.GetDirectories(dir).Length > 0)
                {
                    newNode.PopulateOnDemand = true;
                }
                newNode.Target = value + Path.GetFileName(dir)+"/";
                node.ChildNodes.Add(newNode);
            }

            // Enumerate files
            //String[] files = Directory.GetFiles(node.Value);

            //foreach (String file in files)
            //{
            //    TreeNode newNode = new TreeNode(Path.GetFileName(file), file);
            //    node.ChildNodes.Add(newNode);
            //}
        }
        protected void MyTree_SelectedNodeChanged(object sender, EventArgs e)
        {
            this.Label1.Text = DisplayFiles(MyTree.SelectedNode.Target);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Label1.Text = DisplayFiles(location);
        }

        string DisplayFiles(string location)
        {
            string physicalLocation = location;
            
            physicalLocation = MapPath(location);
            
            DirectoryInfo dInfo = new DirectoryInfo(physicalLocation);
            FileInfo[] arrFiles = dInfo.GetFiles();

            this.Pager1.totalObjects = arrFiles.Length;
            this.Pager1.objectsPerPage = row * filePerRow;
            this.Pager1.displayAll = false;

            int limit = row * filePerRow;

            if (this.Pager1.totalObjects < limit)
                limit = this.Pager1.totalObjects;

            int start = 0;
            //try
            //{
            if (Request.Params["page"] != null)
            {
                start = (int.Parse(Request.Params["page"]) - 1) * limit;
                limit = start + limit;
                if (limit > dInfo.GetFiles().Length)
                    limit = dInfo.GetFiles().Length;
            }
            //}
            //catch {}

            string clientLocation = location.Replace("~", "..");
            string result = "<table border=\"1\" cellpadding=\"0\" cellspacing=\"5px\"><tr>";

            for (int i = start; i < limit; i++)
            {
                result += "<td><img width=\"70\" height=\"96\" src=\"" + clientLocation + arrFiles[i].Name + "\" onclick=\"opener.document.forms[0]." + Server.UrlDecode(Request.Params["idFill"].ToString()) + ".value = '" + clientLocation + arrFiles[i].Name + "'; window.close();\" /></td>";

                if (i == limit - 1)
                    result += "</tr></table>";
                else if ((i + 1) % filePerRow == 0)
                    result += "</tr><tr>";
            }

            return result;
        }

        bool CheckImageFile(string fileName)
        {
            string extension = fileName.Substring(fileName.Length - 3, 3).ToLower();
            if (extension != "jpg" && extension != "bmp" && extension != "gif" && extension != "jpeg" && extension != "png")
                return false;
            return true;
        }
       
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (this.FileUpload.HasFile)
            {
                if (!CheckImageFile(this.FileUpload.FileName))
                {
                    this.MsgClient.InnerHtml = "<script language='javascript'>alert('Chỉ chấp nhận hình ảnh đuôi jpg, jpeg, gif, bmp, png.');</script>";
                    return;
                }
                else
                {
                    DirectoryInfo dInfo = new DirectoryInfo(MapPath(location));
                    FileInfo[] arrFiles = dInfo.GetFiles();

                    string fileName = ChangeFileNameIfExisted(this.FileUpload.FileName, dInfo);

                    this.FileUpload.SaveAs(MapPath(location) + fileName);

                    // Tinh xem nen redirect ve dau sau khi upload xong
                    arrFiles = dInfo.GetFiles();
                    string redirectURL = Request.Url.PathAndQuery;
                    if (Request.Params["page"] != null)
                        redirectURL = redirectURL.Replace("page=" + Request.Params["page"].ToString(), "page=" + GetTotalPage(arrFiles.Length, row * filePerRow));
                    else
                        redirectURL += "&page=" + GetTotalPage(arrFiles.Length, row * filePerRow);

                    // ------------------------

                    this.MsgClient.InnerHtml = "<script language='javascript'>window.location = \"" + redirectURL + "\";</script>";
                }
            }
        }

        string ChangeFileNameIfExisted(string fileName, DirectoryInfo dInfo)
        {
            foreach (FileInfo fInfo in dInfo.GetFiles())
                if (fInfo.Name == fileName)
                    return (Utils.GenerateRandomNumber().ToString() + fileName);
            return fileName;
        }

        int GetTotalPage(int totalObjects, int objectsPerPage)
        {
            int result = 0;
            if (totalObjects % objectsPerPage == 0)
                result = totalObjects / objectsPerPage;
            else
                result = totalObjects / objectsPerPage + 1;
            return result;
        }

       
    }
}