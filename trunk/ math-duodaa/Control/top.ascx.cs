namespace zhidao.Control
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		top ��ժҪ˵����
	/// </summary>
	public partial class top : System.Web.UI.UserControl
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��

            if (Session["userid"].ToString()!="0" || Session["userlogin"].ToString()!="1") logic.isFirstLogin(Session["userid"].ToString());


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
			if(Session["userlogin"].ToString()=="1")
				Response.Redirect("tiwen.aspx");
			else
				Response.Redirect("Login.aspx");
		}

		
        
	}
}
