<%@ Page Title="Add News" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddNews.aspx.cs" Inherits="HallManagement.Common.AddNews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%:eMessage.ClientID %>').delay(5000).fadeOut(1000);
            $('#<%:sMessage.ClientID %>').delay(5000).fadeOut(1000);
        });
    </script>
    <div class="container">
        <br />
        <div class="col-md-9">
            <p class="text-left" style="font-size: 40px; color: #0d5166"><%: Title %></p>
            <h4 class="text-success" id="sMessage" runat="server"></h4>
            <h4 class="text-danger" id="eMessage" runat="server"></h4>

        </div>
        <div class="col-md-2 col-md-offset-1 text-right">
            <asp:LinkButton CssClass="btn btn-link" Text="Add Notice >>" Style="font-size: medium" ID="lnkAddNotice" OnClick="lnkAddNotice_Click" runat="server" />
            <%--<a href="EditContact.aspx">Edit Contact ></a>--%>
        </div>
    </div>
    <hr />
    <div class="container">
        <div class="row">
            <div class="panel col-md-10 col-md-offset-1" style="background-color: #f4f4f4">
                <br />
                <div class="form-group">
                    <asp:Label Text="Title" runat="server" AssociatedControlID="txtTitle" />
                    <asp:TextBox runat="server" TextMode="MultiLine" ID="txtTitle" CssClass="form-control" Style="height: 70px" />
                </div>
                <div class="form-group">
                    <asp:Label Text="Description" runat="server" AssociatedControlID="txtBody" />
                    <asp:TextBox runat="server" TextMode="MultiLine" ID="txtBody" CssClass="form-control" Style="height: 310px; overflow-y: auto" />
                </div>
                <div class="col-md-offset-9">
                    <asp:Button Text="Add" CssClass="buttons" ID="btnAdd" OnClick="btnAdd_Click" runat="server" />
                    <button type="button" class="buttone col-md-offset-1" data-toggle="modal" data-target="#myModal">Cancel</button>
                    <div class="modal fade" id="myModal" role="dialog">
                        <div class="modal-dialog">
                            <div class="modal-content" style="background-color: #f0f0f0">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                </div>
                                <div class="modal-body">
                                    <h3>Do you really want to cancel?</h3>
                                </div>
                                <div class="modal-footer">
                                    <asp:HiddenField ID="hfCurrentNews" runat="server" />
                                    <button type="button" class="buttons" runat="server" id="btnCancel" style="width: 100px" onserverclick="btnCancel_ServerClick">Yes</button>
                                    <button type="button" class="buttone" style="width: 100px" data-dismiss="modal">No</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--<asp:Button Text="Remove" runat="server" CssClass="buttone col-md-offset-1" ID="btnRemove" OnClick="btnRemove_Click" />--%>
                </div>
                <br />
            </div>
        </div>
    </div>
</asp:Content>
