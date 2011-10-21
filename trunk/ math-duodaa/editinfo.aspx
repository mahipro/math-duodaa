<%@ Register TagPrefix="uc1" TagName="top" Src="Control/top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Login" Src="Control/Login.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ad" Src="Control/ad.ascx" %>
<%@ Page language="c#" Inherits="zhidao.editinfo" CodeFile="editinfo.aspx.cs" %>
<%@ Register TagPrefix="uc1" TagName="buttom" Src="Control/buttom.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>
			<%=Application["CnWebName"]%>
		</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta content='<%=Application["Description"]%>' name="Description" >
		<meta content='<%=Application["Keywords"]%>' name="Keywords" >
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link type="text/css" href="baidu.css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc1:top id="Top1" runat="server"></uc1:top>
			<table width="800" cellpadding="5" cellspacing="0" border="0">
				<tr>
					<td width="570" valign="top">
						<div class="leftdiv">
							<div align="left"><a href="index.aspx">�����</a>&gt;�޸ĸ�������</div>
							<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD><FONT face="����">�û���</FONT></TD>
									<TD>
										<asp:TextBox id="xm" runat="server" Width="150px" Enabled="False"></asp:TextBox></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD><FONT face="����">����</FONT></TD>
									<TD>
										<asp:TextBox id="mm" runat="server" TextMode="Password" Width="150px"></asp:TextBox></TD>
									<TD>
										<asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" ErrorMessage="���벻��Ҫ��" ControlToValidate="mm"
											ValidationExpression="[0-9a-zA-Z]{6,20}"></asp:RegularExpressionValidator></TD>
								</TR>
                                <TR>
									<TD><FONT face="����">�ظ�����</FONT></TD>
									<TD>
										<asp:TextBox id="mm1" runat="server" TextMode="Password" Width="150px"></asp:TextBox></TD>
									<TD>
										<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="mm1" ControlToCompare="mm" ErrorMessage="������������벻��ͬ"></asp:CompareValidator></TD>
								</TR>
								<TR>
									<TD><FONT face="����">�Ա�</FONT></TD>
									<TD>
										<asp:DropDownList id="xb" runat="server">
											<asp:ListItem Value="��">��</asp:ListItem>
											<asp:ListItem Value="Ů">Ů</asp:ListItem>
										</asp:DropDownList></TD>
									<TD></TD>
								</TR>
                                <TR>
									<TD><FONT face="����">QQ��</FONT></TD>
									<TD>
										<asp:TextBox id="qq" runat="server" Width="250px"></asp:TextBox></TD>
									<TD>
										<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="��Ч��QQ��" ControlToValidate="qq"
											ValidationExpression="[1-9]{1,1}[0-9]{4,20}"></asp:RegularExpressionValidator></TD>
								</TR>
								<TR>
									<TD><FONT face="����">�����ʼ�</FONT></TD>
									<TD>
										<asp:TextBox id="email" runat="server" Width="250px"></asp:TextBox></TD>
									<TD>
										<asp:RegularExpressionValidator id="RegularExpressionValidator3" runat="server" ErrorMessage="��Ч���ʼ���ַ" ControlToValidate="email"
											ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></TD>
								</TR>
								<TR>
									<TD><FONT face="����">���</FONT></TD>
									<TD>
										<asp:TextBox id="jj" runat="server" TextMode="MultiLine" Width="250px" Rows="10"></asp:TextBox></TD>
									<TD>
										<asp:RegularExpressionValidator id="RegularExpressionValidator4" runat="server" ErrorMessage="Error" ControlToValidate="jj"
											ValidationExpression="[^<,>,/,']*"></asp:RegularExpressionValidator></TD>
								</TR>
								<tr>
									<td></td>
									<td>
										<asp:Button id="Button1" runat="server" Text=" �� �� " onclick="Button1_Click"></asp:Button></td>
									<td></td>
								</tr>
							</TABLE>
						</div>
					</td>
					<td width="180" valign="top">
						<div class="rightdiv"><table cellpadding="0" cellspacing="0" border="0" width="160">
								<tr>
									<td>
										<uc1:Login id="Login1" runat="server"></uc1:Login></td>
								</tr>
							</table>
						</div>
						<br>
						<div class="addiv"><table cellpadding="0" cellspacing="0" border="0" width="160">
								<tr>
									<td>
										<uc1:ad id="Ad1" runat="server"></uc1:ad></td>
								</tr>
							</table>
						</div>
					</td>
				</tr>
			</table>
			<uc1:buttom id="Buttom1" runat="server"></uc1:buttom>
		</form>
	</body>
</HTML>
