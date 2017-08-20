<%@ Page Title="Export Hall Authority Info" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ViewAndExportHAInfo.aspx.cs" Inherits="HallManagement.Admin.ViewAndExportHAInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        input[type=text] {
            width: 100%;
            box-sizing: border-box;
            border: 2px solid #ccc;
            border-radius: 4px;
            font-size: 14px;
            background-color: white;
            background-position: 10px 10px;
            background-repeat: no-repeat;
            padding: 12px 20px 12px 14px;
            /*-webkit-transition: width 1s ease-in-out;
            transition: width 1s ease-in-out;*/
        }

            input[type=text]:focus {
                width: 100%;
            }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%:eMessage.ClientID %>').delay(5000).fadeOut(1000);
            $('#<%:sMessage.ClientID %>').delay(5000).fadeOut(1000);
        });
    </script>

    <div class="row">
        <br />
        <div class="col-md-12">
            <div class="container">
                <div class="col-md-9">
                    <p class="text-left" style="font-size: 40px; color: #0d5166"><%:Title %></p>
                    <h4 class="text-success" id="sMessage" runat="server"></h4>
                    <h4 class="text-danger" id="eMessage" runat="server"></h4>
                </div>
                <div id="divStudentAccount" runat="server" class="col-md-2 col-md-offset-1 text-right">
                    <asp:LinkButton CssClass="btn btn-link" Text="<< Student Info" Style="font-size: medium" ID="lnkStudentInfo" OnClick="lnkStudentInfo_Click" runat="server" />
                </div>
            </div>
            <hr />
            <div class="form-horizontal panel-body" style="background-color: #f4f4f4">
                <div class="panel panel-body" style="background-color: #f4f4f4">
                    <div class="col-md-12">
                        <div class="col-md-6">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="ddlViewBy" CssClass="control-label pad col-md-2">View By</asp:Label>
                                    <div class="col-md-10">
                                        <asp:DropDownList AutoPostBack="true" ID="ddlViewBy" OnSelectedIndexChanged="ddlViewBy_SelectedIndexChanged" Style="max-width: 280px" CssClass="form-control" runat="server">
                                            <asp:ListItem Text="All" Value="All" />
                                            <asp:ListItem Text="Range" Value="Range" />
                                            <asp:ListItem Text="Hall" Value="Hall" />
                                            <asp:ListItem Text="Username" Value="UserName" />
                                            <asp:ListItem Text="Name" Value="Name" />
                                            <asp:ListItem Text="Designation" Value="Designation" />
                                            <asp:ListItem Text="Position" Value="Position" />
                                            <asp:ListItem Text="Phone No" Value="PhoneNo" />
                                            <asp:ListItem Text="Address" Value="Address" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-horizontal">
                                <div id="divViewByHall" runat="server" class="form-group">
                                    <asp:Label CssClass="control-label col-md-2 col-md-offset-2" runat="server" AssociatedControlID="ddlHall">Hall</asp:Label>
                                    <div class="col-md-8">
                                        <asp:DropDownList runat="server" ID="ddlHall" AutoPostBack="true" OnSelectedIndexChanged="ddlHall_SelectedIndexChanged" CssClass="form-control" Style="max-width: 280px">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div id="divViewByRange" runat="server" class="form-group">
                                    <asp:Label CssClass="control-label col-md-2 col-md-offset-2" runat="server" AssociatedControlID="ddlRange">Range</asp:Label>
                                    <div class="col-md-8">
                                        <asp:DropDownList runat="server" ID="ddlRange" AutoPostBack="true" OnSelectedIndexChanged="ddlRange_SelectedIndexChanged" CssClass="form-control" Style="max-width: 280px">
                                            <asp:ListItem Text="50" Value="50" />
                                            <asp:ListItem Text="100" Value="100" />
                                            <asp:ListItem Text="150" Value="150" />
                                            <asp:ListItem Text="200" Value="200" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div id="divViewByUserName" runat="server">
                                <asp:TextBox ID="txtUName" runat="server" CssClass="form-control col-md-3 col-md-offset-2" placeholder="Search.." />
                                <button type="button" id="btnUName" onserverclick="btnUName_ServerClick" runat="server" class="buttonf col-md-offset-1"><span class="glyphicon glyphicon-search"></span>&nbsp Search</button>
                            </div>
                            <div id="divViewByPosition" runat="server">
                                <asp:TextBox ID="txtPosition" runat="server" CssClass="form-control col-md-3 col-md-offset-2" placeholder="Search.." />
                                <button type="button" id="btnPosition" onserverclick="btnPosition_ServerClick" runat="server" class="buttonf col-md-offset-1"><span class="glyphicon glyphicon-search"></span>&nbsp Search</button>
                            </div>
                            <div id="divViewByDesignation" runat="server">
                                <asp:TextBox ID="txtDesignation" runat="server" CssClass="form-control col-md-3 col-md-offset-2" placeholder="Search.." />
                                <button type="button" id="btnDesignation" onserverclick="btnDesignation_ServerClick" runat="server" class="buttonf col-md-offset-1"><span class="glyphicon glyphicon-search"></span>&nbsp Search</button>
                            </div>
                            <div id="divViewByName" runat="server">
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control col-md-3 col-md-offset-2" placeholder="Search.." />
                                <button type="button" id="btnName" onserverclick="btnName_ServerClick" runat="server" class="buttonf col-md-offset-1"><span class="glyphicon glyphicon-search"></span>&nbsp Search</button>
                            </div>
                            <div id="divViewByPhoneNo" runat="server">
                                <asp:TextBox ID="txtPhoneNo" runat="server" CssClass="form-control col-md-3 col-md-offset-2" placeholder="Search.." />
                                <button type="button" id="btnPhoneNo" onserverclick="btnPhoneNo_ServerClick" runat="server" class="buttonf col-md-offset-1"><span class="glyphicon glyphicon-search"></span>&nbsp Search</button>
                            </div>
                            <div id="divViewByAddress" runat="server">
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control col-md-3 col-md-offset-2" placeholder="Search.." />
                                <button type="button" id="btnSearchAddress" onserverclick="btnSearchAddress_ServerClick" runat="server" class="buttonf col-md-offset-1"><span class="glyphicon glyphicon-search"></span>&nbsp Search</button>
                                <%--<asp:Button ID="btnSearchAddress" OnClick="btnSearchAddress_Click" Text="Search" runat="server" CssClass="btn btn-default col-md-offset-1" Width="100px" BackColor="LightGray" />--%>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="panel col-md-12" style="max-height: 500px; overflow-y: auto; background-color: #f4f4f4">
                    <asp:GridView ID="gvAllHA" Width="100%" HeaderStyle-BackColor="#004256" RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle" BorderWidth="2" AlternatingRowStyle-BackColor="#d4d8dd" CssClass="table table-borderd table-responsive" CellPadding="5" AutoGenerateColumns="false" runat="server" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" HeaderStyle-ForeColor="White">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label Text="User Name" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label Text='<%# Eval("UName") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label Text="First Name" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label Text='<%# Eval("FName") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label Text="Last Name" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label Text='<%# Eval("LName") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label Text="Designation" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label Text='<%# Eval("Designation") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label Text="Position" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label Text='<%# Eval("Position") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label Text="Father's Name" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label Text='<%# Eval("FatherName") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label Text="Mother's Name" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label Text='<%# Eval("MotherName") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label Text="Birthdate" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label Text='<%# Convert.ToDateTime(Eval("Birthdate")).ToString("dd/MM/yyyy") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label Text="Gender" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label Text='<%# Eval("Sex") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label Text="Hall Name" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label Text='<%# Eval("Hall") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label Text="Email Address" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label Text='<%# Eval("Email") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label Text="Address" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label Text='<%# Eval("Address") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label Text="Phone No" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label Text='<%# Eval("PhoneNo") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </div>
                <asp:Button Text="Exoprt to PDF" ID="btnExportPDF" OnClick="btnExportPDF_Click" CssClass="buttonp col-md-offset-10" Width="150px" runat="server" />
            </div>
        </div>
    </div>

</asp:Content>
