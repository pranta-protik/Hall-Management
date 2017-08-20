<%@ Page Title="Edit Hall Authority Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditHallAuthority.aspx.cs" Inherits="HallManagement.Admin.EditHallAuthority" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="panel panel-heading col-md-7 col-md-offset-2">
            <p style="font-size: 40px; color: #0d5166"><%: Title %></p>
            <h4 class="text-success" id="sMessage" runat="server"></h4>
            <h4 class="text-danger" id="eMessage" runat="server"></h4>
            <h4 class="text-danger" id="eMessage2" runat="server"></h4>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%:sMessage.ClientID %>').delay(5000).fadeOut(1000);
            $('#<%:eMessage.ClientID %>').delay(5000).fadeOut(1000);
        });
    </script>
    <%-- <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>--%>
    <div class="row">
        <%--<h4>Apply for seat</h4>--%>
        <div class="panel col-md-7 col-md-offset-2" style="background-color: #f4f4f4">
            <div class="form-horizontal panel-body">
                <br />
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="firstName" CssClass="col-md-3 control-label pad">First Name *</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="firstName" CssClass="form-control" TextMode="SingleLine" AutoPostBack="false" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="firstName"
                            CssClass="text-danger" ErrorMessage="The first name field is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="lastName" CssClass="col-md-3 control-label pad">Last Name *</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="lastName" CssClass="form-control" TextMode="SingleLine" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="lastName"
                            CssClass="text-danger" ErrorMessage="The last name is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="designation" CssClass="col-md-3 control-label pad">Designation *</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="designation" CssClass="form-control" TextMode="SingleLine" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="designation"
                            CssClass="text-danger" ErrorMessage="The designation is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="position" CssClass="col-md-3 control-label pad">Position *</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="position" CssClass="form-control" TextMode="SingleLine" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="position"
                            CssClass="text-danger" ErrorMessage="The position is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="fathersName" CssClass="col-md-3 control-label pad">Father's Name *</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="fathersName" CssClass="form-control" TextMode="SingleLine" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="fathersName"
                            CssClass="text-danger" ErrorMessage="The father's name is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="mothersName" CssClass="col-md-3 control-label pad">Mother's Name *</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="mothersName" CssClass="form-control" TextMode="SingleLine" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="mothersName"
                            CssClass="text-danger" ErrorMessage="The mother's name is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Sex" CssClass="col-md-3 control-label pad">Gender *</asp:Label>
                    <div class="col-md-6">
                        <asp:DropDownList runat="server" ID="Sex" CssClass="form-control" Style="max-width: 280px">
                            <asp:ListItem Text="Female" Value="Female" />
                            <asp:ListItem Text="Male" Value="Male" />
                            <asp:ListItem Text="Other" Value="Other" />
                        </asp:DropDownList>
                    </div>
                </div>
                <br />
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="birthdate" CssClass="col-md-3 control-label pad">Date of Birth *</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="birthdate" CssClass="form-control" TextMode="Date" Style="max-width: 280px" />
                        <asp:RequiredFieldValidator ErrorMessage="The birthdate is required" CssClass="text-danger" ControlToValidate="birthdate" runat="server" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ddlHall" CssClass="col-md-3 control-label pad">Hall *</asp:Label>
                    <div class="col-md-6">
                        <asp:DropDownList AutoPostBack="false" ID="ddlHall" Style="max-width: 280px" CssClass="form-control" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlHall"
                            CssClass="text-danger" ErrorMessage="The hall is required." Display="Dynamic" />
                    </div>
                </div>
               <br />
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="userName" CssClass="col-md-3 control-label pad">Username *</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="userName" CssClass="form-control" TextMode="SingleLine" ReadOnly="true" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="userName"
                            CssClass="text-danger" ErrorMessage="The username is required." />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-3 control-label pad">Email *</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" Display="Dynamic"
                            CssClass="text-danger" ErrorMessage="The email field is required." />
                        <asp:RegularExpressionValidator CssClass="text-danger" Display="Dynamic" ErrorMessage="This is not a valid email address."
                            ControlToValidate="Email" runat="server" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$" />
                    </div>
                </div>
                <br />
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="PhoneNumber" CssClass="col-md-3 control-label pad">Phone / Mobile number *</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="PhoneNumber" CssClass="form-control" TextMode="SingleLine" AutoPostBack="false" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="PhoneNumber"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The phone number is required." />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Address" CssClass="col-md-3 control-label pad">Address*</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" Style="max-width: 280px" ID="Address" CssClass="form-control" AutoPostBack="false" TextMode="MultiLine" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Address"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The address is required." />
                    </div>
                </div>
                <br />
                <div class="form-group">
                    <div class="col-md-offset-3 col-md-6">
                        <asp:Button runat="server" OnClick="UpdateUser_Click" Text="Update" CssClass="buttons" Style="width: 100px" />
                        <button type="button" class="buttone col-md-offset-1" data-toggle="modal" data-target="#myModal">Delete</button>
                        <div class="modal fade" id="myModal" role="dialog">
                            <div class="modal-dialog">
                                <div class="modal-content" style="background-color: #f0f0f0">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    </div>
                                    <div class="modal-body">
                                        <h3>Do you really want to delete?</h3>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="buttons" runat="server" id="btnDelete" causesvalidation="false" style="width: 100px" onserverclick="btnDelete_ServerClick">Yes</button>
                                        <button type="button" class="buttone" style="width: 100px" data-dismiss="modal">No</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
