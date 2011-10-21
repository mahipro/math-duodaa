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
	/// Register ��ժҪ˵����
	/// </summary>
	public partial class Register : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(Session["userlogin"].ToString()=="0")
				Msg.Text="������Ѿ��Ƕ������ע���û�������ֱ��ʹ�����е��ʺ�<A href='login.aspx' target=_self>��¼</A>��";
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

		protected void Button1_Click(object sender, System.EventArgs e)

		{
            if (RegularExpressionValidator6.IsValid == false)
            {
                RegularExpressionValidator3.IsValid = false;
                RegularExpressionValidator3.ErrorMessage = "�û�������Ҫ��<br>ֻ�����볤��3��20����ĸ�����ֺͺ��֡�";
            }
			if(username.Text=="" || password1.Text=="" || password2.Text=="" || email.Text=="" || qq_Account.Text=="")
			this.RegisterClientScriptBlock("tz1","<script>window.alert('������������лл��')</script>");
            else if (RegularExpressionValidator3.IsValid == false)
            { this.RegisterClientScriptBlock("tz1", "<script>window.alert('�û���ֻ����3-20����ĸ�����ֺͺ��֣�')</script>"); }
            else if (RegularExpressionValidator4.IsValid == false)
            { this.RegisterClientScriptBlock("tz1", "<script>window.alert('����ֻ����6-20����ĸ�����֣�')</script>"); }
            else if (CompareValidator1.IsValid == false)
            { this.RegisterClientScriptBlock("tz1", "<script>window.alert('�������벻��ͬ��')</script>"); }
            else if (RegularExpressionValidator5.IsValid == false)
            { this.RegisterClientScriptBlock("tz1", "<script>window.alert('��Ч��QQ�Ÿ�ʽ��')</script>"); }
            else if (RegularExpressionValidator1.IsValid == false)
            { this.RegisterClientScriptBlock("tz1", "<script>window.alert('��Ч���ʼ���ʽ��')</script>"); }
            else if (Session["checkcode"].ToString().ToLower() != checkcode.Text.ToLower().Trim())
            { this.RegisterClientScriptBlock("tz1", "<script>window.alert('��֤�벻��ȷ��')</script>"); }
            else
            {
                if (xy.Checked == false)
                    this.RegisterClientScriptBlock("tz1", "<script>window.alert('��û��ͬ��Э�飬���ܴ����û���')</script>");
                else
                {
                    OleDbConnection conn = new OleDbConnection(dbConStr.dbConnStr());
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("select username from users where username=@username", conn);
                    cmd.Parameters.Add("@username", OleDbType.Char, 20);
                    cmd.Parameters["@username"].Value = username.Text.Trim();
                    OleDbDataReader r1 = cmd.ExecuteReader();
                    if (r1.Read())
                    {
                        r1.Close();
                        this.RegisterClientScriptBlock("tz1", "<script>window.alert('�û����Ѿ����ڣ�����������һ����')</script>");
                        username.Text = "";
                    }
                    else
                    {
                        r1.Close();
                        cmd = new OleDbCommand("insert into users(username,password1) values(@username,@password)", conn);
                        cmd.Parameters.Add("@username", OleDbType.Char, 20);
                        cmd.Parameters["@username"].Value = username.Text.Trim();
                        cmd.Parameters.Add("@password", OleDbType.Char, 20);
                        cmd.Parameters["@password"].Value = password2.Text;
                        cmd.ExecuteNonQuery();
                        cmd = new OleDbCommand("select id from users where username='" + username.Text.Trim() + "'", conn);
                        r1 = cmd.ExecuteReader();
                        r1.Read();
                        string _id = r1["id"].ToString();
                        r1.Close();
                        cmd = new OleDbCommand("insert into userinformation(userid,sex,email,information,sj,lastlogindate,QQ) values(@userid,@sex,@email,@information,@sj,@lastlogindate,@qq)", conn);
                        cmd.Parameters.Add("@userid", OleDbType.Integer);
                        cmd.Parameters.Add("@sex", OleDbType.Char, 2);
                        cmd.Parameters.Add("@email", OleDbType.Char, 50);
                        cmd.Parameters.Add("@information", OleDbType.Char, 200);
                        cmd.Parameters.Add("@sj", OleDbType.Date);
                        cmd.Parameters.Add("@lastlogindate", OleDbType.Date);
                        cmd.Parameters.Add("@qq", OleDbType.Char, 20);
                        cmd.Parameters["@userid"].Value = _id;
                        cmd.Parameters["@sex"].Value = sex.SelectedValue;
                        cmd.Parameters["@email"].Value = email.Text.Trim();
                        cmd.Parameters["@information"].Value = information.Text.Trim();
                        cmd.Parameters["@sj"].Value = DateTime.Now;
                        cmd.Parameters["@lastlogindate"].Value = DateTime.Now.AddDays(-1);
                        cmd.Parameters["@qq"].Value=qq_Account.Text.Trim();
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            Session["userlogin"] = "1";
                            Session["userid"] = _id;
                            Msg.Text = "���Ѿ��ɹ�ע�ᣬ����ֱ��ʹ�ø�ע����ʺ�<A href='login.aspx' target=_self>��¼</A>��";
                            this.RegisterClientScriptBlock("tz1", "<script>window.alert('ע��ɹ���');self.location='default.aspx';</script>");
                        }
                    }
                    conn.Close();
                }
            }
		}
	}
}
