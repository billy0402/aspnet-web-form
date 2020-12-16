using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using AspnetWebForm.Models;

namespace AspnetWebForm
{
    public partial class Edit : System.Web.UI.Page
    {
        dbProductEntities db = new dbProductEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string fId = Request.QueryString["fId"].ToString();
                var product = db.tProduct.Where(m => m.fId == fId).FirstOrDefault();
                txtId.Text = product.fId;
                txtName.Text = product.fName;
                txtPrice.Text = product.fPrice.ToString();
                if (product.fImg == "")
                {
                    lblShowImg.Text = "無圖示";
                }
                else
                {
                    lblShowImg.Text = "<img src='Images/" + product.fImg + "' width='200'>";
                }
            }
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            string fId, fileName;
            fId = txtId.Text;
            var product = db.tProduct.Where(m => m.fId == fId).FirstOrDefault();

            // 圖檔儲存
            fileName = product.fImg;
            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(Server.MapPath("Images") + "/" + FileUpload1.FileName);
                fileName = FileUpload1.FileName;
            }

            // 修改紀錄
            product.fName = txtName.Text;
            product.fPrice = decimal.Parse(txtPrice.Text);
            product.fImg = fileName;
            db.SaveChanges();

            // 轉向 Index.aspx
            Response.Redirect("Index.aspx");
        }
    }
}