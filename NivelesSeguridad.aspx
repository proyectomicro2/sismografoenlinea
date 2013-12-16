<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<script runat="server">


    protected void btnBodyOk_Click(object sender, EventArgs e)
    {
       // Response.Write(this.lbEliminar0.SelectedItem.Text);
        sismografoenlinea.ConexionSql conectSq = new sismografoenlinea.ConexionSql();
        try
        {
            conectSq.eliminaralarma(lbEliminar0.SelectedItem.ToString());
            lbEliminar0.Items.Clear();
            conectSq.mostrarAlarmas(lbEliminar0, sismografoenlinea.Account.Graficas.InfoUsuario.nombreUsuario);

            Lbmostrar0.Items.Clear();
            conectSq.mostrarAlarmas(Lbmostrar0, sismografoenlinea.Account.Graficas.InfoUsuario.nombreUsuario);
        }
        catch (Exception x)
        {
            // TextBox1.Text = x.Message.ToString();

        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            sismografoenlinea.ConexionSql conectSq = new sismografoenlinea.ConexionSql();

            lbEliminar0.Items.Clear();
            conectSq.mostrarAlarmas(lbEliminar0, sismografoenlinea.Account.Graficas.InfoUsuario.nombreUsuario);
        }
    }
</script>
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NivelesSeguridad.aspx.cs" Inherits="sismografoenlinea.NivelesSeguridad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .modalBackground
        {
            background-color: Black;
            filter: alpha(opacity=80);
            opacity: 0.8;
        }
        .modalPopup
        {
            border: 3px solid black;
            background-color: #B6B7BC;
            padding-top: 10px;
            padding-left: 10px;
            width: 300px;
            }         
         
    </style>
    <link href="bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="bootstrap.css" rel="stylesheet" type="text/css" /> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
    </p>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <table class="nav-justified">
                <tr>
                    <td class="style3">
                        <asp:Button ID="Button8" runat="server" Text="Agregar" />
                        <asp:ModalPopupExtender ID="Button8_ModalPopupExtender" runat="server" 
                            BackgroundCssClass="modalBackground" DynamicServicePath="" Enabled="True" 
                            PopupControlID="Panelmodal" TargetControlID="Button8">
                        </asp:ModalPopupExtender>
                    </td>
                    <td class="style4">
                        <asp:Button ID="Button4" runat="server" Text="Mostrar" />
                        <asp:ModalPopupExtender ID="Button4_ModalPopupExtender" runat="server" 
                            BackgroundCssClass="modalBackground" DynamicServicePath="" Enabled="True" 
                            PopupControlID="Panelmodal1" TargetControlID="Button4">
                        </asp:ModalPopupExtender>
                    </td>
                    <td>
                        &nbsp;&nbsp;
                        <modalpopupextender id="Button5_ModalPopupExtender" runat="server" 
                            backgroundcssclass="modalBackground" dynamicservicepath="" enabled="True" 
                            popupcontrolid="Panelmodal2" targetcontrolid="Button5">
                        </modalpopupextender>
                        &nbsp;<asp:Button ID="Button9" runat="server" Text="Eliminar" />
                        <asp:ModalPopupExtender ID="Button9_ModalPopupExtender" runat="server" 
                            BackgroundCssClass="modalBackground" DynamicServicePath="" Enabled="True" 
                            PopupControlID="Panelmodal2" TargetControlID="Button9">
                        </asp:ModalPopupExtender>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
<p>
        &nbsp;</p>
<asp:Panel ID="Panelmodal" runat="server" 
    style="display: list-item; background: white; width: 80%; height: auto">
    <div class="modal-header">
        <button aria-hidden="true" class="close" data-dismiss="modal" type="button">
            ×
        </button>
        <h3>
            Agregar Alarma</h3>
    </div>
    <div class="modal-body">
        <asp:Label ID="Label5" runat="server" Text="Nombre Alarma"></asp:Label>
        &nbsp;
        <asp:TextBox ID="txtNombreAlarm0" runat="server" Width="157px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
            ControlToValidate="txtNombreAlarm0" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                  <br />
                  <br />
                  <asp:Label ID="Label6" runat="server" style="font-weight: 700" 
            Text="Rango de Magnitud"></asp:Label>
                  <br />
                  <br />
                  <asp:Label ID="Label7" runat="server" Text="Desde"></asp:Label>
        &nbsp;<asp:TextBox ID="txtDesde0" runat="server" Width="27px"></asp:TextBox>
        <filteredtextboxextender id="txtDesde0_FilteredTextBoxExtender" runat="server" 
            enabled="True" filtertype="Numbers, Custom" targetcontrolid="txtDesde0" 
            validchars="."></filteredtextboxextender>
        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
            ControlToValidate="txtDesde0" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        &nbsp;
        <asp:Label ID="Label8" runat="server" Text="Hasta"></asp:Label>
        &nbsp;<asp:TextBox ID="txtHasta0" runat="server" Width="27px"></asp:TextBox>
        <filteredtextboxextender id="txtHasta0_FilteredTextBoxExtender" runat="server" 
            enabled="True" filtertype="Numbers, Custom" targetcontrolid="txtHasta0" 
            validchars="."></filteredtextboxextender>
        &nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
            ControlToValidate="txtHasta0" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                  <br />
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;</div>
    <div class="modal-footer">
        <asp:LinkButton ID="LinkButton4" runat="server" class="btn btn-primary" 
            onclick="LinkButton4_Click">Guardar Cambios</asp:LinkButton>
        <a class="btn" href="NivelesSeguridad.aspx">Cerrar</a>
                
               <!--- <a href="#" class="btn btn-primary">Save changes</a> -->
              </div>
</asp:Panel>
<p>
        &nbsp;</p>
<asp:Panel ID="Panelmodal1" runat="server" 
    style="display: list-item; background: white; width: 40%; height: auto">
    <div class="modal-header">
        <button aria-hidden="true" class="close" data-dismiss="modal" type="button">
            ×
        </button>
        <h3>
            Mostrar Alarmas</h3>
    </div>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:ListBox ID="Lbmostrar0" runat="server" Height="116px" 
        onload="Lbmostrar0_Load" 
         Width="212px">
    </asp:ListBox>
    <div class="modal-footer">
        <a class="btn" href="NivelesSeguridad.aspx">Cerrar</a>
    </div>
</asp:Panel>
<p>
        &nbsp;</p>
<asp:Panel ID="Panelmodal2" runat="server" 
    style="display: list-item; background: white; width: 40%; height: auto">
    <div class="modal-header">
        <button aria-hidden="true" class="close" data-dismiss="modal" type="button">
            ×
        </button>
        <h3>
            Eliminar Alarmas</h3>
    </div>
    <div class="modal-body">
        <asp:ListBox ID="lbEliminar0" runat="server" Height="116px" 
            SelectionMode="Single" Width="212px"></asp:ListBox>
                    <br />
                    <br />
                    <br />

                   
                </div>
    <div class="modal-footer">
        <asp:LinkButton ID="LinkButton5" runat="server" class="btn btn-primary" 
            onclick="btnBodyOk_Click">Eliminar</asp:LinkButton>
        <a class="btn" href="NivelesSeguridad.aspx">Cerrar</a>
    </div>
</asp:Panel>
<p>
        &nbsp;</p>
<p>
        &nbsp;</p>
</asp:Content>
