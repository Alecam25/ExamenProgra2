<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Tecnico.aspx.cs" Inherits="ExamenPrograWeb.Tecnico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
        <h1>TECNICO </h1>
  
         
     <p>&nbsp;</p>
      </div>

    <div>
        <br />
        <br />
        <asp:GridView runat="server" ID="datagrid" PageSize="10" HorizontalAlign="Center"
            CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
            RowStyle-CssClass="rows" AllowPaging="True" />

    <div class="container text-center">
        Nombre: <asp:TextBox ID="tNombre" class="form-control" runat="server" ></asp:TextBox>
        Especialidad: <asp:TextBox ID="tEspecialidad" class="form-control" runat="server"></asp:TextBox>
        IDtecnicos: <asp:TextBox ID="tIDtecnicos" class="form-control" runat="server"></asp:TextBox>
    </div>

        <br />
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
