<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BizBuildingApp.MyAccount.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>BizBuilding - Tenant Requests</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myDashboard" runat="server">
    <div class="header">
        Tenant Complaints
    </div>
    <div class="info">
        <div class="row">
            <asp:Label ID="lblMessage" runat="server" CssClass="label-success"></asp:Label>
        </div>
        <asp:GridView ID="gvLogs" runat="server" AutoGenerateColumns="false" CssClass="content-table">
            <Columns>
                <asp:BoundField HeaderText="Request #" DataField="LogId" />
                <asp:BoundField HeaderText="Category" DataField="CategoryName" />
                <asp:BoundField HeaderText="Location/Suit" DataField="Location" />
                <asp:BoundField HeaderText="Description" DataField="Description" />
                <asp:BoundField HeaderText="Status" DataField="Status" />
                <asp:BoundField HeaderText="Requested Date" DataField="RequestedDate" />
                <asp:BoundField HeaderText="Completed Date" DataField="ResolveDate" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkStatus" runat="server" Text="<i class='fas fa-edit'></i>" ToolTip="Change Status" OnClick="lnkStatus_Click" CommandArgument='<%#Eval("LogId") %>'></asp:LinkButton> 
                        <asp:LinkButton ID="lnkDelete" runat="server" Text="<i class='fas fa-trash'></i>" ToolTip="Delete" CommandArgument='<%#Eval("LogId") %>' OnClick="lnkDelete_Click" OnClientClick="if (!confirm('Are you sure you want delete?')) return false;"></asp:LinkButton> 
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
