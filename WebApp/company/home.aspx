<%@ Page Title="Home" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="WebApp.company.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script>
        $(document).ready(function () {
            var current_event = null;
            var event_visual = null;
            var new_title = null;
            var completedColor = 'red';
            $('#calendar').fullCalendar({
                events: {
                    url: '/webservice/webservice.asmx/GetEvents',
                    type: 'POST'
                },
                dayClick: function (date, jsEvent, view) {
                    console.log('clicked: ', date.format());
                },
                eventMouseover: function (event, jsEvent, view) {
                    $(this).css('cursor', 'pointer');
                },
                eventClick: function (event, jsEvent, view) {
                    console.log('clicked: ', JSON.stringify(event));
                    current_event = event;
                    event_visual = this;
                    $('#MementoEvent').modal('show');
                }
            });

            $('#btnCreateMemento').click(function () {
                current_event = null;
                $('#MementoEvent').modal('show');
            });

            $('#btnAddCustomObject').click(function () {
                new_title = $('#MainContent_txtEventName').val();
                $('#MementoEvent').modal('hide');
                $('#MementoCustomObject').modal('show');
            });

            $('#btnSaveMemento').click(function () {
                $('#MementoCustomObject').modal('hide');
                $('#MementoHasBeenSaved').modal('show');
                if (current_event) {
                    current_event.title = new_title;
                    $('#calendar').fullCalendar('updateEvent', current_event);
                }
                else {
                    var new_event = {};
                    new_event.title = new_title;
                    $('#calendar').fullCalendar('addEventSource', [new_event]);
                }
                //Something here to actually write Memento to DB.
            });

            $('#btnOK').click(function () {
                $('#MementoHasBeenSaved').modal('hide')
            });

            $('#completeEventBtn').click(function () {
                console.log('complete pushed for event: ' + current_event.title);
                if ($(event_visual).css('border-color') == 'rgb(58, 135, 173)') {
                    $(event_visual).css('border-color', completedColor);
                    current_event.isComplete = true;
                }
                else {
                    $(event_visual).css('border-color', 'rgb(58, 135, 173)');
                    current_event.isComplete = false;
                }
            });

            $('#modalClose').click(function () {
                $('.eventInfo').attr('disabled', true);
            });

            $('#syncBtn').click(function () {

            });
        });
    </script>

    <div id="calendar"></div>
    <p class="inputs">
    <button type="button" class="btn btn-primary" id="btnCreateMemento">Create Memento</button>
    </p>

    <div class="modal fade" id="MementoEvent">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
        <h4 class="modal-title">Create Memento: What's happening?</h4>
      </div>
      <div class="modal-body">
        <p>What do you want to call this event?
            <asp:TextBox ID="txtEventName" runat="server"></asp:TextBox>
            <br />
            What kind of event is it?
            <asp:DropDownList ID="ddlEventType" runat="server" DataSourceID="MementoEvent" DataTextField="EventTypeName"></asp:DropDownList>
            <asp:SqlDataSource ID="MementoEvent" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>" SelectCommand="SELECT [EventTypeName] FROM [EventType]"></asp:SqlDataSource>
            </p>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Go Back</button>
        <button type="button" class="btn btn-primary" id="btnAddCustomObject">What are you sending?</button>
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->

        <div class="modal fade" id="MementoCustomObject">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
        <h4 class="modal-title">Create Memento: Vendor Options</h4>
      </div>
      <div class="modal-body">
        <p>Which vendor will you be ordering from?
          <asp:DropDownList ID="ddlVendor" runat="server" DataSourceID="MementoDB" DataTextField="VendorName"></asp:DropDownList>
            <asp:SqlDataSource ID="MementoDB" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>" SelectCommand="SELECT DISTINCT [VendorName] FROM [Vendor]"></asp:SqlDataSource>
            <br />
            What will you be ordering?
            <asp:DropDownList ID="ddlItem" runat="server" DataSourceID="MementoItem" DataTextField="ItemName"></asp:DropDownList>
            <asp:SqlDataSource ID="MementoItem" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnection %>" SelectCommand="SELECT [ItemName] FROM [Item]"></asp:SqlDataSource>
            <br />
            How many (per person) will you be ordering?
            <asp:TextBox ID="txtItemQuantity" runat="server"></asp:TextBox>
            <br />
            Any special instructions or customizations?
            <asp:TextBox ID="txtInstructionsCustomizations" runat="server" TextMode="MultiLine"></asp:TextBox>
            </p>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-primary" id="btnSaveMemento">Save Memento</button>
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->

            <div class="modal fade" id="MementoHasBeenSaved">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
        <h4 class="modal-title">Create Memento: Memento Saved Successfully</h4>
      </div>
      <div class="modal-body">
        <p> Your Memento has been saved. Check your calendar!
            </p>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-primary" id="btnOK">OK!</button>
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->
</asp:Content>

