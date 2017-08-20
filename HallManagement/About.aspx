<%@ Page Title="History" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="HallManagement.About" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <br />
        <p class="text-left" style="font-size: 40px; color: #0d5166"><%: Title %></p>
        <hr />
    </div>
    <br />
    <div class="container-fluid">
        <div class="row">
            <div class="panel col-md-6 ">
                <asp:Literal ID="ltlHistoryImage" runat="server" />
            </div>
            <div class="panel col-md-5 col-md-offset-1" style="background-color: #f4f4f4;">
                <h3 class="panel-heading text-center" style="color: #03707b"><strong><%: lblHeading.InnerText %></strong></h3>
                <div class="form-horizontal panel-body">
                    <label id="lblHeading" runat="server" visible="false"></label>
                    <textarea id="txtDescription" runat="server" readonly="readonly" class="form-control" style="height: 325px; overflow-y: auto;background-color:#f4f4f4"></textarea>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
