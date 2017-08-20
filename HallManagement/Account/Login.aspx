<%@ Page Title="Sign in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HallManagement.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <%--<h2><%: Title %></h2>--%>

    <div class="panel panel-heading col-md-5 col-md-offset-3">
    <p style="font-size: 40px; color: #0d5166"><%: Title %></p>
    
    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
        <p class="text-danger">
            <asp:Literal runat="server" ID="FailureText" />
        </p>
    </asp:PlaceHolder>
    </div>
    <div class="row">
        
        <div class="col-md-5 col-md-offset-3 ">
            <div class="form-horizontal panel-body" style="background-color: #f4f4f4">
                <section id="loginForm">
                    <div class="form-horizontal">
                        <%--<h4>Use a local account to log in.</h4>--%>
                        <br />
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="Username" CssClass="col-md-3 control-label pad">Username</asp:Label>
                            <div class="col-md-8">
                                <asp:TextBox runat="server" ID="Username" CssClass="form-control" TextMode="SingleLine" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Username"
                                    CssClass="text-danger" ErrorMessage="The username is required." />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-3 control-label pad">Password</asp:Label>
                            <div class="col-md-8 ">
                                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-3 col-md-10">
                                <div class="checkbox">
                                    <asp:CheckBox runat="server" ID="RememberMe" />
                                    <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-3 col-md-8">
                                <asp:Button runat="server" OnClick="LogIn" Text="Sign in" CssClass="buttonp" Style="width: 80px" />
                            </div>
                        </div>
                    </div>
                    <%--<p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register as a new user</asp:HyperLink>
                </p>--%>
                    <p>
                        <%-- Enable this once you have account confirmation enabled for password reset functionality
                    <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink" ViewStateMode="Disabled">Forgot your password?</asp:HyperLink>
                        --%>
                    </p>
                </section>
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
    <br />
    <br />
</asp:Content>
