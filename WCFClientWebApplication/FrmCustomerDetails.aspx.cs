using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WCFClientWebApplication.CustomerService;

namespace WCFClientWebApplication
{
    public partial class FrmCustomerDetails : System.Web.UI.Page
    {
        CustomerService.ServiceClient CustomerServiceProxy = new CustomerService.ServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindCustomerData();
            }
        }

        private void BindCustomerData()
        {
            try
            {
                GrdCustomer.DataSource = CustomerServiceProxy.GetCustomerData();
                GrdCustomer.DataBind();
            }

            catch (FaultException<CustomerService.ServiceExceptions> ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void GrdCustomer_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GrdCustomer.EditIndex)
            {
            }
        }

        protected void GrdCustomer_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GrdCustomer.EditIndex = e.NewEditIndex;
            this.BindCustomerData();
        }

        protected void GrdCustomer_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GrdCustomer.EditIndex = -1;
            this.BindCustomerData();
        }

        protected void GrdCustomer_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Customers Cust = null;

            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    Cust = new Customers();
                    GridViewRow row = GrdCustomer.Rows[e.RowIndex];
                    Cust.CustomerID = Convert.ToString(GrdCustomer.DataKeys[e.RowIndex].Values[0]);
                    Cust.Name = (row.FindControl("txtName") as TextBox).Text;
                    Cust.Address = (row.FindControl("txtAddress") as TextBox).Text;
                    Cust.Mobileno = (row.FindControl("txtMobileno") as TextBox).Text;
                    Cust.EmailID = (row.FindControl("txtemailId") as TextBox).Text;
                    CustomerServiceProxy.UpdateCustomerData(Cust);

                    ts.Complete();

                    GrdCustomer.EditIndex = -1;
                    this.BindCustomerData();
                }
                catch (FaultException<CustomerService.ServiceExceptions> ex)
                {
                    ts.Dispose();
                    Response.Write(ex.Message);
                }
                finally
                {
                    Cust = null;
                }
            }
        }

        protected void GrdCustomer_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Customers Cust = new Customers();

            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    Cust.CustomerID = Convert.ToString(GrdCustomer.DataKeys[e.RowIndex].Values[0]);
                    CustomerServiceProxy.DeletCustomerData(Cust);
                    ts.Complete();

                    GrdCustomer.EditIndex = -1;
                    this.BindCustomerData();
                }
                catch (FaultException<CustomerService.ServiceExceptions> ex)
                {
                    ts.Dispose();
                    Response.Write(ex.Message);
                }
                finally
                {
                    Cust = null;
                }
            }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Customers Cust = null;

            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    Cust = new Customers();

                    Cust.CustomerID = txtCustID.Text;
                    Cust.Name = txtName.Text;
                    Cust.Address = txtAddress.Text;
                    Cust.Mobileno = txtMobile.Text;
                    Cust.EmailID = txtEmailid.Text;
                    CustomerServiceProxy.SaveCustomerData(Cust);
                    this.BindCustomerData();
                }
                catch (FaultException<CustomerService.ServiceExceptions> ex)
                {
                    ts.Dispose();
                    Response.Write(ex.Message);
                }
                finally
                {
                    Cust = null;
                }
            }
        }
    }
}