<%@ Register TagPrefix="uc1" TagName="top" Src="Control/top.ascx" %>
<%@ Page language="c#" Inherits="zhidao.index" CodeFile="index.aspx.cs" %>
<%@ Register TagPrefix="uc1" TagName="buttom" Src="Control/buttom.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ad" Src="Control/ad.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Login" Src="Control/Login.ascx" %>
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
	
	 <script type="text/javascript" >var curTime="<% =DateTime.Now.ToString() %>"</script>
	 <script type="text/javascript" src="jsfunction/timecal.js">	</script>
     <script type="text/javascript" src="jsfunction/showprize.js">	</script>
	
	</HEAD>
	
    
	
	<body>

		<form id="Form1" method="post" runat="server">
			<uc1:top id="Top1" runat="server"></uc1:top>
			<table width="800" cellpadding="5" cellspacing="0" border="0">
				<tr>
					<td width="570" valign="top">
						<div class="leftdiv">
							<div align="left">
								<asp:Button id="Button1" runat="server" Text="ȫ������" Font-Bold="True" onclick="Button1_Click"></asp:Button>
								<asp:Button id="Button2" runat="server" Text="�ѽ��" onclick="Button2_Click"></asp:Button>
								<asp:Button id="Button3" runat="server" Text="�����" onclick="Button3_Click"></asp:Button></div>
							<div align="right">�����������
								<asp:Label id="_count" runat="server"></asp:Label>&nbsp;��</div>
							<asp:DataGrid id="Grid1" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="True"
								GridLines="None" PageSize="21" CellPadding="0">
								<ItemStyle Font-Size="14px"></ItemStyle>
								<HeaderStyle Font-Size="12px" HorizontalAlign="Left"></HeaderStyle>
								<Columns>
									<asp:HyperLinkColumn DataNavigateUrlField="id" DataNavigateUrlFormatString="view.aspx?id={0}" DataTextField="caption"
										HeaderText="����" DataTextFormatString="{0}&lt;br&gt;&lt;hr size=1 color=#eae6e8&gt;">
										<HeaderStyle Width="600px"></HeaderStyle>
									</asp:HyperLinkColumn>
                                    <asp:BoundColumn DataField="prize" HeaderText="����" DataFormatString="&lt;script type='text/javascript'&gt;document.write(showPrize('{0}'));&lt;/script&gt; &lt;br&gt;&lt;hr size=1 color=#eae6e8&gt;">
										<HeaderStyle Width="60px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>

									<asp:BoundColumn DataField="answer" HeaderText="�ش���" DataFormatString="{0}&lt;br&gt;&lt;hr size=1 color=#eae6e8&gt;">
										<HeaderStyle Width="60px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="state" HeaderText="״̬" DataFormatString="&lt;img src='images/state_{0}.gif'&gt;&lt;br&gt;&lt;hr size=1 color=#eae6e8&gt;">
										<HeaderStyle Width="40px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="sj" HeaderText="����ʱ��" DataFormatString="&lt;script type='text/javascript'&gt;document.write(shijian('{0:yyyy-MM-dd hh:mm:ss}',curTime));&lt;/script&gt; &lt;br&gt;&lt;hr size=1 color=#eae6e8&gt;">
										<HeaderStyle Width="80px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle  VerticalAlign="Bottom" NextPageText="��һҳ" PrevPageText="��һҳ" HorizontalAlign="Center"
									Mode="NumericPages" ></PagerStyle>
							</asp:DataGrid>
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
            <asp:Label ID="kk" runat="server"></asp:Label>
			<uc1:buttom id="Buttom1" runat="server"></uc1:buttom>
			<asp:TextBox id="TextBox1" runat="server" Width="0px" Visible="False">10</asp:TextBox>
            <asp:TextBox id="TextBox2" runat="server" Width="0px" Visible="False"></asp:TextBox>
		</form>
		
		
	</body>
</HTML>
