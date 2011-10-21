using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

namespace zhidao
{
	/// <summary>
	/// Login ��ժҪ˵����
	/// </summary>
	public partial class Login : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(Session["userlogin"].ToString()=="1")
				Response.Redirect("default.aspx");
		}

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

		protected void Button2_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Register.aspx");
		}

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			if(username.Text=="" || password1.Text=="")
				this.RegisterClientScriptBlock("tz1","<script>window.alert('������������лл��')</script>");
            else if (Session["checkcode"].ToString().ToLower() != checkcode.Text.ToLower().Trim())
            {
                Response.Write("<script>window.alert('��֤���������')</script>");

            }
			else
			{
				OleDbConnection conn=new OleDbConnection(dbConStr.dbConnStr());
				conn.Open();
				OleDbCommand cmd=new OleDbCommand("select id from users where username=@u and password1=@p",conn);
				cmd.Parameters.Add("@u",OleDbType.Char,20);
				cmd.Parameters.Add("@p",OleDbType.Char,20);
				cmd.Parameters["@u"].Value=username.Text;
				cmd.Parameters["@p"].Value=password1.Text;
				OleDbDataReader r1=cmd.ExecuteReader();
				if(r1.Read())
				{
					Session["userlogin"]="1";
					Session["userid"]=r1["id"].ToString();

                    System.Web.HttpCookie newcookie;


                    newcookie = new HttpCookie("userinfo");
                    newcookie.Values["userid"] = r1["id"].ToString();
                    newcookie.Values["psw"] = password1.Text;
                    
                    if (Request.Cookies["userinfo"] == null) newcookie.Values["usercookieid"] = r1["id"].ToString();
                    else newcookie.Values["usercookieid"] = ((Request.Cookies["userinfo"].Values["usercookieid"] == null || Request.Cookies["userinfo"].Values["usercookieid"].Trim() == "") ? r1["id"].ToString() : Request.Cookies["userinfo"].Values["usercookieid"]);
                    //||Request.Cookies["userinfo"].Values["usercookieid"].Trim()==""
                    
                    newcookie.Expires = DateTime.Now.AddYears(30);
                    Response.AppendCookie(newcookie);


                    
                 
                    

					r1.Close();
					conn.Close();
					Response.Redirect("index.aspx");
				}
				else
				{
					r1.Close();
					conn.Close();
					this.RegisterClientScriptBlock("tz1","<script>window.alert('�û������������')</script>");
				}
			}
		}
	}
}
