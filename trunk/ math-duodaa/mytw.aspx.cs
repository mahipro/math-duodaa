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
	/// mytw ��ժҪ˵����
	/// </summary>
	public partial class mytw : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(Session["userlogin"].ToString()=="0")
				Response.Redirect("index.aspx");
			if(!IsPostBack)
			{
				showdata();
			}
		}
		private void showdata()
		{
			string _sql;
				_sql="select * from problems where userid="+Session["userid"].ToString()+" order by sj desc";
			OleDbConnection conn=new OleDbConnection(dbConStr.dbConnStr());
			OleDbDataAdapter mydata=new OleDbDataAdapter(_sql,conn);
			DataSet ds=new DataSet();
			mydata.Fill(ds,"problems1");
			_count.Text=ds.Tables["problems1"].Rows.Count.ToString();
			Grid1.DataSource=ds.Tables["problems1"];
			Grid1.DataBind();
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
			this.Grid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.Grid1_PageIndexChanged);

		}
		#endregion

		private void Grid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			Grid1.CurrentPageIndex=e.NewPageIndex;
			showdata();
		}
	}
}
