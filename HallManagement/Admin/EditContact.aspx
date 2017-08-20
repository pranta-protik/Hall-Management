<%@ Page Title="Edit Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditContact.aspx.cs" Inherits="HallManagement.Admin.EditContact" %>
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
                    <asp:LinkButton CssClass="btn btn-link" Text="<< Edit History" Style="font-size: medium" ID="lnkEditHistory" OnClick="lnkEditHistory_Click" runat="server" />
                </div>
            </div>
            <hr />
            <div class="form-horizontal panel-body">
                <div class="panel col-md-5" style="background-color: #f4f4f4;">
                    <div class="form-horizontal panel-body">
                        <p class="text-left" style="font-size: 25px; color: #0d5166">Contact</p>
                        <br />
                        <strong>Address :&nbsp</strong>
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" TextMode="MultiLine" Style="height: 200px; overflow-y: auto" />
                        <br />
                        <strong>Support :&nbsp</strong>
                        <asp:TextBox ID="txtSupport" runat="server" CssClass="form-control" TextMode="MultiLine" Style="height: 35px; overflow-y: auto" />
                        <br />
                        <strong>Support Link :&nbsp</strong>
                        <asp:TextBox ID="txtSupportHref" runat="server" CssClass="form-control" TextMode="MultiLine" Style="height: 35px; overflow-y: auto" />
                        <br />
                        <strong>Contact No :&nbsp</strong>
                        <asp:TextBox ID="txtContact" runat="server" CssClass="form-control" TextMode="MultiLine" Style="height: 35px; overflow-y: auto" />
                        <br />
                        <asp:Button ID="btnUpdateContact" runat="server" CssClass="buttons col-md-offset-5" Style="width: 100px;" Text="Update" OnClick="btnUpdateContact_Click" />
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
                                        <button type="button" class="buttons" runat="server" id="btnRemoveContact" style="width: 100px" onserverclick="btnRemoveContact_ServerClick">Yes</button>
                                        <button type="button" class="buttone" style="width: 100px" data-dismiss="modal">No</button>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <%--<asp:Button ID="btnRemoveContact" runat="server" CssClass="btn btn-danger col-md-offset-1" Style="width: 100px" Text="Remove" OnClick="btnRemoveContact_Click" />--%>
                        <br />
                        <br />

                    </div>
                </div>
                <div class="panel col-md-6 col-md-offset-1" style="background-color: #f4f4f4;">
                    <div class="form-horizontal panel-body">
                        <p class="text-left" style="font-size: 25px; color: #0d5166">Image</p>
                        <br />
                        <asp:Literal ID="ltlContactImage" runat="server" />
                        <hr />
                        <div id="divUploadContact" runat="server">
                            <asp:FileUpload ID="contactImageUpload" runat="server" />
                            <br />
                            <asp:Button ID="btnUploadContactImage" runat="server" CssClass="buttons" Style="width: 90px" Text="Upload" OnClick="btnUploadContactImage_Click" />
                        </div>
                        <div id="divDeleteContact" runat="server">
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
                                            <button type="button" class="buttons" runat="server" id="btnDeleteContactImage" style="width: 100px" onserverclick="btnDeleteContactImage_ServerClick">Yes</button>
                                            <button type="button" class="buttone" style="width: 100px" data-dismiss="modal">No</button>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <%--<asp:Button ID="btnDeleteContactImage" runat="server" CssClass="btn btn-danger col-md-offset-9" Style="width: 100px" Text="Delete" OnClick="btnDeleteContactImage_Click" />--%>
                        </div>
                        <br />
                        <br />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
