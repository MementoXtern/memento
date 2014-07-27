<%@ Page Title="Manage Inventory" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="manage_inventory.aspx.cs" Inherits="WebApp.Manage_Inventory" %>
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
        function addItemBtn_onclick() {

        }

    </script>
    <div style="background-color: whitesmoke">
    <div class="new-item-container">
    <h3>New Item</h3>
        <div class="new-item-input">
            <asp:Label ID="nameLabel" runat="server" Text="Item Name:"></asp:Label>
            <asp:TextBox ID="newItemNameText" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="priceLabel" runat="server" Text="Item Price:"></asp:Label>
            <asp:TextBox ID="newItemPriceText" runat="server" CausesValidation="true" ></asp:TextBox>
            <asp:RangeValidator
                ID="RangeValidator1" runat="server" ErrorMessage="Must be a decimal" 
                Type="Double" ControlToValidate="newItemPriceText"></asp:RangeValidator>
        </div>
        <asp:Button
            ID="addItemBtn" CssClass="btn btn-primary" runat="server" Text="Add Item" 
            onclick="addItemBtn_Click" />
    </div>
    
    
    <div class="existing-items-table">
    <!--
        <asp:GridView ID="GridView1" runat="server" 
            onselectedindexchanged="GridView1_SelectedIndexChanged1" Width="449px" 
            AutoGenerateColumns="False" DataSourceID="SqlDataSource1" 
            OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:BoundField DataField="ItemName" HeaderText="ItemName" 
                    SortExpression="ItemName" />
                <asp:BoundField DataField="ItemDesc" HeaderText="ItemDesc" 
                    SortExpression="ItemDesc" />
                <asp:BoundField DataField="ItemProcessingTime" HeaderText="ItemProcessingTime" 
                    SortExpression="ItemProcessingTime" />
                <asp:BoundField DataField="ItemPrice" HeaderText="ItemPrice" 
                    SortExpression="ItemPrice" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        -->
        <asp:Button ID="btnRemoveItem" runat="server" Text="Remove Item" 
            onclick="btnRemoveItem_Click" />
        <asp:ListBox ID="lbInventory" runat="server" DataSourceID="SqlDataSource1" 
            DataTextField="ItemName" DataValueField="ItemPrice" Height="113px" 
            Width="517px"></asp:ListBox>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DBConnection %>" 
            SelectCommand="SELECT [ItemName], [ItemDesc], [ItemProcessingTime], [ItemPrice] FROM [Item] WHERE ([VendorID] = @VendorID)">
            <SelectParameters>
                <asp:SessionParameter Name="VendorID" SessionField="AccountId" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div></div>

</asp:Content>
