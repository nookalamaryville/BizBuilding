<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="BizBuildingApp.MyAccount.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>BizBuilding - Property Information</title>
    <style>

        @media print {
            body * {
                visibility: hidden;
            }

            .print-container,
            .print-container * {
                visibility: visible;
            }

            .form-container {
                position: static;
            }
            @page { 
                size: auto; 
                margin: 0; 
            } 

            .print-container {
                position: absolute;
                left: 0;
                top: 0;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="myDashboard" runat="server">
    <div class="header">
        Property Information
    </div>
    <div class="info">
        <div class="row">
            <asp:Label ID="lblMessage" runat="server" CssClass="label-success"></asp:Label>
        </div>
        <div class="row">
            <div class="col-2">
                <div class="form-container">
                    <div class="row">
                        <h2>Property Details</h2>
                    </div>
                    <div class="row input-display">
                        <label for="propertyname" class="label">Property Name</label>
                        <asp:TextBox runat="server" ID="txtPropertyName" CssClass="input-text"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqPropertyName" runat="server" ControlToValidate="txtPropertyName" class="rfvstyle"
                            Display="Dynamic" ErrorMessage="Property Name is mandatory." SetFocusOnError="True"
                            ValidationGroup="g">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="row input-display">
                        <label for="address" class="label">Address</label>
                        <asp:TextBox runat="server" ID="txtAddress" CssClass="input-text"></asp:TextBox>
                    </div>
                    <div class="row input-display">
                        <label for="city" class="label">City</label>
                        <asp:TextBox runat="server" ID="txtCity" CssClass="input-text"></asp:TextBox>
                    </div>
                    <div class="row input-display">
                        <label for="state" class="label">State</label>
                        <asp:TextBox runat="server" ID="txtState" CssClass="input-text"></asp:TextBox>
                    </div>
                    <div class="row input-display">
                        <label for="zipcode" class="label">Zipcode</label>
                        <asp:TextBox runat="server" ID="txtZipcode" CssClass="input-text"></asp:TextBox>
                    </div>
                    <div class="row center">
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
            <div class="col-2">
                <div class="form-container">
                    <div class="row">
                        <h2>Property QR Code</h2>
                    </div>
                    <div class="row print-container">
                        <img src="<%=propertyQRCode %>" />
                    </div>
                    <div class="row">
                        <div><a href="JavaScript:window.print();">Print</a></div>
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
