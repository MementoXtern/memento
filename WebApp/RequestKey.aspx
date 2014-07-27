<%@ Page Title="Request Key" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RequestKey.aspx.cs" Inherits="WebApp.RequestKey" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class='title'>Product Key</h2>
    <p class='splash-text'>
        Please enter the product key: <asp:TextBox ID="txtKeyRequest" runat="server"></asp:TextBox>
    </p>
    <p class='splash-text'>
        If you don't have a product key and would like one, please contact MementoHRSoftware@gmail.com.
    </p>
</asp:Content>
