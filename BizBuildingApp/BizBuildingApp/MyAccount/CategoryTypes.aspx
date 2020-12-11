<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="CategoryTypes.aspx.cs" Inherits="BizBuildingApp.MyAccount.CategoryTypes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>BizBuilding - Categories</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myDashboard" runat="server">
    <div class="header">
        Categories
    </div>
    <div class="info">
        <div class="row">
            <asp:Label ID="lblMessage" runat="server" CssClass="label-success"></asp:Label>
        </div>
        <div class="top-content">
            <asp:LinkButton ID="lnkAddCategory" runat="server" OnClick="lnkAddCategory_Click">Create Category</asp:LinkButton>
          </div>
        <asp:GridView ID="gvCategories" runat="server" AutoGenerateColumns="false" CssClass="content-table">
            <Columns>
                <asp:BoundField HeaderText="Name" DataField="Name" />
                <asp:BoundField HeaderText="Description" DataField="Description" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" runat="server" Text="<i class='fas fa-edit'></i>" ToolTip="Modify" CommandArgument='<%#Eval("CategoryId") %>' OnClick="lnkEdit_Click"></asp:LinkButton> 
                        <asp:LinkButton ID="lnkDelete" runat="server" Text="<i class='fas fa-trash'></i>" ToolTip="Delete" CommandArgument='<%#Eval("CategoryId") %>' OnClick="lnkDelete_Click" OnClientClick="if (!confirm('Are you sure you want delete?')) return false;"></asp:LinkButton> 
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
