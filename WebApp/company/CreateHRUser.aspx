<%@ Page Title="CreateHRUser" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateHRUser.aspx.cs" Inherits="WebApp.company.CreateHRUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class='login splash'>
    <h2 class="title">Create HR User Account</h2>
    <p class="username field">
    Company Name: <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
    <br />
    Shipping Address: <asp:TextBox ID="txtShippingAddress" runat="server"></asp:TextBox>
    <br />
    Billing Address: <asp:TextBox ID="txtBillingAddress" runat="server"></asp:TextBox>
    <br />
    Contact Email: <asp:TextBox ID="txtContactEmail" runat="server"></asp:TextBox>
    <br />
    Username: <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
    <br />
    Password: <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
    </p>
    </div>

</asp:Content>
