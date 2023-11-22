<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Equipo.aspx.cs" Inherits="ExamenPrograWeb.Equipo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
        <h1>EQUIPOS </h1>
  
     
     <p>&nbsp;</p>
       </div>
     
    <div>
        <br />
        <br />
        <asp:GridView runat="server" ID="datagrid" PageSize="10" HorizontalAlign="Center"
            CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
            RowStyle-CssClass="rows" AllowPaging="True" />

        <br />
    <div class="container text-center">
        UsuariosID: <asp:TextBox ID="tUsuariosID" class="form-control" runat="server" ></asp:TextBox>
        TipoEquipo: <asp:TextBox ID="tTipoEquipo" class="form-control" runat="server"></asp:TextBox>
        Modelo: <asp:TextBox ID="tModelo" class="form-control" runat="server"></asp:TextBox>
        IDEquipos: <asp:TextBox ID="tIDEquipos" class="form-control" runat="server"></asp:TextBox>
    </div>
        <br />
        <br />

    </div>
    <div class="container text-center">

        <asp:Button ID="Button1" class="btn btn-outline-primary" runat="server" Text="Agregar" OnClick="Button1_Click1" />
        <asp:Button ID="Button2" class="btn btn-outline-secondary" runat="server" Text="Borrar" OnClick="Button2_Click"  />
        <asp:Button ID="Button3" runat="server" class="btn btn-outline-danger" Text="Modificar" OnClick="Button3_Click" />
        <asp:Button ID="Bconsulta" runat="server" class="btn btn-outline-danger" Text="Consultar" OnClick="Bconsulta_Click"/>
      
    </div>
</asp:Content>
