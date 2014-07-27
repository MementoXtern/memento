<%@ Page Title="Create Vendor Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateVendor.aspx.cs" Inherits="WebApp.CreateVendor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <p>
        Vendor Name: <asp:TextBox ID="txtVendorName" runat="server"></asp:TextBox>
        <br />
        Vendor Email: <asp:TextBox ID="txtVendorEmail" runat="server"></asp:TextBox>
        <br />
        Username: <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        <br />
        Password: <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        <br />
    </p>
</asp:Content>
