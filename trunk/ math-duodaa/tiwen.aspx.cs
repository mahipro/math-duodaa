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

namespace zhidao
{
	/// <summary>
	/// tiwen ��ժҪ˵����
	/// </summary>
	public partial class tiwen : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(Session["userlogin"].ToString()=="0")
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
			if(caption.Text=="")
				this.RegisterClientScriptBlock("tz1","<script>window.alert('������������лл��')</script>");
			else
				Response.Redirect("tiwen_search.aspx?caption="+Server.UrlEncode(caption.Text).Replace("+","%20"));
		}
	}
}
