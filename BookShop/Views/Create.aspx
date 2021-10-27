<%@ Page Title="Create" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="BookShop.Create" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <form>
        <div class="form-group">
            <label>Name</label>
            <asp:TextBox ID="txName" placeholder="name" class="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Year</label>
            <asp:TextBox ID="txYear" placeholder="Year" class="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Pages Count</label>
            <asp:TextBox ID="txPagesCount" placeholder="Pages Count" class="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Author</label>
            <asp:DropDownList ID="ddlAuthors" runat="server">
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <label>Genre</label>
            <asp:DropDownList ID="ddlGenres" runat="server">
            </asp:DropDownList>
        </div>
        <asp:Button ID="CreateButton" runat="server" Text="Create" OnClick="CreateButton_Click" />
    </form>
</asp:Content>
