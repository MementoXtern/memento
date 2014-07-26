<%@ Page Title="Request Key" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RequestKey.aspx.cs" Inherits="WebApp.RequestKey" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Product Key</h2>
    <p>
        Please enter the product key: <asp:TextBox ID="txtKeyRequest" runat="server"></asp:TextBox>
        <br />
        If you don't have a product key and would like one, please contact MementoHRSoftware@gmail.com.
    </p>
</asp:Content>
