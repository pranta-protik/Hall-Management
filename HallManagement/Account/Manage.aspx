<%@ Page Title="Manage your account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="HallManagement.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
   
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%: sMessage.ClientID %>').delay(5000).fadeOut(1000);
            $('#<%: eMessage.ClientID %>').delay(5000).fadeOut(1000);
        });
    </script>
    <div class="panel col-md-offset-2 col-md-8">
        <p class="panel-heading" style="font-size: 40px; color: #0d5166"><%: Title %></p>
        <h4 class="panel-heading text-success" id="sMessage" runat="server"></h4>
        <h4 class="panel-heading text-danger" id="eMessage" runat="server"></h4>
        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
            <h4 class="panel-heading text-success"><%: SuccessMessage %></h4>
        </asp:PlaceHolder>
    </div>
    
    <div class="row">
        <div class="panel col-md-offset-2 col-md-8 " style="background-color: #f4f4f4">
            <div class="form-horizontal panel-body">
                <br />
                <div class="form-group">
                    <label class="col-md-4 text-right">Username</label>
                    <div class="col-md-8">
                        <label id="lblUserName" runat="server"></label>
                    </div>
                </div>
                <br />
                
                <div id="divHallAuthority" runat="server" visible="false">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtDesignation" CssClass="col-md-4 control-label pad">Designation</asp:Label>
                        <div class="col-md-8">
                            <asp:TextBox runat="server" ID="txtDesignation" CssClass="form-control" TextMode="SingleLine" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDesignation"
                                CssClass="text-danger" ErrorMessage="The designation field is required." />
                        </div>
                    </div>               
                </div>
                <div id="divAdmin" runat="server">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtFirstName" CssClass="col-md-4 control-label pad">First Name</asp:Label>
                        <div class="col-md-8">
                            <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control" TextMode="SingleLine" />

                        </div>
                    </div>
                    <br />
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtLastName" CssClass="col-md-4 control-label pad">Last Name</asp:Label>
                        <div class="col-md-8">
                            <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control" TextMode="SingleLine" />

                        </div>
                    </div>
                    <br />
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="ddlSex" CssClass="col-md-4 control-label pad">Gender</asp:Label>
                        <div class="col-md-8">
                            <asp:DropDownList runat="server" ID="ddlSex" CssClass="form-control" Style="max-width: 280px">
                                <asp:ListItem Text="Female" Value="Female" />
                                <asp:ListItem Text="Male" Value="Male" />
                                <asp:ListItem Text="Other" Value="Other" />
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtFatherName" CssClass="col-md-4 control-label pad">Father's Name</asp:Label>
                        <div class="col-md-8">
                            <asp:TextBox runat="server" ID="txtFatherName" CssClass="form-control" TextMode="SingleLine" />

                        </div>
                    </div>
                    <br />
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtMotherName" CssClass="col-md-4 control-label pad">Mother's Name</asp:Label>
                        <div class="col-md-8">
                            <asp:TextBox runat="server" ID="txtMotherName" CssClass="form-control" TextMode="SingleLine" />
                        </div>
                    </div>
                    <br />
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtBirthdate" CssClass="col-md-4 control-label pad">Birthdate</asp:Label>
                        <div class="col-md-8">
                            <asp:TextBox runat="server" ID="txtBirthdate" CssClass="form-control" TextMode="Date" style="max-width:280px" />
                        </div>
                    </div>
                    <br />
                </div>
                <div id="divCommon" runat="server">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtEmail" CssClass="col-md-4 control-label pad">Email</asp:Label>
                        <div class="col-md-8">
                            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="SingleLine" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail"
                                CssClass="text-danger" ErrorMessage="The email field is required." />
                            <asp:RegularExpressionValidator CssClass="text-danger" ErrorMessage="This is not a valid email address."
                                ControlToValidate="txtEmail" runat="server" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtMobileNum" CssClass="col-md-4 control-label pad">Phone / Mobile number</asp:Label>
                        <div class="col-md-8">
                            <asp:TextBox runat="server" ID="txtMobileNum" CssClass="form-control" TextMode="SingleLine" />

                        </div>
                    </div>
                    <br />
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtAddress" CssClass="col-md-4 control-label pad">Address</asp:Label>
                        <div class="col-md-8">
                            <asp:TextBox runat="server" Style="max-width: 280px" ID="txtAddress" CssClass="form-control" TextMode="MultiLine" />
                        </div>
                    </div>
                    <br />
                    <div class="form-group">
                        <div class="col-md-offset-4 col-md-8">
                            <asp:Button runat="server" Text="Update" ID="btnUpdate" OnClick="btnUpdate_Click" CssClass="buttons" Style="width: 100px" />
                        </div>
                    </div>
                    <hr />
                </div>
               
                <div class="dl-horizontal">
                    <div class="form-group">
                        <label for="ChangePassword" class="col-md-4 text-right">Password</label>
                        <div class="col-md-8">
                            <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Change]" Visible="false" ID="ChangePassword" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
