<%@ Page Title="Manage your password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManagePassword.aspx.cs" Inherits="HallManagement.Account.ManagePassword" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel col-md-offset-2 col-md-8">
        <p class="panel-heading" style="font-size: 40px; color: #0d5166"><%: Title %></p>
        <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" style="font-size:18px" />
    </div>
    <div class="form-horizontal">
        <section id="passwordForm">
            <asp:PlaceHolder runat="server" ID="setPassword" Visible="false">
                <p>
                    You do not have a local password for this site. Add a local
                        password so you can log in without an external login.
                </p>
                <div class="form-horizontal">
                    <h4>Set Password Form</h4>
                    <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
                    <hr />
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="password" CssClass="col-md-2 control-label">Password</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="password" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="password"
                                CssClass="text-danger" ErrorMessage="The password field is required."
                                Display="Dynamic" ValidationGroup="SetPassword" />
                            <asp:ModelErrorMessage runat="server" ModelStateKey="NewPassword" AssociatedControlID="password"
                                CssClass="text-danger" SetFocusOnError="true" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="confirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="confirmPassword" TextMode="Password"  CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="confirmPassword"
                                CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required."
                                ValidationGroup="SetPassword" />
                            <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="confirmPassword"
                                CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match."
                                ValidationGroup="SetPassword" />

                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" Text="Set Password" ValidationGroup="SetPassword" OnClick="SetPassword_Click" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
            </asp:PlaceHolder>

            <asp:PlaceHolder runat="server" ID="changePasswordHolder" Visible="false">
                <div class="row">
                    <div class="panel col-md-offset-2 col-md-8 " style="background-color: #f4f4f4">
                        <div class="form-horizontal panel-body">
                            <%--<h4>Change Password Form</h4>--%>
                            
                            <br />
                            <div class="form-group">
                                <asp:Label runat="server" ID="CurrentPasswordLabel" AssociatedControlID="CurrentPassword" CssClass="col-md-4 control-label">Current password</asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox runat="server" ID="CurrentPassword" TextMode="Password" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="CurrentPassword"
                                        CssClass="text-danger" ErrorMessage="The current password field is required."
                                        ValidationGroup="ChangePassword" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" ID="NewPasswordLabel" AssociatedControlID="NewPassword" CssClass="col-md-4 control-label">New password</asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox runat="server" ID="NewPassword" TextMode="Password" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="NewPassword"
                                        CssClass="text-danger" ErrorMessage="The new password is required."
                                        ValidationGroup="ChangePassword" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" ID="ConfirmNewPasswordLabel" AssociatedControlID="ConfirmNewPassword" CssClass="col-md-4 control-label">Confirm new password</asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox runat="server" ID="ConfirmNewPassword" TextMode="Password" placeholder="Write the same password again" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmNewPassword"
                                        CssClass="text-danger" Display="Dynamic" ErrorMessage="Confirm new password is required."
                                        ValidationGroup="ChangePassword" />
                                    <asp:CompareValidator runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The new password and confirmation password do not match."
                                        ValidationGroup="ChangePassword" />
                                </div>
                            </div>
                            <br />
                            <div class="form-group">
                                <div class="col-md-offset-4 col-md-8">
                                    <asp:Button runat="server" Text="Change Password" ValidationGroup="ChangePassword" OnClick="ChangePassword_Click" CssClass="buttons" Width="170px"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:PlaceHolder>
        </section>
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
