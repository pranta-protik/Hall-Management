<%@ Page Title="Notice" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Notice.aspx.cs" Inherits="HallManagement.Notice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <br />
        <p class="text-left" style="font-size: 40px; color: #0d5166"><%: Title %></p>
        <hr />
    </div>
    <div class="container">
        <div class="row">
            <div class="panel col-md-6 " style="background-color: #f4f4f4">
                <br />
                <div class="form-group">
                    <asp:TextBox runat="server" ReadOnly="true" TextMode="MultiLine" ID="txtTitle" CssClass="form-control" Style="height: 70px" />
                </div>
                <div class="form-group">
                    <asp:TextBox runat="server" ReadOnly="true" TextMode="MultiLine" ID="txtBody" CssClass="form-control" Style="height: 350px; overflow-y: auto" />
                </div>
            </div>
            <div class="panel col-md-5 col-md-offset-1" style="background-color: #f4f4f4;">
                <div class="form-group" style="max-height: 455px; overflow-y: auto">
                    <br />
                    <asp:GridView runat="server" ID="gvNotice" BorderStyle="None" HeaderStyle-Font-Underline="true" AutoGenerateColumns="false" Width="100%" GridLines="None" CellPadding="10" CssClass="table table-responsive" HeaderStyle-Font-Size="Large">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label Text="Notice" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:HiddenField ID="hfNotice" runat="server" Value='<%# Eval("NoticeId") %>' />
                                    <asp:LinkButton ID="lnkNotice" OnClick="lnkNotice_Click" runat="server" Text='<%# Eval("Title") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
