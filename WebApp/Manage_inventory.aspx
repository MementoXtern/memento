<%@ Page Title="Manage Inventory" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage_inventory.aspx.cs" Inherits="WebApp.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="new-item-container">
    <h3>New Item</h3>
        <div class="new-item-input">
            <asp:Label ID="nameLabel" runat="server" Text="Item Name:"></asp:Label>
            <asp:TextBox ID="newItemNameText" runat="server" 
                ontextchanged="TextBox1_TextChanged" Height="19px" Width="258px"></asp:TextBox>
            <br />
            <asp:Label ID="priceLabel" runat="server" Text="Item Price:"></asp:Label>
            <asp:TextBox ID="newItemPriceText" runat="server" 
                ontextchanged="newItemPrice_TextChanged" Height="19px" Width="258px"></asp:TextBox>
        </div>
        <button type="button" class="btn btn-primary">Add Item</button>
    </div>
    
    <div class="existing-items-table">
        <asp:GridView ID="GridView1" runat="server" 
            onselectedindexchanged="GridView1_SelectedIndexChanged1" Width="449px">
            <Columns>
                <asp:CheckBoxField AccessibleHeaderText="Checkbox" HeaderText="Checkbox" />
                <asp:BoundField DataField="hello" HeaderText="Item" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
