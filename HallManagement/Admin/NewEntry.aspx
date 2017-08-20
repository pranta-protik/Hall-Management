<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewEntry.aspx.cs" Inherits="HallManagement.Admin.NewEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Wizard ID="wizNewEntry" runat="server" CssClass="container col-md-12">
        <StartNavigationTemplate>
            <asp:Button ID="StartNextButton" Text="Allote seats to room" CssClass="buttonp" Width="170px" CommandName="MoveNext" CausesValidation="false" runat="server" />
        </StartNavigationTemplate>
        <StepNavigationTemplate>
            <asp:Button ID="StepPreviousButton" Text="Allote rooms to hall" CssClass="buttonp" Width="170px" CommandName="MovePrevious" CausesValidation="false" runat="server" />
            <asp:Button ID="StepNextButton" Text="Allote seats to discipline" CssClass="buttonp" Width="170px" CommandName="MoveNext" CausesValidation="false" runat="server" />
        </StepNavigationTemplate>
        <FinishNavigationTemplate>
            <asp:Button ID="FinishCompleteButton" Text="Allote seats to room" CssClass="buttonp" Width="170px" CommandName="MovePrevious" CausesValidation="false" runat="server" />
        </FinishNavigationTemplate>
        <WizardSteps>
            <asp:WizardStep runat="server">
                <div class="container">
                    <br />
                    <p class="text-left" style="font-size: 40px; color: #0d5166">Allote rooms to hall</p>
                    <h4 class="text-success" id="sMessage1" runat="server"></h4>
                    <h4 class="text-danger" id="eMessage1" runat="server"></h4>
                    <hr />
                </div>
                <script type="text/javascript">
                    $(document).ready(function () {
                        $('#<%:sMessage1.ClientID %>').delay(5000).fadeOut(1000);
                        $('#<%:eMessage1.ClientID %>').delay(5000).fadeOut(1000);
                    });
                </script>
                <div class="row">
                    <div class="panel col-md-6" style="background-color: #f4f4f4">
                        <div class="form-horizontal panel-body">
                            <br />
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="hallName" CssClass="col-md-3 control-label pad">Hall Name*</asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox runat="server" ID="hallName" CssClass="form-control" TextMode="SingleLine" AutoPostBack="false" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="hallName"
                                        CssClass="text-danger" ErrorMessage="The hall name field is required." />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="totalRoom" CssClass="col-md-3 control-label pad">Total Room*</asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox runat="server" ID="totalRoom" CssClass="form-control" TextMode="SingleLine" AutoPostBack="false" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="totalRoom"
                                        CssClass="text-danger" ErrorMessage="The total room field is required." />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="totalSeat" CssClass="col-md-3 control-label pad">Total Seat*</asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox runat="server" ID="totalSeat" CssClass="form-control" TextMode="SingleLine" AutoPostBack="false" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="totalSeat"
                                        CssClass="text-danger" ErrorMessage="The total room field is required." />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-offset-3 col-md-6">
                                    <asp:Button runat="server" ID="alloteHallRoom" OnClick="alloteHallRoom_Click" Text="Allote" CssClass="buttons" Style="width: 100px" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-5 col-md-offset-1" style="max-height: 307px; overflow-y: auto">
                        <asp:GridView ID="gvHallRoom" Width="100%" CssClass="table table-bordered table-responsive" BackColor="#f4f4f4" HeaderStyle-BackColor="#004256" BorderWidth="2" RowStyle-VerticalAlign="Middle" RowStyle-HorizontalAlign="Center" AlternatingRowStyle-BackColor="#d4d8dd" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" AutoGenerateColumns="false" runat="server" CellPadding="5">
                            <Columns>
                              
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label Text="Hall Name" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("HName") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label Text="Total Room" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("TRoomNo") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label Text="Total Seat" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("TSeatNo") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label Text="Delete" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hfHallId" runat="server" Value='<%# Eval("HId") %>' />
                                        <a href="#"><span class="glyphicon glyphicon-trash" style="color: darkred"></span></a>
                                        <asp:LinkButton ID="lnkDeleteHall" CausesValidation="false" Text="Delete" ForeColor="DarkRed" runat="server" OnClick="lnkDeleteHall_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </asp:WizardStep>
            <asp:WizardStep runat="server">
                <div class="container">
                    <br />
                    <p class="text-left" style="font-size: 40px; color: #0d5166">Allote seats to room</p>
                    <h4 class="text-success" id="sMessage2" runat="server"></h4>
                    <h4 class="text-danger" id="eMessage2" runat="server"></h4>
                    <hr />
                </div>
                <script type="text/javascript">
                    $(document).ready(function () {
                        $('#<%:sMessage2.ClientID %>').delay(5000).fadeOut(1000);
                        $('#<%:eMessage2.ClientID %>').delay(5000).fadeOut(1000);
                    });
                </script>
                <div class="row">
                    <div class="panel col-md-6" style="background-color: #f4f4f4">
                        <div class="form-horizontal panel-body">
                            <br />
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlHallRoom" CssClass="col-md-3 control-label pad">Hall*</asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="ddlHallRoom_SelectedIndexChanged" ID="ddlHallRoom" Style="max-width: 280px" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlHallRoom"
                                        CssClass="text-danger" ErrorMessage="The hall is required." />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="roomNo" CssClass="col-md-3 control-label pad">Room Number*</asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox runat="server" ID="roomNo" CssClass="form-control" TextMode="SingleLine" AutoPostBack="false" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="roomNo"
                                        CssClass="text-danger" ErrorMessage="The room number is required." />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="roomAllotedSeat" CssClass="col-md-3 control-label pad">Allote Seat*</asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox runat="server" ID="roomAllotedSeat" CssClass="form-control" TextMode="SingleLine" AutoPostBack="false" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="roomAllotedSeat"
                                        CssClass="text-danger" ErrorMessage="The seat number field is required." />
                                </div>
                                <div class="col-md-2">
                                    <asp:Label ID="lblUnallottedRoomSeat" Text="Unallotted seat: 0" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-offset-3 col-md-6">
                                    <asp:Button runat="server" ID="alloteRoomSeat" OnClick="alloteRoomSeat_Click" Text="Allote" CssClass="buttons" Style="width: 100px" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-5 col-md-offset-1" style="max-height: 307px; overflow-y: auto">
                        <asp:GridView ID="gvRoomSeat" Width="100%" CssClass="table table-bordered table-responsive" CellPadding="5" BackColor="#f4f4f4" HeaderStyle-BackColor="#004256" BorderWidth="2" RowStyle-VerticalAlign="Middle" RowStyle-HorizontalAlign="Center" AlternatingRowStyle-BackColor="#d4d8dd" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" AutoGenerateColumns="false" runat="server">
                            <Columns>
                               
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label Text="Hall Name" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("HName") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label Text="Room Number" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("RoomNo") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label Text="Total Seat" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("SeatNo") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label Text="Delete" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hfRoomId" runat="server" Value='<%# Eval("RId") %>' />
                                        <a href="#"><span class="glyphicon glyphicon-trash" style="color: darkred"></span></a>
                                        <asp:LinkButton ID="lnkDeleteRoom" CausesValidation="false" Text="Delete" ForeColor="DarkRed" runat="server" OnClick="lnkDeleteRoom_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </asp:WizardStep>
            <asp:WizardStep runat="server">
                <div class="container">
                    <br />
                    <p class="text-left" style="font-size: 40px; color: #0d5166">Allote seats to discipline</p>
                    <h4 class="text-success" id="sMessage3" runat="server"></h4>
                    <h4 class="text-danger" id="eMessage3" runat="server"></h4>
                    <hr />
                </div>
                <script type="text/javascript">
                    $(document).ready(function () {
                        $('#<%:sMessage3.ClientID %>').delay(5000).fadeOut(1000);
                        $('#<%:eMessage3.ClientID %>').delay(5000).fadeOut(1000);
                    });
                </script>
                <div class="row">
                    <div class="panel col-md-6" style="background-color: #f4f4f4">
                        <div class="form-horizontal panel-body">
                            <br />
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ddlHallDiscipline" CssClass="col-md-3 control-label pad">Hall*</asp:Label>
                                <div class="col-md-6">
                                    <asp:DropDownList AutoPostBack="true" ID="ddlHallDiscipline" OnSelectedIndexChanged="ddlHallDiscipline_SelectedIndexChanged" Style="max-width: 280px" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlHallDiscipline"
                                        CssClass="text-danger" ErrorMessage="The hall field is required." />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="discipline" CssClass="col-md-3 control-label pad">Discipline*</asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox runat="server" ID="discipline" CssClass="form-control" TextMode="SingleLine" AutoPostBack="false" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="discipline"
                                        CssClass="text-danger" ErrorMessage="The discipline field is required." />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="disciplineAllotedSeat" CssClass="col-md-3 control-label pad">Allote Seat*</asp:Label>
                                <div class="col-md-6">
                                    <asp:TextBox runat="server" ID="disciplineAllotedSeat" CssClass="form-control" TextMode="SingleLine" AutoPostBack="false" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="disciplineAllotedSeat"
                                        CssClass="text-danger" ErrorMessage="The alloted seat field is required." />
                                </div>
                                <div class="col-md-2">
                                    <asp:Label ID="lblUnallottedDisciplineSeat" Text="Unallotted seat: 0" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-offset-3 col-md-6">
                                    <asp:Button runat="server" ID="alloteDisciplineSeat" OnClick="alloteDisciplineSeat_Click" Text="Allote" CssClass="buttons" Style="width: 100px" />
                                </div>
                                
                            </div>
                        </div>
                    </div>
                    <div class="col-md-5 col-md-offset-1" style="max-height: 307px; overflow-y: auto">
                        <asp:GridView ID="gvDisciplineSeat" Width="100%" CssClass="table table-bordered table-responsive" CellPadding="5" BackColor="#f4f4f4" HeaderStyle-BackColor="#004256" BorderWidth="2" RowStyle-VerticalAlign="Middle" RowStyle-HorizontalAlign="Center" AlternatingRowStyle-BackColor="#d4d8dd" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" AutoGenerateColumns="false" runat="server">
                            <Columns>
                              
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label Text="Hall Name" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("HName") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label Text="Discipline Name" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("DName") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label Text="Alloted Seat" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("AllotedSeat") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label Text="Delete" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hfDisciplineId" runat="server" Value='<%# Eval("DId") %>' />
                                        <a href="#"><span class="glyphicon glyphicon-trash" style="color: darkred"></span></a>
                                        <asp:LinkButton ID="lnkDeleteDiscipline" CausesValidation="false" Text="Delete" ForeColor="DarkRed" runat="server" OnClick="lnkDeleteDiscipline_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </asp:WizardStep>
        </WizardSteps>
    </asp:Wizard>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
