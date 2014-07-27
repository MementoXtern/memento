<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApp._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class='splash'>
        <h2 class='title'>
            A Whole New Way to Reward Employees.
        </h2>

        <p class='splash-text'>
            This is Memento. A new Human Relations utility for automating gifts on special occasions. Do 30 of your employees have a birthday this Friday? No problem. They'll be receiving personalized messages and gifts right on time. Happy employees mean more productive employees, so adopt Memento today and start boosting your profits.
        </p>
        <p class='inputs'>

            <asp:Button ID="btnCreateAccount" class='red-gradient' runat="server" Text="Create Account" OnClick="btnCreateAccount_Click" />
            <asp:Button ID="btnLogin" class='red-gradient' runat="server" Text="Login" OnClick="btnLogin_Click" />

        </p>
    </div>
</asp:Content>
