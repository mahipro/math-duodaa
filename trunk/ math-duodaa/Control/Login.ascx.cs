namespace zhidao.Control
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Data.OleDb;
    

	/// <summary>
	///		Login ��ժҪ˵����
	/// </summary>
	public partial class Login : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Label labexit;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
            
            TABLE1.Attributes.Add("onkeydown", "if(event.which || event.keyCode){   if ((event.which == 13) || (event.keyCode == 13)) {   document.getElementById('" + Button1.UniqueID + "').click();return false;}}    else {return true}; ");  
            
			if(Session["userlogin"].ToString()=="0")
			{
				TABLE1.Visible=true;
				Table2.Visible=false;
			}
			else
			{
				OleDbConnection conn=new OleDbConnection(dbConStr.dbConnStr());
				conn.Open();
				OleDbCommand cmd=new OleDbCommand("select a.username,b.tw,b.hd,b.dd,b.point,b.gold from users a,userinformation b where a.id=b.userid and a.id=@id",conn);
				cmd.Parameters.Add("@id",OleDbType.Integer);
				cmd.Parameters["@id"].Value=Session["userid"].ToString();
				OleDbDataReader r1=cmd.ExecuteReader();
				if(r1.Read())
				{
					zh.Text=r1["username"].ToString();
					tw.Text=r1["tw"].ToString();
					hd.Text=r1["hd"].ToString();
					dd.Text=r1["dd"].ToString();
                    point.Text = r1["point"].ToString();
                    gold.Text = r1["gold"].ToString() + "<img src='images/gold_0.gif'/>";

				}
				r1.Close();
				conn.Close();
				TABLE1.Visible=false;
				Table2.Visible=true;
			}

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
		///		�����֧������ķ��� - ��Ҫʹ�ô���༭��
		///		�޸Ĵ˷��������ݡ�
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
            if (username.Text == "" || password1.Text == "")
                Response.Write("<script>window.alert('������������лл��')</script>");
            else if (RegularExpressionValidator1.IsValid == false)
            { Response.Write("<script>window.alert('�û�����������')</script>"); }
            else if (RegularExpressionValidator2.IsValid == false)
            { Response.Write("<script>window.alert('������������')</script>"); }
            else if (Session["checkcode"].ToString().ToLower() != checkcode.Text.ToLower().Trim())
                {
                    Response.Write("<script>window.alert('��֤�������������������������֤��ͼƬ������ͼ���ԡ�лл��')</script>");

                }
         
                
            else
                {
                    OleDbConnection conn = new OleDbConnection(dbConStr.dbConnStr());
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("select id from users where username=@u and password1=@p", conn);
                    cmd.Parameters.Add("@u", OleDbType.Char, 20);
                    cmd.Parameters.Add("@p", OleDbType.Char, 20);
                    cmd.Parameters["@u"].Value = username.Text;
                    cmd.Parameters["@p"].Value = password1.Text;
                    OleDbDataReader r1 = cmd.ExecuteReader();
                    if (r1.Read())
                    {
                        Session["userlogin"] = "1";
                        Session["userid"] = r1["id"].ToString();

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
                        Response.Redirect(Request.RawUrl);

                    }
                    else
                    {
                        r1.Close();
                        conn.Close();
                        Response.Write("<script>window.alert('�û������������')</script>");
                    }
                }
            
		}

		protected void Button3_Click(object sender, System.EventArgs e)
		{
            string cookieid = Request.Cookies["userinfo"].Values["usercookieid"];
           // string cookieid1 = Request.Cookies["userinfo"].Values["userid"];
            //Response.Write("<script>window.alert('"+cookieid1+"')</script>");
            Session["userlogin"]="0";
			Session["userid"]="0";
            System.Web.HttpCookie newcookie;
            newcookie = new HttpCookie("userinfo");
            newcookie.Values["userid"] = "0";
            newcookie.Values["psw"] = "0";
            newcookie.Values["usercookieid"] = cookieid;
            newcookie.Expires = DateTime.Now.AddYears(30);
            Response.AppendCookie(newcookie);
            Response.Redirect(Request.RawUrl);
		}

	}
}
