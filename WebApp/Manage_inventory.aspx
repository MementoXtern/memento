<%@ Page Title="Manage Inventory" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage_inventory.aspx.cs" Inherits="WebApp.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        $(document).ready(function () {
            $('#addItemBtn').click(function () {
                var name = $('#newItemNameText').val();
                var price = $('#newItemPriceText').val();
                console.log(name + ' is ' + price);
                $('#GridView1').append('<tr><td>Item value</td><td>column2 value</td></tr>');
            });
        });
    </script>
    <div class="new-item-container">
    <h3>New Item</h3>
        <div class="new-item-input">
            <asp:Label ID="nameLabel" runat="server" Text="Item Name:"></asp:Label>
            <input type="text" id="newItemNameText" />
            <br />
            <asp:Label ID="priceLabel" runat="server" Text="Item Price:"></asp:Label>
            <input type="text" id="newItemPriceText" />
        </div>
        <button type="button" class="btn btn-primary" id="addItemBtn">Add Item</button>
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
