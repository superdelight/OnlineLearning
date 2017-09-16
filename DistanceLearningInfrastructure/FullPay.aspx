<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FullPay.aspx.cs" Inherits="FullPay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>::SCHOOL FEE PAYMENT::</title>
    <link href='//fonts.googleapis.com/css?family=Raleway:300,400,600,700,800' rel='stylesheet' type='text/css' />
    <link href='//fonts.googleapis.com/css?family=Open+Sans:300,400,600,700,800' rel='stylesheet' type='text/css' />
    <!-- / Fonts -->
    <link rel="stylesheet" href="../My/styles/vendor/bootstrap-tagsinput.css" />
    <link rel="stylesheet" href="../My/styles/vendor/chosen.min.css" />
    <!-- Style Sheets -->
    <link rel="stylesheet" href="../My/vendor/pace-theme-minimal.css" />
    <link rel="stylesheet" href="../My/styles/vendor/bootstrap.min.css" />
    <link rel="stylesheet" href="../My/styles/vendor/metisMenu.min.css" />
    <link rel="stylesheet" href="../My/styles/vendor/animate.min.css" />
    <link rel="stylesheet" href="../My/styles/vendor/toastr.min.css" />
    <link rel="stylesheet" href="../My/styles/vendor/font-awesome.min.css" />
    <link rel="stylesheet" href="../My/styles/style.min.css" />
    <link rel="stylesheet" href="../My/styles/themes/theme-all.min.css" />
    <link rel="stylesheet" href="../My/styles/demo.min.css" />
    </head>
<body>
    <form id="form1" runat="server">
        <div style="width:100%;" align="center">
        <div style=" width: 852px; padding-top: 50px;">
            <div class="row" align="left">
                <div class="col-md-12">

                    <div class="panel panel-danger">
                        <div class="panel-heading">
                            <div class="panel-title">
                                Payment|<b><asp:Label ID="lbMsg" runat="server"></asp:Label>
                                </b>
                            </div>
                        </div>
                        <div class="panel-body">

                            <div>
                                <div class="col-sm-12">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <div class="single-container register-screen animated rubberBand">

                                                <asp:Label ID="Label1" runat="server"></asp:Label>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div style="margin-bottom:20px;padding-left:15px; font-style: italic; font-size: small; font-weight: 700;">
                              
                                 You are going to pay School Fee of&nbsp;
                                    <asp:Label ID="lbAmout" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="Red" Text="=N=100,000.00"></asp:Label>
&nbsp;only.
                                
                                </div>
                                <div class="col-sm-12">

                                    <asp:Button ID="Button1" runat="server" Text="Pay Now" CssClass="btn btn-inverse" Height="45px" Width="165px" OnClick="Button1_Click" PostBackUrl="http://lodlc.lautech.edu.ng/paynow/" />

                                </div>
                                    

                            </div>
                        </div>
                        <div class="panel-footer panel-footer-color">
                            <i class="fa fa-chevron-left"></i>
                            <i class="fa fa-chevron-right"></i>
                        </div>
                    </div>

                </div>
            </div>

        </div>

        <div>

            <asp:HiddenField ID="personNumber" runat="server" />
            <asp:HiddenField ID="personFullName" runat="server" />
            <asp:HiddenField ID="TransactionAmount" runat="server" />
            <asp:HiddenField ID="paymentDescription" runat="server" />
            <asp:HiddenField ID="RedirectedPage" runat="server" />
            <asp:HiddenField ID="paymentSplit" runat="server" />

            <asp:HiddenField ID="schoolDet" runat="server" />

        </div>
            </div>
    </form>
</body>
</html>
