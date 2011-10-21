<%@ Page language="c#" Inherits="zhidao.Login" CodeFile="Login.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�û�ע��-<%=Application["CnWebName"]%></title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta content='<%=Application["Description"]%>' name="Description" />
		<meta content='<%=Application["Keywords"]%>' name="Keywords" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table cellpadding="0" cellspacing="0">
				<tr>
					<td>
						<fieldset>
							<TABLE cellSpacing="4" width="280" cellPadding="0" border="0" height="160">
								<TR>
									<TD colSpan="3"><b>&nbsp;&nbsp;���ע���û���ֱ�ӵ�¼</b></TD>
								</TR>
								<TR>
									<TD align="right"><FONT size="2">��&nbsp;��&nbsp;����</FONT></TD>
									<TD>
										<asp:TextBox id="username" runat="server" Width="155px" MaxLength="20"></asp:TextBox></TD>
									<TD>
										<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="����" ControlToValidate="username"
											ValidationExpression="[\u0800-\u4e00 \u4e00-\u9fa5 a-zA-Z_0-9]{3,20}"></asp:RegularExpressionValidator>
                                            <asp:RegularExpressionValidator id="RegularExpressionValidator3" runat="server" ControlToValidate="username"
											ValidationExpression="\S+"></asp:RegularExpressionValidator>
                                            </TD>
								</TR>
								<TR>
									<TD align="right"><FONT size="2">��&nbsp;&nbsp;&nbsp;&nbsp;�룺</FONT></TD>
									<TD>
										<asp:TextBox id="password1" runat="server" TextMode="Password" Width="155px" MaxLength="20"></asp:TextBox></TD>
									<TD>
										<asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" ErrorMessage="����" ControlToValidate="password1"
											ValidationExpression="[0-9a-zA-Z]{6,20}"></asp:RegularExpressionValidator></TD>
								</TR>
                                <TR>
									<TD align="right"><FONT size="2">��&nbsp;֤&nbsp;�룺</FONT></TD>
									<TD colspan="2"><asp:TextBox id="checkcode" runat="server" Width="50px" MaxLength="6" ></asp:TextBox>
										<img src="checkimage.aspx" title="�����壬�����һ��ͼ" onclick="this.src='checkimage.aspx?f='+Math.random()"/></TD>
									
								</TR>
								<TR>
									<TD colSpan="3" align="center">
										<asp:Button id="Button1" runat="server" Text=" �� ¼ " onclick="Button1_Click"></asp:Button></TD>
								</TR>
							</TABLE>
							<hr width="80%" size="1">
							<br>
							<div><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font size="2">û�ж���ʺţ�</font></b>
							</div>
							<br>
							<div align="center">
								<asp:Button id="Button2" runat="server" Text="����ע�����ʺ�" onclick="Button2_Click"></asp:Button></div>
							<br>
						</fieldset>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
