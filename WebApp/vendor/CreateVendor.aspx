<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateVendor.aspx.cs" Inherits="WebApp.vendor.CreateVendor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class='login splash'>
    <h2 class="title">Create Vendor Account</h2>
    <p class="username field">
    Vendor Name: <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
    <br />
    Email Address: <asp:TextBox ID="txtShippingAddress" runat="server"></asp:TextBox>
    <br />
    Billing Address: <asp:TextBox ID="txtBillingAddress" runat="server"></asp:TextBox>
    <br />
    Username: <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
    <br />
    Password: <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
    </p>
    </div>
</asp:Content>
