<%@ Page Title="Manage your website" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageWebsite.aspx.cs" Inherits="HallManagement.Admin.ManageWebsite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .button {
            border-radius: 4px;
            background-color: #0d5166;
            border: none;
            color: #FFFFFF;
            text-align: center;
            font-size: 28px;
            padding: 10px;
            width: 500px;
            transition: all 0.5s;
            cursor: pointer;
            margin: 5px;
        }

        .button span {
            cursor: pointer;
            display: inline-block;
            position: relative;
            transition: 0.5s;
        }

        .button span:after {
            content: '\00bb';
            position: absolute;
            opacity: 0;
            top: 0;
            right: -20px;
            transition: 0.5s;
        }

        .button:hover span {
            padding-right: 25px;
        }

        .button:hover span:after {
            opacity: 1;
            right: 0;
        }
    </style>

    <div class="row">
        <br />
        <div class=" col-md-12">
            <p class="panel-heading" style="font-size: 40px; color: #0d5166"><span class="glyphicon glyphicon-pencil" style="font-size: xx-large; color: #0d5166; padding-right: 10px"></span><%: Title %></p>
            <hr />
            <div class="form-horizontal panel-body" style="background-color: #f4f4f4;">
                <br />
                <div class="row">
                    <div class="panel col-md-6" style="background-color: #f4f4f4;">
                        <br />
                        <div class="panel col-md-12 text-center" style="background-color: #0d5166; min-height: 120px; padding-top: 25px">
                            <%--<span class="glyphicon glyphicon-user" style="color: white; font-size: x-large; padding-right: 10px"></span>--%>
                            <button type="button" id="btnEditAccount" onserverclick="btnEditAccount_ServerClick" runat="server" class="button"><p class="glyphicon glyphicon-user" style="color: white; font-size: x-large; padding-right: 10px"></p><span>Edit Accounts </span></button>
                           <%-- <asp:LinkButton ID="lnkEditAccount" OnClick="lnkEditAccount_Click" Text="Edit Accounts >>" ForeColor="White" runat="server" Font-Size="X-Large" />--%>
                        </div>
                        <br />
                        <div class="panel col-md-12 text-center" style="background-color: #0d5166; min-height: 120px; padding-top: 25px">
                            <button type="button" id="btnEditHome" onserverclick="btnEditHome_ServerClick" runat="server" class="button"><p class="glyphicon glyphicon-home" style="color: white; font-size: x-large; padding-right: 10px"></p><span>Edit Home Page </span></button>
                            <%--<span class="glyphicon glyphicon-home" style="color: white; font-size: x-large; padding-right: 10px"></span>
                            <asp:LinkButton ID="lnkEditHome" OnClick="lnkEditHome_Click" Text="Edit Home Page >>" ForeColor="White" runat="server" Font-Size="X-Large" />--%>
                        </div>

                    </div>
                    <div class="panel col-md-6" style="background-color: #f4f4f4;">
                        <br />
                        <div class="panel col-sm-12 text-center" style="background-color: #0d5166; min-height: 120px; padding-top: 25px">
                            <button type="button" id="btnEditNewsNotice" onserverclick="btnEditNewsNotice_ServerClick" runat="server" class="button"><p class="glyphicon glyphicon-file" style="color: white; font-size: x-large; padding-right: 6px"></p><span>Edit News & Notice </span></button>
                            <%--<span class="glyphicon glyphicon-file" style="color: white; font-size: x-large; padding-right: 10px"></span>
                            <asp:LinkButton ID="lnkEditNewsNotice" OnClick="lnkEditNewsNotice_Click" Text="Edit News & Notice >>" ForeColor="White" runat="server" Font-Size="X-Large" />--%>
                        </div>
                        <br />
                        <div class="panel col-sm-12 text-center" style="background-color: #0d5166; min-height: 120px; padding-top: 25px">
                            <button type="button" id="btnEditHistoryContact" onserverclick="btnEditHistoryContact_ServerClick" runat="server" class="button"><p class="glyphicon glyphicon-envelope" style="color: white; font-size: x-large; padding-right: 10px"></p><span>Edit History & Contact </span>
                            </button>
                           <%-- <span class="glyphicon glyphicon-envelope" style="color: white; font-size: x-large; padding-right: 10px"></span>
                            <asp:LinkButton ID="lnkEditHistoryContact" OnClick="lnkEditHistoryContact_Click" Text="Edit History & Contact >>" ForeColor="White" runat="server" Font-Size="X-Large" />--%>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />
    <br />
</asp:Content>
