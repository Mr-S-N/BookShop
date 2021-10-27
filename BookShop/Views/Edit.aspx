<%@ Page Title="Edit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="BookShop.Edit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <form>
         <div class="form-group">
            <label>Id</label>
            <asp:TextBox Enabled="false" ID="txId" placeholder="Id" class="form-control"  runat="server"></asp:TextBox>
        </div>
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
        <asp:Button ID="EditButton" runat="server" Text="Create" OnClick="EditButton_Click" />
    </form>
</asp:Content>
