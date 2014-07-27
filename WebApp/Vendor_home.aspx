<%@ Page Title="Vendor Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vendor_home.aspx.cs" Inherits="WebApp.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        $(document).ready(function () {
            $('#calendar').fullCalendar({
                events: {
                    url: 'https://www.google.com/calendar/feeds/rfptn6bo41m04d2khbjnm4eedk%40group.calendar.google.com/public/basic'
                },
                dayClick: function (date, jsEvent, view) {
                    console.log('clicked: ', date.format());
                },
                eventClick: function (event, jsEvent, view) {
                    if (event.url) { //return false so it doesn't navigate to google calendar event page
                        console.log('clicked: ', JSON.stringify(event));
                        $('.fade').modal('show');
                        return false;
                    }
                }
            });
            
            $('#editEventBtn').click(function () {
                console.log('edit pushed');
                $('.eventInfo').removeAttr('disabled');
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
            <p>Event: <input type="text" class="eventInfo" value="Event" disabled/></p>
            <p>Day: <input type="text" class="eventInfo" value="Day" disabled/></p>
            <p>Location: <input type="text" class="eventInfo" value="Location" disabled/></p>
            </div>
            <div class="modal-footer">
            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            <button type="button" class="btn btn-primary" id="editEventBtn">Edit Event</button>
            </div>
        </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->
</asp:Content>
