<%@ Page Title="Edit History" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditHistory.aspx.cs" Inherits="HallManagement.Admin.EditHistory" %>

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
                <div class="col-md-9">
                    <p class="text-left" style="font-size: 40px; color: #0d5166"><%:Title %></p>
                    <h4 class="text-success" id="sMessage" runat="server"></h4>
                    <h4 class="text-danger" id="eMessage" runat="server"></h4>
                </div>
                <div class="col-md-2 col-md-offset-1 text-right">
                    <asp:LinkButton CssClass="btn btn-link" Text="Edit Contact >>" Style="font-size: medium" ID="lnkEditContact" OnClick="lnkEditContact_Click" runat="server" />
                    <%--<a href="EditContact.aspx">Edit Contact ></a>--%>
                </div>
            </div>
            <hr />
            <div class="form-horizontal panel-body">
                <div class="panel col-md-6" style="background-color: #f4f4f4;">
                    <div class="form-horizontal panel-body">
                        <p class="text-left" style="font-size: 25px; color: #0d5166">Image</p>
                        <br />
                        <asp:Literal ID="ltlHistoryImage" runat="server" />
                        <hr />
                        <div id="divUploadHistory" runat="server">
                            <asp:FileUpload ID="historyImageUpload" runat="server" />
                            <br />
                            <asp:Button ID="btnUploadHistoryImage" runat="server" CssClass="buttons" Style="width: 90px" Text="Upload" OnClick="btnUploadHistoryImage_Click" />
                        </div>
                        <div id="divDeleteHistory" runat="server">
                            <button type="button" class="buttone col-md-offset-9" data-toggle="modal" data-target="#myModal2">Delete</button>
                            <div class="modal fade" id="myModal2" role="dialog">
                                <div class="modal-dialog">
                                    <div class="modal-content" style="background-color: #f0f0f0">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                        </div>
                                        <div class="modal-body">
                                            <h3>Do you really want to delete?</h3>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="buttons" runat="server" id="btnDeleteHistoryImage" style="width: 100px" onserverclick="btnDeleteHistoryImage_ServerClick">Yes</button>
                                            <button type="button" class="buttone" style="width: 100px" data-dismiss="modal">No</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%--<asp:Button ID="btnDeleteHistoryImage" runat="server" CssClass="button col-md-offset-9" Style="width: 100px" Text="Delete" OnClick="btnDeleteHistoryImage_Click" />--%>
                        </div>
                        <br />
                        <br />
                    </div>
                </div>
                <div class="panel col-md-5 col-md-offset-1" style="background-color: #f4f4f4;">
                    <div class="form-horizontal panel-body">
                        <p class="text-left" style="font-size: 25px; color: #0d5166">History</p>
                        <br />
                        <strong>Title : &nbsp</strong>
                        <asp:TextBox ID="txtHeading" runat="server" CssClass="form-control" TextMode="MultiLine" Style="height: 60px; overflow-y: auto" />
                        <br />
                        <strong>Description : &nbsp</strong>
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Style="height: 330px; overflow-y: auto" />
                        <br />
                        <asp:Button ID="btnUpdateHistory" runat="server" CssClass="buttons col-md-offset-5" Style="width: 100px;" Text="Update" OnClick="btnUpdateHistory_Click" />
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
                                        <button type="button" class="buttons" runat="server" id="btnRemoveHistory" style="width: 100px" onserverclick="btnRemoveHistory_ServerClick">Yes</button>
                                        <button type="button" class="buttone" style="width: 100px" data-dismiss="modal">No</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%-- <asp:Button ID="btnRemoveHistory" runat="server" CssClass="btn btn-danger col-md-offset-1" Style="width: 100px" Text="Remove" OnClick="btnRemoveHistory_Click" />--%>
                        <br />
                        <br />

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
