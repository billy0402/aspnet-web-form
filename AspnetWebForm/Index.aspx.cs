using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using AspnetWebForm.Models;

namespace AspnetWebForm
{
    public partial class Index : System.Web.UI.Page
    {
        dbProductEntities db = new dbProductEntities();

        // 在 GridView1 控制項顯示 tProduct 資料表的所有紀錄
        void LoadData()
        {
            GridView1.DataSource = db.tProduct.ToList();
            GridView1.DataBind();
        }

        // 網頁載入時執行
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadData();
            }
        }

        // 當控制項的 CommandName 按鈕被按時會觸發 RowCommand 事件
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string fId = e.CommandArgument.ToString();
            if (e.CommandName == "編輯")
            {
                Response.Redirect("Edit.aspx?fId=" + fId);
            }
            else if (e.CommandName == "刪除")
            {
                // 取得目前的產品
                var product = db.tProduct.Where(m => m.fId == fId).FirstOrDefault();
                // 取得產品圖檔
                string fileName = product.fImg;
                if (fileName != "")
                {
                    // 刪除指定圖檔
                    System.IO.File.Delete(Server.MapPath("~/Images") + "/" + fileName);
                }
                // 刪除指定產品
                db.tProduct.Remove(product);
                db.SaveChanges();
                LoadData();
            }
        }
    }
}