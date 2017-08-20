<%@ Page Title="Export Student Info" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ViewAndExportStudentInfo.aspx.cs" Inherits="HallManagement.Common.ViewAndExportStudentInfo" %>
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
                <div id="divHAAccount" runat="server" class="col-md-2 col-md-offset-1 text-right">
                    <asp:LinkButton CssClass="btn btn-link" Text="Hall Authority Info >>" Style="font-size: medium" ID="lnkHallAuthorityInfo" OnClick="lnkHallAuthorityInfo_Click" runat="server" />
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
                                            <asp:ListItem Text="Application No" Value="ApplicationNo" />
                                            <asp:ListItem Text="Hall" Value="Hall" />
                                            <asp:ListItem Text="Discipline" Value="Discipline" />
                                            <asp:ListItem Text="Username" Value="UserName" />
                                            <asp:ListItem Text="Name" Value="Name" />
                                            <asp:ListItem Text="Blood Group" Value="BloodGroup" />
                                            <asp:ListItem Text="Roll No" Value="RollNo" />
                                            <asp:ListItem Text="Batch" Value="Batch" />
                                            <asp:ListItem Text="Phone No" Value="PhoneNo" />
                                            <asp:ListItem Text="Room No" Value="RoomNo" />
                                            <asp:ListItem Text="Address" Value="Address" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-horizontal">
                                <div id="divViewByBatch" runat="server" class="form-group">
                                    <asp:Label CssClass="control-label col-md-2 col-md-offset-2" runat="server" AssociatedControlID="ddlBatch">Batch</asp:Label>
                                    <div class="col-md-8">
                                        <asp:DropDownList runat="server" ID="ddlBatch" AutoPostBack="true" OnSelectedIndexChanged="ddlBatch_SelectedIndexChanged" CssClass="form-control" Style="max-width: 280px">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div id="divViewByHall" runat="server" class="form-group">
                                    <asp:Label CssClass="control-label col-md-2 col-md-offset-2" runat="server" AssociatedControlID="ddlHall">Hall</asp:Label>
                                    <div class="col-md-8">
                                        <asp:DropDownList runat="server" ID="ddlHall" AutoPostBack="true" OnSelectedIndexChanged="ddlHall_SelectedIndexChanged" CssClass="form-control" Style="max-width: 280px">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div id="divViewByDiscipline" runat="server" class="form-group">
                                    <asp:Label CssClass="control-label col-md-2 col-md-offset-2" runat="server" AssociatedControlID="ddlDisciplineHall1">Hall</asp:Label>
                                    <div class="col-md-8">
                                        <asp:DropDownList runat="server" ID="ddlDisciplineHall1" AutoPostBack="true" OnSelectedIndexChanged="ddlDisciplineHall1_SelectedIndexChanged" CssClass="form-control" Style="max-width: 280px">
                                        </asp:DropDownList>
                                    </div>
                                    <asp:Label CssClass="control-label col-md-2 col-md-offset-2" AssociatedControlID="ddlDisciplineHall2" runat="server">Discipline</asp:Label>
                                    <div class="col-md-8">
                                        <asp:DropDownList runat="server" ID="ddlDisciplineHall2" AutoPostBack="true" OnSelectedIndexChanged="ddlDisciplineHall2_SelectedIndexChanged" CssClass="form-control" Style="max-width: 280px">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div id="divViewByRoomNo" runat="server" class="form-group">
                                    <asp:Label CssClass="control-label col-md-2 col-md-offset-2" runat="server" AssociatedControlID="ddlRoomHall">Hall</asp:Label>
                                    <div class="col-md-8">
                                        <asp:DropDownList runat="server" ID="ddlRoomHall" AutoPostBack="true" OnSelectedIndexChanged="ddlRoomHall_SelectedIndexChanged" CssClass="form-control" Style="max-width: 280px">
                                        </asp:DropDownList>
                                    </div>
                                    <asp:TextBox ID="txtRoomNo" runat="server" CssClass="form-control col-md-3 col-md-offset-2" placeholder="Search.." />
                                    <button type="button" id="btnRoomNo" onserverclick="btnRoomNo_ServerClick" runat="server" class="buttonf col-md-offset-1"><span class="glyphicon glyphicon-search"></span>&nbsp Search</button>
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
                            <div id="divViewByName" runat="server">
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control col-md-3 col-md-offset-2" placeholder="Search.." />
                                <button type="button" id="btnName" onserverclick="btnName_ServerClick" runat="server" class="buttonf col-md-offset-1"><span class="glyphicon glyphicon-search"></span>&nbsp Search</button>
                            </div>
                            <div id="divViewByPhoneNo" runat="server">
                                <asp:TextBox ID="txtPhoneNo" runat="server" CssClass="form-control col-md-3 col-md-offset-2" placeholder="Search.." />
                                <button type="button" id="btnPhoneNo" onserverclick="btnPhoneNo_ServerClick" runat="server" class="buttonf col-md-offset-1"><span class="glyphicon glyphicon-search"></span>&nbsp Search</button>
                            </div>
                            <div id="divViewByBloodGroup" runat="server">
                                <asp:TextBox ID="txtBGroup" runat="server" CssClass="form-control col-md-3 col-md-offset-2" placeholder="Search.." />
                                <button type="button" id="btnBGroup" onserverclick="btnBGroup_ServerClick" runat="server" class="buttonf col-md-offset-1"><span class="glyphicon glyphicon-search"></span>&nbsp Search</button>
                            </div>
                            <div id="divViewByRollNo" runat="server">
                                <asp:TextBox ID="txtRollNo" runat="server" CssClass="form-control col-md-3 col-md-offset-2" placeholder="Search.." />
                                <button type="button" id="btnSearchRNo" onserverclick="btnSearchRNo_ServerClick" runat="server" class="buttonf col-md-offset-1"><span class="glyphicon glyphicon-search"></span>&nbsp Search</button>
                                <%-- <asp:Button ID="btnSearchRNo" OnClick="btnSearchRNo_Click" Text="Search" runat="server" CssClass="btn btn-default col-md-offset-1" Width="100px" BackColor="LightGray" />--%>
                            </div>
                            <div id="divViewByAppId" runat="server">
                                <asp:TextBox ID="txtApplicationId" runat="server" CssClass="form-control col-md-3 col-md-offset-2" placeholder="Search.." />
                                <button type="button" id="btnSearchAId" onserverclick="btnSearchAId_ServerClick" runat="server" class="buttonf col-md-offset-1"><span class="glyphicon glyphicon-search"></span>&nbsp Search</button>
                                <%--<asp:Button ID="btnSearchAId" OnClick="btnSearchAId_Click" Text="Search" runat="server" CssClass="btn btn-default col-md-offset-1" Width="100px" BackColor="LightGray" />--%>
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
                    <asp:GridView ID="gvAllStudent" Width="100%" HeaderStyle-BackColor="#004256" RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle" BorderWidth="2" AlternatingRowStyle-BackColor="#d4d8dd" CssClass="table table-borderd table-responsive" CellPadding="5" AutoGenerateColumns="false" runat="server" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" HeaderStyle-ForeColor="White">
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
                                    <asp:Label Text="Roll No" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label Text='<%# Eval("RollNo") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label Text="Discipline" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label Text='<%# Eval("Discipline") %>' runat="server" />
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
                                    <asp:Label Text="Batch" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label Text='<%# Eval("Batch") %>' runat="server" />
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
                                    <asp:Label Text="Blood Group" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label Text='<%# Eval("BGroup") %>' runat="server" />
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
                                    <asp:Label Text="Room No" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label Text='<%# Eval("RoomNo") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label Text="Application No" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label Text='<%# Eval("ApplicationNo") %>' runat="server" />
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
