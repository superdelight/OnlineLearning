
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FullPay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
              string matricNo = Page.User.Identity.Name.Trim();
            //string matricNo = "15000131";
                try
                {

                    RsView.RsViewModelClient context = new RsView.RsViewModelClient();
                    PayServ.PaymentServiceClient payCloud = new PayServ.PaymentServiceClient();
                    var currentSession=context.GetCurrentSession();
                   // var previousSession=context.GetPreviousSession();
                    var student = context.GetFullName(matricNo);
                    var fuulPament = payCloud.GetFullSchoolFeeSessionPay(currentSession.Id);
                    // var payment = payConfig.GetAllItems().Where(c => c.FacId == dept.FacId && c.PayDescription.ToLower().Contains(gg.ToString().ToLower())).FirstOrDefault();
                    lbMsg.Text = fuulPament.Description;
                   
                        var studentPrevInvoice=payCloud.GetStudentPreviousInvoice(matricNo);
                        if (payCloud.ConfirmInvoiceisWithOutstandingPayment(studentPrevInvoice.Id)==false)
                        {
                            var studentLev = context.GetStudentLevel(matricNo, currentSession.Id);
                            var currentInvoice = payCloud.GetStudentCurrentInvoice(matricNo);
                            if (payCloud.ConfirmStudentInvoiceWithAnyPayment(studentLev.Id) == false)
                            {
                                Label1.Text = string.Format("<h2>Hi {0},</h2><br/> Welcome to LAUTECH Open and Distance Learning School Fee Payment Platform. You will be redirected to our payment engine where your payment will be done.<br/>", student);

                                double amount = (double)fuulPament.TotalAmount;
                                lbAmout.Text = string.Format("=N={0:N2}", amount);
                                personFullName.Value = student;
                                personNumber.Value = matricNo;
                                TransactionAmount.Value = amount.ToString();
                                paymentDescription.Value = lbMsg.Text;
                                schoolDet.Value = "LAUTECH ODL";
                                string DomainName = HttpContext.Current.Request.Url.Host;
                                int port = HttpContext.Current.Request.Url.Port;
                                RedirectedPage.Value = "http://lodlc.lautech.edu.ng/home/FeeResponse.aspx";
                                paymentSplit.Value = string.Format("1&1014795225&{0}&117&{1}", amount, paymentDescription.Value);
                            }
                            else
                            {
                                Label1.Text = string.Format("<h2>Hi {0},</h2><br/> Welcome to LAUTECH Open and Distance Learning School Fee Payment Platform. Your payment cannot be processed...<br/>", student);
                                Button1.Enabled = false;
                            }
                        }
                        else
                        {
                            Label1.Text = string.Format("<h2>Hi {0},</h2><br/> Welcome to LAUTECH Open and Distance Learning School Fee Payment Platform. You must first pay for your outstanding before you can proceed...<br/>", student);
                            Button1.Enabled = false;
                        }
                }
                catch(Exception ex)
                {
                    Response.Write(ex.Message);//"Unable to proceed...");
                }
            }
        
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}

