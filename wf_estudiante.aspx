<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wf_estudiante.aspx.cs" Inherits="SistemaEstudiante.wf_estudiante" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 140px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">cedula</td>
                    <td>
                        <asp:TextBox ID="txt_cedula" runat="server" MaxLength="10"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">nombre</td>
                    <td>
                        <asp:TextBox ID="txt_nombre" runat="server" MaxLength="50"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">apellido</td>
                    <td>
                        <asp:TextBox ID="txt_apellido" runat="server" MaxLength="50"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">sexo</td>
                    <td>
                        <asp:CheckBox ID="chk_masculino" runat="server" AutoPostBack="True" OnCheckedChanged="chk_masculino_CheckedChanged" Text="M" />
                        <asp:CheckBox ID="chk_femenino" runat="server" AutoPostBack="True" OnCheckedChanged="chk_femenino_CheckedChanged" Text="F" />
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">fecha_nacimiento</td>
                    <td>
                        <asp:Calendar ID="cl_fecha_nacimiento" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                            <NextPrevStyle VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#808080" />
                            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                            <SelectorStyle BackColor="#CCCCCC" />
                            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <WeekendDayStyle BackColor="#FFFFCC" />
                        </asp:Calendar>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Button ID="btn_nuevo" runat="server" Text="Nuevo" OnClick="btn_nuevo_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btn_grabar" runat="server" OnClick="btn_grabar_Click" Text="Grabar" />
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EstudianteConnectionString %>" SelectCommand="SELECT * FROM [Estudiante]"></asp:SqlDataSource>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
                        <asp:GridView ID="gv_clientes" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gv_clientes_SelectedIndexChanged" OnRowDeleting="gv_clientes_RowDeleting">
                            <Columns>
                                <asp:BoundField DataField="cedula" HeaderText="cedula" />
                                <asp:BoundField DataField="nombre" HeaderText="nombre" />
                                <asp:BoundField DataField="apellido" HeaderText="apellido" />
                                <asp:BoundField DataField="fecha_nacimiento" DataFormatString="{0:d}" HeaderText="fecha_nacimiento" />
                                <asp:BoundField DataField="estado" HeaderText="estado" />
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:CommandField ShowDeleteButton="True" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
