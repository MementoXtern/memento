<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApp.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class='login'>
        <h2 class='title'>Login</h2>
        <p class='splash-text username field'>
            <asp:TextBox ID="txtUsername" runat="server" value='Username'></asp:TextBox>
        </p>
        <p class='splash-text password field'>
            <asp:TextBox ID="txtPassword" runat="server" value='Password'></asp:TextBox>
        </p>
        <p class='inputs'>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
        </p>
    </div>
</asp:Content>
