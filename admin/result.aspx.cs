﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class admin_result : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string uemail = Request.QueryString["uid"];
        if (!IsPostBack)
        {
            if(uemail != null)
            {
                getspecificresults(uemail);
                gridviewspecific.Visible = true;
                gridresult.Visible = false;
            }
            else
            {
                getallresults();
                gridviewspecific.Visible = false;
                gridresult.Visible = true;
            }
            
        }
    }
    string s = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
    //method for get all result
    public void getallresults()
    {
        using (SqlConnection con = new SqlConnection(s))
        {
            SqlCommand cmd = new SqlCommand("select * from result left join exam on result.exam_fid = exam.exam_id", con);
            try
            {
                con.Open();
                using (SqlDataAdapter ad = new SqlDataAdapter())
                {
                    ad.SelectCommand = cmd;
                    using (DataTable tb = new DataTable())
                    {
                        ad.Fill(tb);
                        if (tb != null)
                        {
                            gridresult.DataSource = tb;
                            gridresult.DataBind();
                        }
                        else
                        {
                            panel_resultshow_warning.Visible = true;
                            lbl_resultshowwarning.Text = "Henüz herhangi bir sonuç açıklanmamış";
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                panel_resultshow_warning.Visible = true;
                lbl_resultshowwarning.Text = "Bir hata oluştu." + ex.Message;
            }
        }
    }

    //method for spexific result

    public void getspecificresults(string email)
    {
        using (SqlConnection con = new SqlConnection(s))
        {
            SqlCommand cmd = new SqlCommand("select * from result left join exam on result.exam_fid = exam.exam_id where user_email = @uemail", con);
            cmd.Parameters.AddWithValue("@uemail", email);
            try
            {
                con.Open();
                using (SqlDataAdapter ad = new SqlDataAdapter())
                {
                    ad.SelectCommand = cmd;
                    using (DataTable tb = new DataTable())
                    {
                        ad.Fill(tb);
                        if (tb != null)
                        {
                            gridviewspecific.DataSource = tb;
                            gridviewspecific.DataBind();
                        }
                        else
                        {
                            panel_resultshow_warning.Visible = true;
                            lbl_resultshowwarning.Text = "Henüz herhangi bir sonuç açıklanmadı";
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                panel_resultshow_warning.Visible = true;
                lbl_resultshowwarning.Text = "Bir hata oluştu." + ex.Message;
            }
        }
    }
    //for paging
    protected void gridresult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridresult.PageIndex = e.NewPageIndex;
        getallresults();
        gridviewspecific.Visible = false;
        gridresult.Visible = true;
    }

    // for specific result paging
    protected void gridviewspecific_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        string uemail = Request.QueryString["uid"];
        gridviewspecific.PageIndex = e.NewPageIndex;
        getspecificresults(uemail);
        gridviewspecific.Visible = true;
        gridresult.Visible = false;
    }
}