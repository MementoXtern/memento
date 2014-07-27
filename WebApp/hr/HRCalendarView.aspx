<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HRCalendarView.aspx.cs" Inherits="WebApp.hr.HRCalendarView" %>
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
            
            $('#btnCreateMemento').click(function () {
                $('.fade').modal('show')
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

    <button type="button" id="btnCreateMemento">Create Memento</button>

    <div class="modal fade">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
        <h4 class="modal-title">Modal title</h4>
      </div>
      <div class="modal-body">
        <p>One fine body&hellip;</p>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->
</asp:Content>
