<%@ Page language="c#" Inherits="zhidao.admin.clear" CodeFile="index.aspx.cs" %>
<%@ Register TagPrefix="uc1" TagName="top" Src="top.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ϵͳ����</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<fieldset>
				<uc1:top id="Top1" runat="server"></uc1:top>
				<asp:Button id="Button1" runat="server" Text="������������" onclick="Button1_Click"></asp:Button>
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="300" border="0" style="WIDTH: 300px; HEIGHT: 184px">
					<TR>
						<TD>�ʺ�</TD>
						<TD>
							<asp:TextBox id="TextBox1" runat="server"></asp:TextBox></TD>
						<TD>
							<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="Error" ControlToValidate="TextBox1"
								ValidationExpression="[^<,>,/,']*"></asp:RegularExpressionValidator></TD>
					</TR>
					<TR>
						<TD>����</TD>
						<TD>
							<asp:TextBox id="TextBox2" runat="server"></asp:TextBox></TD>
						<TD>
							<asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" ErrorMessage="Error" ControlToValidate="TextBox2"
								ValidationExpression="[^<,>,/,']*"></asp:RegularExpressionValidator></TD>
					</TR>
					<TR>
						<TD>��ȫ����</TD>
						<TD>
							<asp:CheckBox id="CheckBox1" runat="server" Text="�����Ƿ����"></asp:CheckBox></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD>
							<asp:Button id="Button2" runat="server" Text="����" onclick="Button2_Click"></asp:Button></TD>
						<TD><FONT face="����"></FONT></TD>
					</TR>
				</TABLE>
			</fieldset>
		</form>
	</body>
</HTML>
