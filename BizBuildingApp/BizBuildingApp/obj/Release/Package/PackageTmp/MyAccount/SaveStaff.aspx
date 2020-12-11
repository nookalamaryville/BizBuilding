<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="SaveStaff.aspx.cs" Inherits="BizBuildingApp.MyAccount.SaveStaff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>BizBuilding - Save Staff</title>
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
                                <label for="txtFirstName" class="label">First Name</label>
                                <asp:TextBox runat="server" ID="txtFirstName" CssClass="input-text"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqFirstName" runat="server" ControlToValidate="txtFirstName" class="rfvstyle"
                                    Display="Dynamic" ErrorMessage="First Name is mandatory." SetFocusOnError="True"
                                    ValidationGroup="g">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="row input-display">
                                <label for="txtLastName" class="label">Last Name</label>
                                <asp:TextBox runat="server" ID="txtLastName" CssClass="input-text"></asp:TextBox>
                            </div>
                            <div class="row input-display">
                                <label for="txtEmailAddress" class="label">Email Address</label>
                                <asp:TextBox runat="server" ID="txtEmailAddress" CssClass="input-text"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqEmailAddress" runat="server" ControlToValidate="txtEmailAddress" class="rfvstyle"
                                    Display="Dynamic" ErrorMessage="Email Address is mandatory." SetFocusOnError="True"
                                    ValidationGroup="g">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="regEmailAddress" runat="server" ControlToValidate="txtEmailAddress" class="rfvstyle"
                                    Display="Dynamic" ErrorMessage="Invalid Email Format." SetFocusOnError="True"
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="g">*</asp:RegularExpressionValidator>
                            </div>
                            <div class="row input-display">
                                <label for="txtPhoneNumber" class="label">Phone Number</label>
                                <asp:TextBox runat="server" ID="txtPhoneNumber" CssClass="input-text" onkeyup="FormatPhoneNumber(this,event,2);"></asp:TextBox>
                            </div>
                            <div class="row input-display">
                                <label for="txtPhoneNumber" class="label">Staff Type</label>
                                <asp:DropDownList ID="ddlUserType" runat="server">
                                    <asp:ListItem Value="" Text="-- Select Type --"></asp:ListItem>
                                    <asp:ListItem Value="Landlord" Text="Landlord" Enabled="false"></asp:ListItem>
                                    <asp:ListItem Value="Manager" Text="Manager"></asp:ListItem>
                                    <asp:ListItem Value="Staff" Text="Staff"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="row input-display">
                                <label for="txtPassword" class="label">Password</label>
                                <asp:TextBox ID="txtPassword" TextMode="Password" Text="enter password" class="input-text"
                                    runat="server" ValidationGroup="g" CausesValidation="True" autocomplete="off"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqPassword" runat="server" ControlToValidate="txtPassword" class="rfvstyle"
                                    ErrorMessage="Password is mandatory." SetFocusOnError="True" ValidationGroup="g">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="row">
                                <a href="staffs.aspx" style="text-decoration: underline;">Cancel</a>
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
    <script>
        function CheckValidation() {
            if (!Page_ClientValidate("g"))
                return false;

        }
        function FormatPhoneNumber(id, event, Vtype) {
            // Allow: backspace, delete, tab, escape, and enter // Allow: home, end, left, right
            if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 13 ||
                (event.keyCode >= 35 && event.keyCode <= 39)) {
                return;
            }
            else {
                // Ensure that it is a number and stop the keypress
                if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
                    event.preventDefault();
                }
            }
            val = id.value.replace(/\D/g, '');
            var newVal = '';
            if (val.length > 10) {
                val = val.substring(0, 10)
            }
            while (val.length >= 3 && newVal.length <= 7) {
                newVal += val.substr(0, 3) + '-';
                val = val.substr(3);
            }
            newVal += val;
            id.value = newVal;
            if (newVal.length == 12) {
                if (newVal.length == 12) {
                    window.setTimeout(function () { id.focus(); }, 0);
                }
                if (Vtype == "3") {
                    document.getElementById('<%=txtPhoneNumber.ClientID %>').style.display = "none";
                }
            }
            else {

                if (Vtype == "3") {
                    document.getElementById('<%=txtPhoneNumber.ClientID %>').style.display = "none";

                }

            }
        }
    </script>
</asp:Content>
