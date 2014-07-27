<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="WebApp.CreateAccount" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class='splash'>
        <h2 class='title'>Create an Account </h2>
        <div class='field'>
            <p class='splash-text'>Company Name: </p>
            <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
        </div>
        <div class='field'>
            <p class='splash-text'>Billing Address: </p>
            <asp:TextBox ID="txtBillingAddress" runat="server"></asp:TextBox>
        </div>
        <div class='field'>
            <p class='splash-text'>Shipping Address:</p> 
            <asp:TextBox ID="txtShippingAddress" runat="server"></asp:TextBox>
        </div>
        <div class='field'>
             <p class='splash-text'>Contact Email: </p>
            <asp:TextBox ID="txtContactEmail" runat="server"></asp:TextBox>
        </div>
        <div class='field'>
             <p class='splash-text'>Username: </p>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        </div>
        <div class='field'>
             <p class='splash-text'>Password: </p>
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        </div>
        <div class='inputs'>
            <asp:Button ID="btnSubmit" class='red-gradient' runat="server" Text="Submit" />
        </div>
    </div>
</asp:Content>
