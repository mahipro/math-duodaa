<%@ Control Language="c#" Inherits="zhidao.Control.Login" CodeFile="Login.ascx.cs" %>

<TABLE cellSpacing="0" width="180" cellPadding="0" border="0" height="160" id="TABLE1"
	runat="server" onkeydown="submitlogin();" >
	<TR>
		<td colspan="3"><b>&nbsp;&nbsp;ע���û����¼</b></TD>
	</TR>
	<TR>
		<TD align="right" valign="middle"><FONT size="2">�ʺţ�</FONT></TD>
		<TD align="left" colspan="2">
			<asp:TextBox id="username" runat="server" Width="100px" MaxLength="20"></asp:TextBox>
            <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="����" ControlToValidate="username"
				ValidationExpression="[\u0800-\u4e00 \u4e00-\u9fa5 a-zA-Z_0-9]{3,20}"></asp:RegularExpressionValidator>
             <asp:RegularExpressionValidator id="RegularExpressionValidator3" runat="server" ControlToValidate="username"
				ValidationExpression="\S+"></asp:RegularExpressionValidator>
            </TD>
		
	</TR>
	<TR>
		<TD align="right" valign="middle"><FONT size="2">���룺</FONT></TD> 
		<TD align="left" colspan="2">
			<asp:TextBox id="password1" runat="server" TextMode="Password" Width="100px" MaxLength="20"></asp:TextBox>
            <asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" ErrorMessage="����" ControlToValidate="password1"
				ValidationExpression="[0-9a-zA-Z]{6,20}"></asp:RegularExpressionValidator>
            </TD>
		<TD>
			</TD>
	</TR>
    <TR>
		<TD align="right" valign="middle" ><FONT size="1">��֤�룺</FONT></TD>
		<TD align="left">
          
			<asp:TextBox id="checkcode" runat="server" Width="50px" MaxLength="6" ></asp:TextBox></TD>
		<td><img src="checkimage.aspx" title="�����壬�����һ��ͼ" onclick="this.src='checkimage.aspx?f='+Math.random()"/></td>
	</TR>
	<TR>
		<TD colSpan="3" align="center">
			<asp:Button id="Button1" runat="server" Text=" �� ¼ " onclick="Button1_Click"></asp:Button>
			<asp:Button id="Button2" runat="server" Text=" ע �� " onclick="Button2_Click"></asp:Button>
		</TD>
	</TR>
    <TR>
		<TD colSpan="3" align="center">
			<div><small><a href="forgetpw.aspx">�������룿���ȡ��</a></small></div>
		</TD>
	</TR>
</TABLE>
<TABLE cellSpacing="0" width="160" cellPadding="0" border="0" height="160" id="Table2"
	runat="server">
	<TR>
		<TD><b>&nbsp;&nbsp;���Ѿ���¼</b>

		</TD>
		<TD>
		</TD>
	</TR>
	<TR>
		<TD>�û�����
			<asp:Label id="zh" runat="server"></asp:Label>		</TD>
		<TD><a href="editinfo.aspx">�޸�����</a></TD>
	</TR>
	<TR>
		<TD>�����ʣ�
			<asp:Label id="tw" runat="server"></asp:Label>		</TD>
		<TD><a href="mytw.aspx">�ҵ�����</a></TD>
	</TR>
	<TR>
		<TD>�ѻش�
			<asp:Label id="hd" runat="server"></asp:Label>		</TD>
		<TD><a href="myhd.aspx">�ҵĻش�</a></TD>
	</TR>
    <TR>
		<TD>�����ɣ�
			<asp:Label id="dd" runat="server"></asp:Label>		</TD>
		<TD></TD>
	</TR>
    <TR>
		<TD>�߶߷֣�
			<asp:Label id="point" runat="server"></asp:Label>		</TD>
		<TD></TD>
	</TR>
    <TR>
		<TD>
			�઱ң�<asp:Label id="gold" runat="server"></asp:Label>		</TD>
		<TD></TD>
	</TR>
	
    <TR>
		<TD>
			<asp:Label id="Label1" runat="server"></asp:Label>		</TD>
		<TD> <asp:Button id="Button3" runat="server" Text="�˳�" onclick="Button3_Click"></asp:Button></TD>
	</TR>
   
</TABLE>


