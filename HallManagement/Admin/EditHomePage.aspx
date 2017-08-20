<%@ Page Title="Edit Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditHomePage.aspx.cs" Inherits="HallManagement.Admin.EditHomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
                <p class="text-left" style="font-size: 40px; color: #0d5166"><%: Title %></p>
                <h4 class="text-success" id="sMessage" runat="server"></h4>
                <h4 class="text-danger" id="eMessage" runat="server"></h4>
                <hr />
            </div>
            <div class="form-horizontal panel-body">
                <div class="panel col-md-6" style="background-color: #f4f4f4;">
                    <div class="form-horizontal panel-body">
                        <p class="text-left" style="font-size: 25px; color: #0d5166">Slideshow Images</p>
                        <br />
                        <asp:GridView ID="gvUploadedImage" CssClass="table table-bordered table-responsive" Width="100%" HeaderStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-VerticalAlign="Middle" runat="server" HeaderStyle-ForeColor="DarkCyan" HeaderStyle-BackColor="LightGray" BorderWidth="2" HeaderStyle-VerticalAlign="Middle" AutoGenerateColumns="false" EmptyDataText="No files uploaded">
                            <Columns>
                                <asp:ImageField DataImageUrlField="Value" ControlStyle-Height="100px" ControlStyle-Width="150px" ControlStyle-CssClass="img-responsive" HeaderText="Images"></asp:ImageField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <a href="#"><span class="glyphicon glyphicon-download-alt"></span></a>
                                        <asp:LinkButton ID="lnkDownload" Text="Download" CommandArgument='<%# Eval("Value") %>' runat="server" OnClick="lnkDownload_Click"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <a href="#"><span class="glyphicon glyphicon-trash" style="color:darkred"></span></a>
                                        <asp:LinkButton ID="lnkDelete" Text="Delete" ForeColor="DarkRed" CommandArgument='<%# Eval("Value") %>' runat="server" OnClick="lnkDelete_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <hr />
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        <br />
                        <asp:Button ID="btnUpload" runat="server" CssClass="buttons" Style="width: 90px" Text="Upload" OnClick="btnUpload_Click" />
                        <br />
                        <br />
                    </div>
                </div>
                <div class="panel col-md-5 col-md-offset-1" style="background-color: #f4f4f4;">
                    <div class="form-horizontal panel-body">
                        <p class="text-left" style="font-size: 25px; color: #0d5166">Messages</p>
                        <br />
                        <strong>Title : &nbsp</strong>
                        <asp:TextBox ID="txtHeading" runat="server" CssClass="form-control" TextMode="MultiLine" Style="height: 60px; overflow-y: auto" />
                        <br />
                        <strong>Description : &nbsp</strong>
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Style="height: 340px; overflow-y: auto" />
                        <br />
                        <asp:Button ID="btnUpdate" runat="server" CssClass="buttons col-md-offset-5" Style="width: 100px;" Text="Update" OnClick="btnUpdate_Click" />
                        <button type="button" class="buttone col-md-offset-1" data-toggle="modal" data-target="#myModal">Remove</button>
                        <div class="modal fade" id="myModal" role="dialog">
                            <div class="modal-dialog">
                                <div class="modal-content" style="background-color: #f0f0f0">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    </div>
                                    <div class="modal-body">
                                        <h3>Do you really want to remove?</h3>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="buttons" runat="server" id="btnRemove" style="width: 100px" onserverclick="btnRemove_ServerClick">Yes</button>
                                        <button type="button" class="buttone" style="width: 100px" data-dismiss="modal">No</button>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <%--<asp:Button ID="btnRemove" runat="server" CssClass="btn btn-danger col-md-offset-1" Style="width: 100px" Text="Remove" OnClick="btnRemove_Click" />--%>
                        <br />
                        <br />

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
