<%@ Page Title="Vendor Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vendor_home.aspx.cs" Inherits="WebApp.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        $(document).ready(function () {
            $('#calendar').fullCalendar({});
        });
    </script>
    <button type="button" class="btn btn-primary" id="manageInvBtn">Manage Inventory</button>
    <div id="calendar"></div>
</asp:Content>
