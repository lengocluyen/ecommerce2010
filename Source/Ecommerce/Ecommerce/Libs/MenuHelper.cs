using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/*
using Libs.Models;
using Libs.Models.DAO;
using Libs.Controllers;
using Libs.ViewModels;
*/
namespace Libs
{
    public class MenuHelper
    {
        /*
        public static void GenerateUserMenu(ref string parentMN, ref string subMN, ref int index)
        {
            index = -1;
            string defaultMenu = "";
            List<UserMenu> lstMenu = UserMenuDAO.GetByUser(ParentController.GetLoginUser);//Get menu : and Enable =true

            List<UserMenu_VM> lstCustomMenu = new List<UserMenu_VM>();
            int count = 0;
            foreach (UserMenu mn in lstMenu) // Get parent menu
            {
                if (mn.ParentID_i == 0 && (bool)mn.IsAvailable_b)
                {
                    UserMenu_VM parentMenu = new UserMenu_VM();
                    parentMenu.UserMenu = mn;
                    parentMenu.Index = count++;
                    lstCustomMenu.Add(parentMenu);
                }
            }

            foreach (UserMenu mn in lstMenu) // Get children menu
            {
                if (mn.ParentID_i > 0)
                {
                    foreach (UserMenu_VM parentMenu in lstCustomMenu)
                    {
                        if (mn.ParentID_i == parentMenu.UserMenu.MenuID_i)
                        {
                            parentMenu.ChildMenu.Add(mn);
                            break;
                        }
                    }
                }
            }

            string currMenu = HttpContext.Current.Request.Url.AbsolutePath;
            foreach (UserMenu_VM cmn in lstCustomMenu)
            {
                //write parent
                parentMN += "<li><a href=\"" + cmn.UserMenu.MenuURL_s + "\">" + cmn.UserMenu.MenuName_s + "</a></li>";
                if (currMenu.ToLower().Contains(cmn.UserMenu.MenuURL_s.ToLower()))
                {
                    index = cmn.Index;
                    defaultMenu = cmn.UserMenu.MenuURL_s;
                }
            }

            //Write subMenu here ->order by Order_i asc
            count = 0;
            foreach (UserMenu_VM cmn in lstCustomMenu)
            {
                subMN += "<ul>";
                foreach (UserMenu submn in cmn.ChildMenu)
                {
                    //write submn
                    if ((bool)submn.IsAvailable_b)
                        subMN += "<li><a href=\"" + submn.MenuURL_s + "\">" + submn.MenuName_s + "</a></li>";
                    if (currMenu.ToLower().Contains(submn.MenuURL_s.ToLower()))
                    {
                        count = cmn.Index;
                        defaultMenu = submn.MenuURL_s;
                    }
                }
                subMN += "</ul>";
            }
            if (index == -1)
                index = count;
        }
        */
    }
}
