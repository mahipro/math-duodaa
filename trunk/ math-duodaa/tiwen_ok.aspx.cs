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
	/// tiwen_ok ��ժҪ˵����
	/// </summary>
	public partial class tiwen_ok : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			string _state=Request.QueryString["state"];
            string _pid=Request.QueryString["pid"];

            if (_state == "0")
            {
                Label1.Text = "�ύ����ɹ���";
                Hyperlink2.NavigateUrl = "view_" + _pid+".html";
                Hyperlink1.NavigateUrl = "default.aspx" ;

            }
            else if (_state == "1")
                Label1.Text = "�ύ����ɹ������뾭������Ա��˺������ʾ��";
            else
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
	}
}
