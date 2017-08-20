<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="HallManagement.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <br />
        <p class="text-left" style="font-size: 40px; color: #0d5166"><%: Title %></p>
        <hr />
    </div>
    <br />
    <div class="container-fluid">
        <div class="row">   
            <div class="panel col-md-5" style="background-color: #f4f4f4;">
                <div class="form-horizontal panel-body">
                    <textarea id="txtAddress" runat="server" readonly="readonly" class="form-control" style="height: 200px; background-color:#f4f4f4; overflow-y: auto; font-size:17px; color:darkcyan"></textarea>
                    <br />
                    <br />
                    <address>
                        <strong style="font-size:medium">Support :&nbsp</strong><a id="hrefSupport" runat="server" style="font-size:medium"></a>
                        <br />
                        <br />
                        <strong style="font-size: medium">Contact No :&nbsp</strong><a id="hrefContact" runat="server"></a>
                    </address>
                </div>
            </div>
            <div class="panel col-md-6 col-md-offset-1 ">
                <asp:Literal ID="ltlContactImage" runat="server" />
            </div>
        </div>
    </div>
    <br />
    <br />
</asp:Content>
