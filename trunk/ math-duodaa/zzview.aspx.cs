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
	/// zzview ��ժҪ˵����
	/// </summary>
	public partial class zzview : System.Web.UI.Page
	{
		public string labtitle;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!IsPostBack)
			{
				string _uid=Request.QueryString["userid"];
				if(_uid=="")
					Response.Redirect("default.aspx");
				else
				{
					OleDbConnection conn=new OleDbConnection(dbConStr.dbConnStr());
					conn.Open();
					OleDbCommand cmd=new OleDbCommand("select * from users a,userinformation b where a.id=b.userid and a.id="+_uid,conn);
					OleDbDataReader r1=cmd.ExecuteReader();
					if(r1.Read())
					{
						labtitle=r1["username"].ToString()+"�ĸ�������";
						Label1.Text=r1["username"].ToString();
						xm.Text=r1["username"].ToString();
						xb.Text=r1["sex"].ToString();
						email.Text=r1["email"].ToString();
						jj.Text=r1["information"].ToString();
						tw.Text=r1["tw"].ToString();
						hd.Text=r1["hd"].ToString();
						dd.Text=r1["dd"].ToString();
					}
					r1.Close();
					conn.Close();
				}
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
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion
	}
}
