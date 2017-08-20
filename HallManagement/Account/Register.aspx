<%@ Page Title="Create account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="HallManagement.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container">
        <div class="panel panel-heading col-md-7 col-md-offset-2">
        <p style="font-size: 40px; color: #0d5166"><%: Title %></p>
        <h4 class="text-success" id="sMessage" runat="server"></h4>
        <h4 class="text-danger" id="eMessage" runat="server"></h4>
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
                <div id="divAdmin" runat="server">
                    <br />
                    <div class="form-group">
                        <asp:Label runat="server" ID="resigterAs" AssociatedControlID="ddlRegisterAs" CssClass="col-md-3 control-label pad">Register as</asp:Label>
                        <div class="col-md-6">
                            <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="ddlRegisterAs_SelectedIndexChanged" ID="ddlRegisterAs" Style="max-width: 280px" CssClass="form-control"
                                runat="server">
                                <asp:ListItem Text="Admin" Value="3" />
                                <asp:ListItem Text="Hall Authority" Value="2" />
                                <asp:ListItem Text="Student" Value="1" />
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <br />
                <div runat="server" id="divHallAuthority">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="designation" CssClass="col-md-3 control-label pad">Designation *</asp:Label>
                        <div class="col-md-6">
                            <asp:TextBox runat="server" ID="designation" CssClass="form-control" TextMode="SingleLine" AutoPostBack="false" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="designation"
                                CssClass="text-danger" ErrorMessage="The designation field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="position" CssClass="col-md-3 control-label pad">Position *</asp:Label>
                        <div class="col-md-6">
                            <asp:TextBox runat="server" ID="position" CssClass="form-control" TextMode="SingleLine" AutoPostBack="false" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="position"
                                CssClass="text-danger" ErrorMessage="The position field is required." />
                        </div>
                    </div>
                </div>
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
                <div id="divCommon" runat="server">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlHall" CssClass="col-md-3 control-label pad">Hall *</asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList AutoPostBack="true" ID="ddlHall" OnSelectedIndexChanged="ddlHall_SelectedIndexChanged" Style="max-width: 280px" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlHall"
                                        CssClass="text-danger" ErrorMessage="The hall is required." />
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div id="divStudent" runat="server">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="studentid" CssClass="col-md-3 control-label pad">Student ID *</asp:Label>
                        <div class="col-md-6">
                            <asp:TextBox runat="server" ID="studentid" CssClass="form-control" TextMode="SingleLine" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="studentid"
                                CssClass="text-danger" ErrorMessage="The Student ID is required." />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="batch" CssClass="col-md-3 control-label pad">Batch *</asp:Label>
                        <div class="col-md-6">
                            <asp:TextBox runat="server" ID="batch" CssClass="form-control" TextMode="SingleLine" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="batch"
                                CssClass="text-danger" ErrorMessage="The Batch is required." />
                        </div>
                    </div>

                    
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="applicationNo" CssClass="col-md-3 control-label pad">Application No *</asp:Label>
                        <div class="col-md-6">
                            <asp:TextBox runat="server" ID="applicationNo" CssClass="form-control" TextMode="SingleLine" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="applicationNo"
                                CssClass="text-danger" ErrorMessage="The Application No is required." />
                        </div>
                    </div>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlDiscipline" CssClass="col-md-3 control-label pad">Discipline *</asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList AutoPostBack="false" ID="ddlDiscipline" Style="max-width: 280px" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlDiscipline"
                                        CssClass="text-danger" ErrorMessage="The discipline is required." />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlRoomNo" CssClass="col-md-3 control-label pad">Room No *</asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList AutoPostBack="false" ID="ddlRoomNo" Style="max-width: 280px" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlRoomNo"
                                        CssClass="text-danger" ErrorMessage="The room number is required." />
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="userName" CssClass="col-md-3 control-label pad">Username *</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="userName" CssClass="form-control" TextMode="SingleLine" />
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
                    <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-3 control-label pad">Password *</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                            CssClass="text-danger" ErrorMessage="The password field is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-3 control-label pad">Confirm password*</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" placeholder="Write the same password again"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                        <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
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
                        <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="buttonp" Style="width: 100px" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
