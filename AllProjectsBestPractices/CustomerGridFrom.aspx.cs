using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer.CustomerRespository;
using BusinessEntities.Customer;

namespace AllProjectsBestPractices
{
    public partial class CustomerGridFrom : System.Web.UI.Page
    {
        CustomerRespositoryBLL CustBll = new CustomerRespositoryBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCustomerData();
            }
        }

        private void BindCustomerData()
        {
            try
            {
                GrdCustomer.DataSource = CustBll.GetCustomerData();
                GrdCustomer.DataBind();
            }
            catch(Exception ex)
            {
            }
        }

        protected void GrdCustomer_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GrdCustomer.EditIndex)
            {
               // (e.Row.Cells[7].Controls[7] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
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

            try
            {
                Cust = new Customers();

                GridViewRow row = GrdCustomer.Rows[e.RowIndex];
                Cust.CustomerID = Convert.ToString(GrdCustomer.DataKeys[e.RowIndex].Values[0]);
                Cust.Name = (row.FindControl("txtName") as TextBox).Text;
                Cust.Address = (row.FindControl("txtAddress") as TextBox).Text;
                Cust.Mobileno = (row.FindControl("txtMobileno") as TextBox).Text;
                Cust.EmailID = (row.FindControl("txtemailId") as TextBox).Text;
                CustBll.UpdateCustomerData(Cust);

                GrdCustomer.EditIndex = -1;
                this.BindCustomerData();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Cust = null;
            }
        }

        protected void GrdCustomer_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Customers Cust = new Customers();
            try
            {
                Cust.CustomerID = Convert.ToString(GrdCustomer.DataKeys[e.RowIndex].Values[0]);

                CustBll.DeleteCustomerData(Cust);
                GrdCustomer.EditIndex = -1;
                this.BindCustomerData();
            }
            catch(Exception ex)
            {
            }
            finally
            {
                Cust = null;
            }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Customers Cust = new Customers();
            try
            {
                Cust.CustomerID = txtCustID.Text;
                Cust.Name = txtName.Text;
                Cust.Address = txtAddress.Text;
                Cust.Mobileno = txtMobile.Text;
                Cust.EmailID = txtEmailid.Text;
                CustBll.InsertCustomerData(Cust);
                this.BindCustomerData();
            }
            catch(Exception ex)
            {
            }
            finally
            {
                Cust = null;
            }
        }
    }
}