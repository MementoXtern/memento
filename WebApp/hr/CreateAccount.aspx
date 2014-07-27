<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="WebApp.CreateAccount" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        Company Name: <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
        <br />
        Billing Address: <asp:TextBox ID="txtBillingAddress" runat="server"></asp:TextBox>
        <br />
        Shipping Address: <asp:TextBox ID="txtShippingAddress" runat="server"></asp:TextBox>
        <br />
        Contact Email: <asp:TextBox ID="txtContactEmail" runat="server"></asp:TextBox>
        <br />
        Username: <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        <br />
        Password: <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        <br/>
        
    </p>
</asp:Content>
