<%@ Page Title="Export" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Export.aspx.cs" Inherits="HallManagement.Common.Export" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .button {
            border-radius: 4px;
            background-color: #0d5166;
            border: none;
            color: #FFFFFF;
            text-align: center;
            font-size: 37px;
            padding: 15px;
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
            <p class="panel-heading" style="font-size: 40px; color: #0d5166"><span class="glyphicon glyphicon-send" style="font-size: xx-large; color: #0d5166; padding-right: 10px"></span><%: Title %></p>
            <hr />
            <br />
            <br />
            <div class="form-horizontal panel-body" style="background-color: #f4f4f4;">
                <br />
                <div class="row">
                    <div class="panel col-md-6" style="background-color: #f4f4f4;">
                        <br />
                        <div class="panel col-md-12 text-center" style="background-color: #0d5166; min-height: 150px; padding-top: 30px">
                            <%--<span class="glyphicon glyphicon-user" style="color: white; font-size: x-large; padding-right: 10px"></span>--%>
                            <button type="button" id="btnApplication" onserverclick="btnApplication_ServerClick" runat="server" class="button">
                                <p class="glyphicon glyphicon-list-alt" style="color: white; font-size: xx-large; padding-right: 5px"></p>
                                <span>Application </span>
                            </button>
                            <%-- <asp:LinkButton ID="lnkEditAccount" OnClick="lnkEditAccount_Click" Text="Edit Accounts >>" ForeColor="White" runat="server" Font-Size="X-Large" />--%>
                        </div>
                    </div>
                    <br />
                    <div class="panel col-md-6" style="background-color: #f4f4f4;">
                        <div class="panel col-sm-12 text-center" style="background-color: #0d5166; min-height: 150px; padding-top: 30px">
                            <button type="button" id="btnAccount" onserverclick="btnAccount_ServerClick" runat="server" class="button">
                                <p class="glyphicon glyphicon-user" style="color: white; font-size: xx-large; padding-right: 5px"></p>
                                <span>Account </span>
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
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
