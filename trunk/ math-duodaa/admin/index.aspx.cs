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

namespace zhidao.admin
{
	/// <summary>
	/// clear ��ժҪ˵����
	/// </summary>
	public partial class clear : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(Session["adminlogin"].ToString()=="0")
				Response.Redirect("login.aspx");
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
            OleDbConnection conn = new OleDbConnection(dbConStr.dbConnStr());
			conn.Open();
			OleDbCommand cmd=new OleDbCommand("delete from problemsinformation where problemsid not in (select a.id as problemsid from problems a,users b where a.userid=b.id)",conn);
			cmd.ExecuteNonQuery();
			Response.Write("����problemsinformation����ϡ���<br>");
			cmd=new OleDbCommand("delete from problems where userid not in (select id as userid from users)",conn);
			Response.Write("����problems����ϡ���<br>");
			cmd=new OleDbCommand("delete from answer where problemsid not in(select id as problemsid from problems)",conn);
			Response.Write("����answer����ϡ���<br>");
			cmd=new OleDbCommand("delete from userinformation where userid not in (select id as userid from user)",conn);
			Response.Write("����userinformation����ϡ���<br>");
			conn.Close();
		}

		protected void Button2_Click(object sender, System.EventArgs e)
		{
			if(TextBox1.Text=="" || TextBox2.Text=="")
				this.RegisterClientScriptBlock("tz1","<script>window.alert('������������')</script>");
			else
			{
                OleDbConnection conn = new OleDbConnection(dbConStr.dbConnStr());
				conn.Open();
				OleDbCommand cmd;
				cmd=new OleDbCommand("update sys set syssh=@sh,username=@name,password1=@pass",conn);
				cmd.Parameters.Add("@sh",OleDbType.Char,1);
				cmd.Parameters.Add("@name",OleDbType.Char,20);
				cmd.Parameters.Add("@pass",OleDbType.Char,20);
				if(CheckBox1.Checked==true)
					cmd.Parameters["@sh"].Value="1";
				else
					cmd.Parameters["@sh"].Value="0";
				cmd.Parameters["@name"].Value=TextBox1.Text;
				cmd.Parameters["@pass"].Value=TextBox2.Text;
				cmd.ExecuteNonQuery();
				conn.Close();
				Response.Redirect("index.aspx");
			}
		}
	}
}
