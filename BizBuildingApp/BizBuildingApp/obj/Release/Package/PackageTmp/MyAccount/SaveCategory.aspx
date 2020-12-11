<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="SaveCategory.aspx.cs" Inherits="BizBuildingApp.MyAccount.SaveCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>BizBuilding - Save Category</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myDashboard" runat="server">
    <div class="header">
        Save Staff
    </div>
    <div class="info">
        <div class="request-demo">
            <div class="container">
                <div class="row">
                    <div class="col-2">
                        <div class="form-container">
                            <div class="row input-display">
                                <label for="txtName" class="label">Name</label>
                                <asp:TextBox runat="server" ID="txtName" CssClass="input-text"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqName" runat="server" ControlToValidate="txtName" class="rfvstyle"
                                    Display="Dynamic" ErrorMessage="Name is mandatory." SetFocusOnError="True"
                                    ValidationGroup="g">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="row input-display">
                                <label for="txtDescription" class="label">Last Name</label>
                                <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" Height="100" CssClass="input-text"></asp:TextBox>
                            </div>
                            <div class="row">
                                <a href="CategoryTypes.aspx" style="text-decoration: underline;">Cancel</a>
                                <asp:LinkButton ID="lnkSubmit" runat="server" OnClick="lnkSubmit_Click" CssClass="btn" OnClientClick="CheckValidation()">Submit</asp:LinkButton>
                            </div>
                            <div class="row">
                                <asp:Label ID="lblError" runat="server" CssClass="label-error"></asp:Label>
                                <div class="val-summary">
                                    <asp:ValidationSummary ID="Valsummery" runat="server" ValidationGroup="g" HeaderText="Errors:"
                                        ShowSummary="true" CssClass="validation-error" />
                                </div>
                            </div>
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
