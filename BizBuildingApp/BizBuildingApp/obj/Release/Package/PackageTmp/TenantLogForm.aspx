<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TenantLogForm.aspx.cs" Inherits="BizBuildingApp.TenantLogForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BizBuilding - Tenant Complaint Form</title>
    <link rel="stylesheet" href="./Content/style.css" />
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@200;300;400;500;600;700&display=swap"
        rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="page-container">
            <div class="header">
                <div class="container">
                    <div class="navbar">
                        <div class="logo">
                            <a href="index.html">
                                <img src="./images/logo.png"
                                    alt="BizBuilding - Tenant Issue Tracking System"
                                    aria-label="BizBuilding - Tenant Issue Tracking System" /></a>
                        </div>
                        <nav>
                        </nav>
                    </div>
                </div>
            </div>
            <div id="content-wrap">
                <div class="request-demo">
                    <div class="container">
                        <div class="row">
                            <div class="col-2">
                                <div class="form-container">
                                    <div class="row">
                                        <h2>Complaint Form</h2>
                                    </div>
                                    <div class="row input-display">
                                        <label for="categories">Category:</label>
                                        <asp:DropDownList ID="ddlCategories" runat="server" DataValueField="CategoryId" DataTextField="Name" AppendDataBoundItems="true">
                                            <asp:ListItem Text="-- Select Item --" Value="" />
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="reqddlCategories" runat="server" ControlToValidate="ddlCategories" class="rfvstyle"
                                            ErrorMessage="Category is mandatory." ValidationGroup="g">*</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="row input-display">
                                        <label for="location" class="label">Location/Suit No</label>
                                        <asp:TextBox ID="txtLocation" class="input-text"
                                            runat="server" ValidationGroup="g" CausesValidation="True" autocomplete="off"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="reqtxtLocation" runat="server" ControlToValidate="txtLocation" class="rfvstyle"
                                            ErrorMessage="Location is mandatory." ValidationGroup="g">*</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="row input-display">
                                        <label for="description" class="label">Description</label>
                                        <asp:TextBox TextMode="MultiLine" runat="server" ID="txtDescription" Height="100px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="reqtxtDescription" runat="server" ControlToValidate="txtDescription" class="rfvstyle"
                                            ErrorMessage="Descrption is mandatory." ValidationGroup="g">*</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="row">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="g" OnClick="btnSubmit_Click"
                                            class="btn" OnClientClick="CheckValidation()" Border="0" />
                                    </div>
                                    <div class="row">
                                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
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
            <!-- Footer Section-->
            <footer id="footer">
                <div class="footer">
                    <div class="container">
                        <p>Copyright <span id="dtyear"></span>- BizBuilding</p>
                    </div>
                </div>
            </footer>
        </div>
        <script type="text/javascript">
            function CheckValidation() {
                if (!Page_ClientValidate("g"))
                    return false;
            }
        </script>
    </form>
</body>
</html>
