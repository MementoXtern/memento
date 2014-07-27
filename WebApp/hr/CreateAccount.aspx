<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="WebApp.CreateAccount" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        Please enter your product key: <asp:TextBox ID="txtProductKey" runat="server"></asp:TextBox>
        <br/>
        If you don't have a product key and would like one, please email MementoHRSoftware@gmail.com
    </p>
</asp:Content>
