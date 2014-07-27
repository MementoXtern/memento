<%@ Page Title="Vendor Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vendor_home.aspx.cs" Inherits="WebApp.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        $(document).ready(function () {
            var current_event = null;
            var event_visual = null;
            var completedColor = 'red';
            $('#calendar').fullCalendar({
                events: {
                    url: '/webservice/webservice.asmx/GetEvents',
                    type: 'POST'
                },
                dayClick: function (date, jsEvent, view) {
                    console.log('clicked: ', date.format());
                },
                eventMouseOver: function (event, jsEvent, view) {

                },
                eventClick: function (event, jsEvent, view) {
                    console.log('clicked: ', JSON.stringify(event));
                    current_event = event;
                    event_visual = this;
                    $('#eventInfoTitle').html('Event: ' + event.title);
                    $('#eventInfoOrigin').html('Ordered by: ' + event.originCompany);
                    $('#eventInfoDay').html('Day: ' + new Date(event.start.format()));
                    $('#eventInfoLocation').html('Location: ' + event.location);
                    $('#eventInfoItem').html('Item: ' + event.item);
                    $('#eventInfoQuantity').html('Quantity: ' + event.quantity);
                    $('.fade').modal('show');
                }
            });

            $('#completeEventBtn').click(function () {
                console.log('complete pushed for event: ' + current_event.title);
                if ($(event_visual).css('border-color') == 'rgb(58, 135, 173)') {
                    $(event_visual).css('border-color', completedColor);
                }
                else {
                    $(event_visual).css('border-color', 'rgb(58, 135, 173)');
                }
            });

            $('#modalClose').click(function () {
                $('.eventInfo').attr('disabled', true);
            });
        });

       
    </script>
    <button type="button" class="btn btn-primary" id="manageInvBtn">Manage Inventory</button>
    <div id="calendar"></div>
    
    <div class="modal fade" >
        <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                <h4 class="modal-title">Event Information</h4>
            </div>
            <div class="modal-body">
                <p id="eventInfoTitle"></p>
                <p id="eventInfoOrigin"></p>
                <p id="eventInfoDay"></p>
                <p id="eventInfoLocation"></p>
                <p id="eventInfoItem"></p>
                <p id="eventInfoQuantity"></p>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal" id="modalClose">Close</button>
                <button type="button" class="btn btn-primary" id="completeEventBtn">Toggle complete</button>
            </div>
        </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->
</asp:Content>
