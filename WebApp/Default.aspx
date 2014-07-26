<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApp._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Memento
    </h2>
    <p>
        This is Memento. It's sexy. We're gonna include some sexy text here that makes you want to use it.
    </p>
    <p>

        <asp:Button ID="btnCreateAccount" runat="server" Text="Create Account" />

        <asp:Button ID="btnLogin" runat="server" Text="Login" />

    </p>
</asp:Content>
