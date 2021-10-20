﻿<%@ Page Title="Edit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="BookShop.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <form>
         <div class="form-group">
            <label>Id</label>
            <asp:TextBox Enabled="false" ID="IdTextBox" placeholder="Id" class="form-control"  runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Name</label>
            <asp:TextBox ID="TextBoxName" placeholder="name" class="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Year</label>
            <asp:TextBox ID="TextBoxYear" placeholder="Year" class="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Pages Count</label>
            <asp:TextBox ID="TextBoxpagesCount" placeholder="Pages Count" class="form-control" runat="server"></asp:TextBox>
        </div>
            <div class="form-group">
            <label>Author</label>
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <label>Genre</label>
            <asp:DropDownList ID="DropDownList2" runat="server">
            </asp:DropDownList>
        </div>
        <asp:Button ID="EditButton" runat="server" Text="Create" OnClick="EditButton_Click" />
    </form>
</asp:Content>