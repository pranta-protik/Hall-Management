<%@ Page Title="Edit Application" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditApplication.aspx.cs" Inherits="HallManagement.Common.EditApplication" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="panel panel-heading col-md-7 col-md-offset-2">
            <p style="font-size: 40px; color: #0d5166"><%: Title %></p>
            <h4 class="text-success" id="sMessage" runat="server"></h4>
            <h4 class="text-danger" id="eMessage" runat="server"></h4>
        </div>
    </div>

    <%--<div class="jumbotron" style="background-color: white; height: 100px; padding-top: 10px">
        
    </div>--%>

    <%-- <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%:sMessage.ClientID %>').delay(5000).fadeOut(1000);
            $('#<%:eMessage.ClientID %>').delay(5000).fadeOut(1000);
        });
    </script>
    <div class="row">
        <%--<h4>Apply for seat</h4>--%>
        <div class="panel col-md-7 col-md-offset-2" style="background-color: #f4f4f4">
            <div class="form-horizontal panel-body">
                <%--<asp:ValidationSummary runat="server" CssClass="text-danger" />--%>
                <br />
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="applicationId" CssClass="col-md-3 control-label pad text-right">Application No</asp:Label>
                    <div class="col-md-6">
                        <label runat="server" id="applicationId" class="col-md-1 control-label pad text-left" style="font-size: medium"></label>
                        <%--<asp:Label runat="server" ID="applicationId" CssClass="col-md-1 control-label pad text-left" />--%>
                    </div>
                </div>
                <br />
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="firstName" CssClass="col-md-3 control-label pad text-right">First Name*</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="firstName" CssClass="form-control" TextMode="SingleLine" AutoPostBack="false" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="firstName"
                            CssClass="text-danger" ErrorMessage="The first name field is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="lastName" CssClass="col-md-3 control-label pad text-right">Last Name*</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="lastName" CssClass="form-control" TextMode="SingleLine" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="lastName"
                            CssClass="text-danger" ErrorMessage="The last name is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="fathersName" CssClass="col-md-3 control-label pad text-right">Father's Name*</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="fathersName" CssClass="form-control" TextMode="SingleLine" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="fathersName"
                            CssClass="text-danger" ErrorMessage="The father's name is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="fathersOccupation" CssClass="col-md-3 control-label pad text-right">Father's Occupation*</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="fathersOccupation" CssClass="form-control" TextMode="SingleLine" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="fathersOccupation"
                            CssClass="text-danger" ErrorMessage="The father's occupation is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="fathersYearlyIncome" CssClass="col-md-3 control-label pad text-right">Father's Yearly Income*</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="fathersYearlyIncome" CssClass="form-control" TextMode="SingleLine" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="fathersYearlyIncome"
                            CssClass="text-danger" ErrorMessage="The father's yearly income is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="mothersName" CssClass="col-md-3 control-label pad text-right">Mother's Name*</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="mothersName" CssClass="form-control" TextMode="SingleLine" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="mothersName"
                            CssClass="text-danger" ErrorMessage="The mother's name is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="mothersOccupation" CssClass="col-md-3 control-label pad text-right">Mother's Occupation*</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="mothersOccupation" CssClass="form-control" TextMode="SingleLine" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="mothersOccupation"
                            CssClass="text-danger" ErrorMessage="The mother's occupation is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="mothersYearlyIncome" CssClass="col-md-3 control-label pad text-right">Mother's Yearly Income*</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="mothersYearlyIncome" CssClass="form-control" TextMode="SingleLine" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="mothersYearlyIncome"
                            CssClass="text-danger" ErrorMessage="The mother's yearly income is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Sex" CssClass="col-md-3 control-label pad text-right">Gender*</asp:Label>
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
                    <asp:Label runat="server" AssociatedControlID="bloodGroup" CssClass="col-md-3 control-label pad text-right">Blood Group*</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="bloodGroup" CssClass="form-control" TextMode="SingleLine" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="mothersName"
                            CssClass="text-danger" ErrorMessage="The blood group is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="maritalStatus" CssClass="col-md-3 control-label pad text-right">Marital Status*</asp:Label>
                    <div class="col-md-6">
                        <asp:DropDownList runat="server" ID="maritalStatus" CssClass="form-control" Style="max-width: 280px">
                            <asp:ListItem Text="Married" Value="Married" />
                            <asp:ListItem Text="Unmarried" Value="Unmarried" />
                        </asp:DropDownList>
                    </div>
                </div>
                <br />
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="causesOfApplication" CssClass="col-md-3 control-label pad text-right">Causes of Application*</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="causesOfApplication" CssClass="form-control" TextMode="MultiLine" Style="max-width: 280px" />
                        <asp:RequiredFieldValidator ErrorMessage="The causes of application is required" CssClass="text-danger" ControlToValidate="causesOfApplication" runat="server" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="birthdate" CssClass="col-md-3 control-label pad text-right">Date of Birth*</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="birthdate" CssClass="form-control" TextMode="Date" Style="max-width: 280px" />
                        <asp:RequiredFieldValidator ErrorMessage="The birthdate is required" CssClass="text-danger" ControlToValidate="birthdate" runat="server" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="studentid" CssClass="col-md-3 control-label pad text-right">Student ID*</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="studentid" CssClass="form-control" TextMode="SingleLine" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="studentid"
                            CssClass="text-danger" ErrorMessage="The Student ID is required." />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="batch" CssClass="col-md-3 control-label pad text-right">Batch*</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="batch" CssClass="form-control" TextMode="SingleLine" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="batch"
                            CssClass="text-danger" ErrorMessage="The Batch is required." />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ltCGPA" CssClass="col-md-3 control-label pad text-right">Last Term CGPA*</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="ltCGPA" CssClass="form-control" TextMode="SingleLine" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ltCGPA"
                            CssClass="text-danger" ErrorMessage="The last term CGPA is required." />
                    </div>
                </div>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="ddlHall" CssClass="col-md-3 control-label pad text-right">Hall*</asp:Label>
                            <div class="col-md-6">
                                <asp:DropDownList AutoPostBack="true" ID="ddlHall" OnSelectedIndexChanged="ddlHall_SelectedIndexChanged" Style="max-width: 280px" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlHall"
                                    CssClass="text-danger" ErrorMessage="The hall is required." />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="ddlDiscipline" CssClass="col-md-3 control-label pad text-right">Discipline*</asp:Label>
                            <div class="col-md-6">
                                <asp:DropDownList AutoPostBack="false" ID="ddlDiscipline" Style="max-width: 280px" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlDiscipline"
                                    CssClass="text-danger" ErrorMessage="The discipline is required." />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-3 control-label pad text-right">Email*</asp:Label>
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
                    <asp:Label runat="server" AssociatedControlID="PhoneNumber" CssClass="col-md-3 control-label pad text-right">Phone / Mobile number*</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="PhoneNumber" CssClass="form-control" TextMode="SingleLine" AutoPostBack="false" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="PhoneNumber"
                            CssClass="text-danger" ErrorMessage="The phone number is required." />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="presentAddress" CssClass="col-md-3 control-label pad text-right">Present Address </asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" Style="max-width: 280px" ID="presentAddress" CssClass="form-control" AutoPostBack="false" TextMode="MultiLine" />
                    </div>
                </div>
                <br />
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="permanentAddress" CssClass="col-md-3 control-label pad text-right">Permanent Address*</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" Style="max-width: 280px" ID="permanentAddress" CssClass="form-control" AutoPostBack="false" TextMode="MultiLine" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="permanentAddress"
                            CssClass="text-danger" ErrorMessage="The permanent address is required." />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="localGuardianName" CssClass="col-md-3 control-label pad text-right">Local Guardian's Name*</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="localGuardianName" CssClass="form-control" TextMode="SingleLine" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="localGuardianName"
                            CssClass="text-danger" ErrorMessage="The local guardian's name is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="localGuardianAddress" CssClass="col-md-3 control-label pad text-right">Local Guardian's Address*</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" Style="max-width: 280px" ID="localGuardianAddress" CssClass="form-control" AutoPostBack="false" TextMode="MultiLine" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="localGuardianAddress"
                            CssClass="text-danger" ErrorMessage="The local guardian's address is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="localGuardianPhoneNo" CssClass="col-md-3 control-label pad text-right">Local Guardian's Phone Number</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="localGuardianPhoneNo" CssClass="form-control" TextMode="SingleLine" AutoPostBack="false" />
                    </div>
                </div>
                <br />
                <div class="form-group">
                    <div class="col-md-offset-3 col-md-6">
                        <asp:Button runat="server" ID="btnUpdate" OnClick="btnUpdate_Click" Text="Update" CssClass="buttons" Style="width: 100px" />
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
                        <%--<asp:Button Text="Delete" ID="btnDelete" OnClick="btnDelete_Click" CssClass="buttone col-md-offset-1" runat="server" />--%>
                    </div>
                </div>
                <br />
            </div>
        </div>
    </div>
</asp:Content>
