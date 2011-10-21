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
	/// view_ok ��ժҪ˵����
	/// </summary>
	public partial class view_ok : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			string _uid=Request.QueryString["uid"];
			string _pid=Request.QueryString["pid"];
			if(_uid=="" || _pid=="")
				Response.Redirect("index.aspx");
			else
			{
                OleDbConnection conn = new OleDbConnection(dbConStr.dbConnStr());
				conn.Open();
				OleDbCommand cmd=new OleDbCommand("select userid from problems where id=@id",conn);
				cmd.Parameters.Add("@id",OleDbType.Integer);
				cmd.Parameters["@id"].Value=_pid;
				OleDbDataReader d1=cmd.ExecuteReader();
				if(d1.Read())
				{
					if(d1["userid"].ToString()==Session["userid"].ToString())
					{
						d1.Close();
						cmd=new OleDbCommand("select id from answer where problemsid=@id and state='2'",conn);
						cmd.Parameters.Add("@id",OleDbType.Integer);
						cmd.Parameters["@id"].Value=_pid;
						d1=cmd.ExecuteReader();
						if(d1.Read())
						{
							d1.Close();
							Label1.Text="�������Ѿ�������Ѵ��ˡ�3����Զ����ء���";
							return;
						}
						else
						{
						
                            cmd = new OleDbCommand("select prize from problems where id=@id", conn);
                            cmd.Parameters.Add("@id",OleDbType.Integer);
                            cmd.Parameters["@id"].Value=_pid;                                     
                            d1=cmd.ExecuteReader();
                            d1.Read();
                            int _prize= Int32.Parse(d1["prize"].ToString());   // �õ��������������ֵ _prize ��

                            d1.Close();   //�õ�������ر�

                            cmd=new OleDbCommand("update answer set state='2' where userid=@uid and problemsid=@pid",conn);
							cmd.Parameters.Add("@uid",OleDbType.Integer);
							cmd.Parameters.Add("@pid",OleDbType.Integer);
							cmd.Parameters["@uid"].Value=_uid;
							cmd.Parameters["@pid"].Value=_pid;
							cmd.ExecuteNonQuery();
							cmd=new OleDbCommand("update userinformation set dd=dd+1 where userid=@uid",conn);
							cmd.Parameters.Add("@uid",OleDbType.Integer);
							cmd.Parameters["@uid"].Value=_uid;
							cmd.ExecuteNonQuery();
							cmd=new OleDbCommand("update problems set state='1' where id=@id",conn);
							cmd.Parameters.Add("@id",OleDbType.Integer);
							cmd.Parameters["@id"].Value=_pid;
							cmd.ExecuteNonQuery();
							conn.Close();

                            AddValue.addPoint("", Int32.Parse(_uid), GetConstant.AddPointClass[2]);     // ��_uid�û��ӻ���
                            AddValue.addGold("", Int32.Parse(_uid),  GetConstant.AddGoldClass[2] + _prize);  // ��_uid�û��ӽ��
                            LogOperation.AddLog(Session["userid"].ToString(),
                                                _uid,
                                                GetConstant.LogType[3] + _pid,                //�ش������LOGTYPE
                                                GetConstant.AddPointClass[2],          //�ش�����ӻ���
                                                GetConstant.AddGoldClass[2]+_prize,    //�ش�����ӽ��
                                                DateTime.Now,                          //Log��¼��ʱ��
                                                GetInfo.getClientIpAddress(),          //��¼Log������IP
                                                Request.Cookies["userinfo"].Values["usercookieid"] == null ? Session["userid"].ToString() : Request.Cookies["userinfo"].Values["usercookieid"].ToString(),
                                                "--");
							
                            Label1.Text="�˴��Ѿ����ɣ����رմ����⡣3����Զ����ء���";
						}
					}
					else
					{
						d1.Close();
						Label1.Text="�����Ǳ�����������ˡ�3����Զ����ء���";
						return;
					}
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
