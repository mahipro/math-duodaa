using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using System.Timers;
using System.Net;
using System.IO;
using System.Threading;
using System.Data;
using System.Data.OleDb;


namespace zhidao 
{
	/// <summary>
	/// Global ��ժҪ˵����
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{
			Application["CnWebName"]=System.Configuration.ConfigurationManager.AppSettings["CnWebName"];
            Application["Description"] = System.Configuration.ConfigurationManager.AppSettings["Description"];
            Application["Keywords"] = System.Configuration.ConfigurationManager.AppSettings["Keywords"];

		}


 
		protected void Session_Start(Object sender, EventArgs e)
		{


            //autoExecute.setExpireState();

            if (Request.Cookies["userinfo"]!=null )
            {
                HttpCookie newcookie = Request.Cookies["userinfo"];

                if (newcookie.Values["userid"] != null)//����cookies�����cookies���ڣ��͵�¼
                {
                    int cookieuserid =(newcookie.Values["userid"]!=null?Int32.Parse(newcookie.Values["userid"]):0);
                    string cookiepsw=(newcookie.Values["psw"]!=null?newcookie.Values["psw"]:"0");

                    bool isLogOn = logic.isLogOnByID(cookieuserid, cookiepsw);
                    if (isLogOn==true)
                    {
                        Session["userlogin"] = "1";
                        Session["userid"] = newcookie.Values["userid"].ToString();
                        if (Request.Cookies["userinfo"].Values["usercookieid"] == null)
                        {
                            newcookie.Values["usercookieid"] = newcookie.Values["userid"].ToString();
                            Response.AppendCookie(newcookie);
                        }
                    }
                    else
                    {
                        Session["userlogin"] = "0";
                        Session["userid"] = "0";
                    }
                }
               
                else
                {
                    Session["userlogin"] = "0";
                    Session["userid"] = "0";
                }
            }
            else 
            {
                Session["userlogin"] = "0";
                Session["userid"] = "0";
            }

            
            Session["adminlogin"] = "0";

		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{
            
           
		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{


             
		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_Error(Object sender, EventArgs e)
		{
            
		}

		protected void Session_End(Object sender, EventArgs e)
		{


		}

		protected void Application_End(Object sender, EventArgs e)
		{

            
		}

        //��ʱִ�е���ҵ
        

      

           
        

		#region Web ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion
	}
}

