<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="BizBuildingApp.SignUp" EnableEventValidation="false" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>BizBuilding - Sign Up</title>
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
                                <img src="./images/logo.png" alt="BizBuilding - Tenant Issue Tracking System"
                                    aria-label="BizBuilding - Tenant Issue Tracking System" /></a>
                        </div>
                        <nav>
                        </nav>
                        <a href="signin.aspx" class="btn home-singin">SIGN IN</a>
                    </div>
                </div>
            </div>
            <div class="request-demo">
                <div class="container">
                    <div class="row">
                        <div class="col-2">
                            <div class="form-container">
                                <div class="row">
                                    <h2>Get your free account!</h2>
                                </div>
                                <div class="row input-display">
                                    <label for="propertyname" class="label">Property Name</label>
                                    <asp:TextBox runat="server" ID="txtPropertyName" CssClass="input-text"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqPropertyName" runat="server" ControlToValidate="txtPropertyName" class="rfvstyle"
                                        Display="Dynamic" ErrorMessage="Property Name is mandatory." SetFocusOnError="True"
                                        ValidationGroup="g">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="row input-display">
                                    <label for="emailaddress" class="label">Email Address</label>
                                    <asp:TextBox runat="server" ID="txtEmailAddress" CssClass="input-text"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqEmailAddress" runat="server" ControlToValidate="txtEmailAddress" class="rfvstyle"
                                        Display="Dynamic" ErrorMessage="Email Address is mandatory." SetFocusOnError="True"
                                        ValidationGroup="g">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="regEmailAddress" runat="server" ControlToValidate="txtEmailAddress" class="rfvstyle"
                                        Display="Dynamic" ErrorMessage="Invalid Email Format." SetFocusOnError="True"
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="g">*</asp:RegularExpressionValidator>
                                </div>
                                <div class="row input-display">
                                    <label for="password" class="label">Password</label>
                                    <asp:TextBox ID="txtPassword" TextMode="Password" Text="enter password" class="input-text"
                                        runat="server" ValidationGroup="g" CausesValidation="True" autocomplete="off"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" class="rfvstyle"
                                        ErrorMessage="Password is mandatory." SetFocusOnError="True" ValidationGroup="g">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="row">
                                    <a href="index.html" style="text-decoration: underline;">Cancel</a>
                                    <asp:Button ID="btnSignUp" runat="server" Text="Create Account" ValidationGroup="g" OnClick="btnSignUp_Click"
                                        class="btn" OnClientClick="CheckValidation()" />
                                </div>
                                <div class="row">
                                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
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
            </div>
        </div>
        <!-- Footer Section-->
        <div class="footer">
            <div class="container">
                <p>Copyright <span id="dtyear"></span>- BizBuilding</p>
            </div>
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
