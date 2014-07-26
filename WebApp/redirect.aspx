<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="redirect.aspx.cs" Inherits="WebApp.redirect" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<p>
    Your session has ended or you do not have access to this page. <a href="login.aspx" title="Login">Click here</a> to login again.
</p>
</asp:Content>
