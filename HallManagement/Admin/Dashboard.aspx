<%@ Page Title="Your personal info" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="HallManagement.Admin.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <%--<br />--%>
        <div class="col-md-8 col-md-offset-2">
            <p class="panel-heading" style="font-size: 40px; background-color: #004256; color: white"><%: Title %></p>
            <%--<hr />--%>
            <div class="form-horizontal panel-body" style="background-color: #f4f4f4">
                <br />
                <div class="form-group">
                    <label class="col-md-4 text-right">Name :</label>
                    <div class="col-md-8">
                        <label id="lblFullName" runat="server"></label>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-4 text-right">Father's Name :</label>
                    <div class="col-md-8">
                        <label id="lblFathersName" runat="server"></label>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-4 text-right">Mother's Name :</label>
                    <div class="col-md-8">
                        <label id="lblMothersName" runat="server"></label>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-4 text-right">Gender :</label>
                    <div class="col-md-8">
                        <label id="lblSex" runat="server"></label>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-4 text-right">Birthdate :</label>
                    <div class="col-md-8">
                        <label id="lblBirthdate" runat="server"></label>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-4 text-right">Email :</label>
                    <div class="col-md-8">
                        <label id="lblEmail" runat="server"></label>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-4 text-right">Mobile Number :</label>
                    <div class="col-md-8">
                        <label id="lblPhoneNo" runat="server"></label>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-4 text-right">Address :</label>
                    <div class="col-md-8">
                        <label id="lblAddress" runat="server"></label>
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
</asp:Content>
