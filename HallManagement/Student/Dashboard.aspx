<%@ Page Title="Your personal info" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="HallManagement.Student.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <p class="panel-heading" style="font-size: 40px; background-color: #004256; color: white"><%: Title %></p>
            <div class="form-horizontal panel-body" style="background-color: #f4f4f4">
                <br />
                <div class="form-group">
                    <label class="col-md-4 text-right">Name :</label>
                    <div class="col-md-8">
                        <label id="lblFullName" runat="server"></label>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-4 text-right">Student ID :</label>
                    <div class="col-md-8">
                        <label id="lblStudentID" runat="server"></label>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-4 text-right">Batch :</label>
                    <div class="col-md-8">
                        <label id="lblBatch" runat="server"></label>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-4 text-right">Discipline :</label>
                    <div class="col-md-8">
                        <label id="lblDiscipline" runat="server"></label>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-4 text-right">Hall :</label>
                    <div class="col-md-8">
                        <label id="lblHall" runat="server"></label>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-4 text-right">Room No :</label>
                    <div class="col-md-8">
                        <label id="lblRoomNo" runat="server"></label>
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
                    <label class="col-md-4 text-right">Blood Group :</label>
                    <div class="col-md-8">
                        <label id="lblBloodGroup" runat="server"></label>
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
                <div class="form-group">
                    <label class="col-md-4 text-right">Local Guardian's Name :</label>
                    <div class="col-md-8">
                        <label id="lblLocalGuardianName" runat="server"></label>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-4 text-right">Local Guardian's Address :</label>
                    <div class="col-md-8">
                        <label id="lblLocalGuardianAddress" runat="server"></label>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-4 text-right">Local Guardian's Phone Number :</label>
                    <div class="col-md-8">
                        <label id="lblLocalGuardianPhoneNo" runat="server"></label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
