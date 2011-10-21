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
	/// editinfo ��ժҪ˵����
	/// </summary>
	public partial class editinfo : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(Session["userlogin"].ToString()=="0")
				Response.Redirect("index.aspx");
			else
			{
				if(!IsPostBack)
				{
					OleDbConnection conn=new OleDbConnection(dbConStr.dbConnStr());
					conn.Open();
					OleDbCommand cmd=new OleDbCommand("select a.username,b.sex,b.email,b.information, b.qq from users a,userinformation b where a.id=b.userid and a.id="+Session["userid"].ToString(),conn);
					OleDbDataReader r1=cmd.ExecuteReader();
					if(r1.Read())
					{
						xm.Text=r1["username"].ToString();
						if(r1["sex"].ToString()=="��")
							xb.SelectedIndex=0;
						else
							xb.SelectedIndex=1;
						email.Text=r1["email"].ToString();
                        qq.Text = r1["qq"].ToString().Trim();
						jj.Text=r1["information"].ToString();
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

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			if(email.Text=="")
				this.RegisterClientScriptBlock("tz1","<script>window.alert('������EMAIL��')</script>");
			else
			{
				OleDbConnection conn=new OleDbConnection(dbConStr.dbConnStr());
				conn.Open();
				OleDbCommand cmd;
				if(mm.Text=="")
				{
					cmd=new OleDbCommand("update userinformation set sex='"+xb.SelectedValue+"',email='"+email.Text+"',information='"+jj.Text+"',qq='"+qq.Text+"' where userid="+Session["userid"].ToString(),conn);
					cmd.ExecuteNonQuery();
				}
				else
				{
					cmd=new OleDbCommand("update users set password1='"+mm.Text+"' where id="+Session["userid"].ToString(),conn);
					cmd.ExecuteNonQuery();
					cmd=new OleDbCommand("update userinformation set sex='"+xb.SelectedValue+"',email='"+email.Text+"',information='"+jj.Text+"' where userid="+Session["userid"].ToString(),conn);
					cmd.ExecuteNonQuery();
				}
				conn.Close();
				Response.Redirect("editinfo.aspx");
			}
		}
	}
}
