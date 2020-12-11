<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Staffs.aspx.cs" Inherits="BizBuildingApp.MyAccount.Staffs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>BizBuilding - Staff Members</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myDashboard" runat="server">
    <div class="header">
        Staff Members
    </div>
    <div class="info">
        <div class="row">
            <asp:Label ID="lblMessage" runat="server" CssClass="label-success"></asp:Label>
        </div>
        <div class="top-content">
            <asp:LinkButton ID="lnkAddStaff" runat="server" OnClick="lnkAddStaff_Click">Create Staff</asp:LinkButton>
          </div>
        <asp:GridView ID="gvStaffs" runat="server" AutoGenerateColumns="false" CssClass="content-table">
            <Columns>
                <asp:BoundField HeaderText="First Name" DataField="FirstName" />
                <asp:BoundField HeaderText="Last Name" DataField="LastName" />
                <asp:BoundField HeaderText="Email Addres" DataField="EmailAddress" />
                <asp:BoundField HeaderText="Phone Number" DataField="PhoneNumber" />
                <asp:BoundField HeaderText="Type" DataField="UserType" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" runat="server" Text="<i class='fas fa-edit'></i>" ToolTip="Change Status" CommandArgument='<%#Eval("UserId") %>' OnClick="lnkEdit_Click"></asp:LinkButton> 
                        <asp:LinkButton ID="lnkDelete" runat="server" Text="<i class='fas fa-trash'></i>" ToolTip="Delete" CommandArgument='<%#Eval("UserId") %>' OnClick="lnkDelete_Click" OnClientClick='<%#Eval("UserType","return ValidateUser(\"{0}\");")%>'></asp:LinkButton> 
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <script>
        function ValidateUser(userType) {
            if (userType == "Landlord") {
                alert('You cannot delete the landlord!');
                return false;
            }
            return true;
        }
    </script>
</asp:Content>