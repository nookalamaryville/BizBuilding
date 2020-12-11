<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="LogDetails.aspx.cs" Inherits="BizBuildingApp.MyAccount.LogDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>BizBuilding - Comaplaint Information</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myDashboard" runat="server">
    <div class="header">
        Comaplaint Information
    </div>
    <div class="info">
        <div class="row">
            <asp:Label ID="lblMessage" runat="server" CssClass="label-error"></asp:Label>
        </div>
        <div class="row">
            <div class="col-2">
                <div class="form-container">    
                    <div class="row input-display">
                        Category: <asp:Label ID="lblCategory" runat="server"></asp:Label>
                    </div>                
                    <div class="row input-display">
                        Location: <asp:Label ID="lblLocation" runat="server"></asp:Label>
                    </div>
                    <div class="row input-display">
                        Category: <asp:Label ID="lblDescription" runat="server"></asp:Label>
                    </div>
                    <div class="row input-display">
                        Requested Date: <asp:Label ID="lblRequestedDate" runat="server"></asp:Label>
                    </div>
                    <div class="row input-display">
                        Completed Date: <asp:Label ID="lblCompletedDate" runat="server"></asp:Label>
                    </div>
                    <div class="row input-display">
                        <label for="state" class="label">Status</label>
                        <asp:DropDownList ID="ddlStatus" runat="server">
                            <asp:ListItem Text="New" Value ="New" />
                            <asp:ListItem Text="Processing" Value ="Processing" />
                            <asp:ListItem Text="Completed" Value ="Completed" />
                        </asp:DropDownList>
                    </div>
                    <div class="row input-display">
                        <label for="zipcode" class="label">Assigned To</label>
                        <asp:DropDownList ID="ddlUsers" runat="server" AppendDataBoundItems="true" DataValueField="UserId" DataTextField="FullName">
                            <asp:ListItem Text="-- Select a staff" Value ="" />
                        </asp:DropDownList>
                    </div>
                    <div class="row center">
                        <a href="Default.aspx" style="text-decoration: underline;">Cancel</a>
                        <asp:LinkButton ID="lnkSave" runat="server" OnClick="lnkSave_Click" CssClass="btn" OnClientClick="return CheckValidation();">Save</asp:LinkButton>
                    </div>
                    <div class="row">
                        <div class="val-summary">
                            <asp:ValidationSummary ID="Valsummery" runat="server" ValidationGroup="g" HeaderText="Errors:"
                                ShowSummary="true" CssClass="validation-error" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function CheckValidation() {
            if (!Page_ClientValidate("g"))
                return false;

        }
    </script>
</asp:Content>
