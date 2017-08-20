<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HallManagement._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .carousel-inner > .item > img,
        .carousel-inner > .item > a > img {
            width: 100%;
            margin: auto;
        }
    </style>

    <div class="container">
        <div class="row">
            <div class="panel col-md-12" style="min-height: 125px; background-color: #004256; font-size: xx-large; color: white; padding-top: 30px">
                <p class="panel-heading text-center"><strong>Khulna University Hall Management System</strong></p>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-md-7">
                        <div id="myCarousel" class="carousel slide " data-ride="carousel" style="background-color:#f4f4f4">
                            <!-- Indicators -->
                            <asp:Literal ID="ltlCarouselIndicators" runat="server" />
                            <!-- Images-->
                            <div class="carousel-inner" role="listbox">
                                <asp:Literal ID="ltlCarouselImages" runat="server" />
                            </div>
                            <!-- Left Right Arrows -->
                            <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                                <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                                <span class="sr-only">Previous</span>
                            </a>
                            <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
                                <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                                <span class="sr-only">Next</span>
                            </a>
                        </div>
                    </div>
                    <div class="panel col-md-5" style="background-color:#f4f4f4;">
                        <h4 class="panel-heading text-center" style="color: #03707b; font-size:20px"><strong><%: lblHeading.InnerText %></strong></h4>
                        <div class="form-horizontal panel-body">
                            <label id="lblHeading" runat="server" visible="false"></label>
                            <textarea id="txtDescription" runat="server" readonly="readonly" class="form-control" style="height: 395px; overflow-y: auto; background-color:#f4f4f4"></textarea>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="panel col-md-6" style="background-color: #f4f4f4">
                
                <div class="form-group" style="height: 300px; overflow-y: auto; background-color:#f4f4f4">
                    <br />
                    <asp:GridView runat="server" ID="gvNews" BorderStyle="None" AutoGenerateColumns="false" BackColor="#f4f4f4" Width="100%" GridLines="None" CssClass="table table-responsive" CellPadding="10" HeaderStyle-Font-Size="X-Large" HeaderStyle-ForeColor="#0d5166" HeaderStyle-Font-Underline="true">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label Text="Latest News" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:HiddenField ID="hfNews" runat="server" Value='<%# Eval("NewsId") %>' />
                                    <asp:LinkButton ID="lnkNews" OnClick="lnkNews_Click" runat="server" Text='<%# Eval("Title") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="panel col-md-5 col-md-offset-1" style="background-color:#f4f4f4">
                <div class="form-group" style="height: 300px; overflow-y: auto; background-color:#f4f4f4">
                    <br />
                    <asp:GridView runat="server" ID="gvNotice" BorderStyle="None" AutoGenerateColumns="false" BackColor="#f4f4f4" Width="100%" GridLines="None" CssClass="table table-responsive" CellPadding="10" HeaderStyle-Font-Size="X-Large" HeaderStyle-ForeColor="#0d5166" HeaderStyle-Font-Underline="true">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label Text="Latest Notice" runat="server" />
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
