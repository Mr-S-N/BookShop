<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BookShop._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Repeater ID="RepeatInformation" runat="server">
        <HeaderTemplate>
            <table class="table">
                <thead>
                    <tr>
                        <th scope="col">ID</th>
                        <th scope="col">Name</th>
                        <th scope="col">Year</th>
                        <th scope="col">Page Count</th>
                        <th scope="col">Action</th>
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tbody>
                <tr>
                    <td><%#DataBinder.Eval(Container,"DataItem.Id")%>  </td>
                    <td><%#DataBinder.Eval(Container,"DataItem.Name")%>  </td>
                    <td><%#DataBinder.Eval(Container,"DataItem.Year")%>  </td>
                    <td><%#DataBinder.Eval(Container,"DataItem.PageCount")%>  </td>
                    <td> <asp:Button ID="EditButton" runat="server" Text="Edit" CommandArgument='<%#DataBinder.Eval(Container,"DataItem.Id")%>' OnClick="EditButton_Click" /> </td>
                </tr>
            </tbody>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tbody>
                <tr>
                    <td><%#DataBinder.Eval(Container,"DataItem.Id")%>  </td>
                    <td><%#DataBinder.Eval(Container,"DataItem.Name")%>  </td>
                    <td><%#DataBinder.Eval(Container,"DataItem.Year")%>  </td>
                    <td><%#DataBinder.Eval(Container,"DataItem.PageCount")%>  </td>
                    <td> <asp:Button ID="EditButton" runat="server" Text="Edit" CommandArgument='<%#DataBinder.Eval(Container,"DataItem.Id")%>' OnClick="EditButton_Click" /> </td>
                </tr>
            </tbody>
        </AlternatingItemTemplate>
    </asp:Repeater>
</asp:Content>
