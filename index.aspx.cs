﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        categorylistmethod();
    }

    string s = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

    //method for categorylist
    public void categorylistmethod()
    {
        using (SqlConnection con = new SqlConnection(s))
        {
            SqlCommand cmd = new SqlCommand("select * from category", con);
            try
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    gridview_categorylist.DataSource = rd;
                    gridview_categorylist.DataBind();
                }
                else
                {
                    panel_categoryshow_warning.Visible = true;
                    lbl_categoryshowwarning.Text = "Üzgünüm! Henüz bir kategori yok";
                }

            }
            catch (Exception ex)
            {
                panel_categoryshow_warning.Visible = true;
                lbl_categoryshowwarning.Text = "Bir şeyler yanlış gitti. Daha sonra tekrar deneyiniz</br> Ya da geliştirici ile iletişime geçiniz " + ex.Message;
            }
        }
    }

}