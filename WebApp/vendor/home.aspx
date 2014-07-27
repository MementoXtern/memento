<%@ Page Title="Vendor Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="WebApp.vendor.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        $(document).ready(function () {
            var current_event = null;
            var event_visual = null;
            var completedColor = 'green';
            var incompleteColor = 'rgb(58, 135, 173)';
            $('#calendar').fullCalendar({
                events: {
                    url: '/webservice/webservice.asmx/GetEvents',
                    type: 'POST'
                },
                eventRender: function (event, element) {
                    console.log('Element being rendered: ' + JSON.stringify(event));
                    if (event.isComplete) {
                        $(element).css('background-color', completedColor);
                    }
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
                if ($(event_visual).css('background-color') === incompleteColor) {
                    $(event_visual).css('background-color', completedColor);
                    current_event.isComplete = true;
                }
                else {
                    $(event_visual).css('background-color', incompleteColor);
                    current_event.isComplete = false;
                }


            });

            $('#modalSave').click(function () { //Send updated event to db
                var id = current_event.id;
                console.log('posting: ' + current_event.isComplete);
                $.ajax({
                    url: "/webservice/webservice.asmx/CompleteEvent",
                    type: "POST",
                    data: { eventId: current_event.id, isComplete: current_event.isComplete }
                });
            });
        });

       
    </script>
    <div style="background-color: whitesmoke">
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
                <button type="button" class="btn btn-default" data-dismiss="modal" id="modalSave">Save</button>
                <button type="button" class="btn btn-primary" id="completeEventBtn">Toggle complete</button>
            </div>
        </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->
    </div>
</asp:Content>
