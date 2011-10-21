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
	/// Login ��ժҪ˵����
	/// </summary>
	public partial class Login : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
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
			OleDbCommand cmd=new OleDbCommand("select username from sys where username=@name and password1=@pass",conn);
			cmd.Parameters.Add("@name",OleDbType.Char,20);
			cmd.Parameters.Add("@pass",OleDbType.Char,20);
			cmd.Parameters["@name"].Value=username.Text;
			cmd.Parameters["@pass"].Value=password1.Text;
			OleDbDataReader r1=cmd.ExecuteReader();
			if(r1.Read())
			{
				Session["adminlogin"]="1";
				Response.Redirect("index.aspx");
			}
			else
				this.RegisterClientScriptBlock("tz1","<script>window.alert('�û������������')</script>");
			r1.Close();
			conn.Close();
		}
	}
}
