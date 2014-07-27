<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApp.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class='login splash'>
        <h2 class='title'>Login</h2>
        <p class='username field'>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        </p>
        <p class='password field'>
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        </p>
        <p class='incorrect-login'>
            <asp:Literal ID="litLoginError" runat="server" Text="" />
        </p>
        <p class='inputs'>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                onclick="btnSubmit_Click" />
        </p>
    </div>
</asp:Content>
