using BusinessEntities.Employee;
using BusinessLogicLayer.EmployeeRespositroy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AllProjectsBestPractices
{
    public partial class EmployeeBonusDetails : System.Web.UI.Page
    {
        IEmployeeRepositroyBLL EmpBll = new EmployeeRepositroyBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EmployeesDataBind();
            }
        }
        private void EmployeesDataBind()
        {
            GrdEmployees.DataSource = EmpBll.GetEmployeesData();
            GrdEmployees.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Empoyees Emps = new Empoyees();

            try
            {
                foreach (GridViewRow drs in GrdEmployees.Rows)
                {
                    Emps.EmpID = Convert.ToInt32(((Label)drs.FindControl("lblempNo")).Text);
                    Emps.EMPNAME = ((Label)drs.FindControl("lblempname")).Text;
                    Emps.Designation = ((Label)drs.FindControl("lbldesignation")).Text;
                    Emps.Salary = Convert.ToInt32(((Label)drs.FindControl("lblSal")).Text);
                    Emps.BonusType = ((Label)drs.FindControl("lblbonustype")).Text;
                    string BonusValue = ((Label)drs.FindControl("lblBonusval")).Text;
                    // BonusType = dllpercentagetype.SelectedValue.ToString();
                    string FiscalYear = ddlFiscalYear.SelectedValue.ToString();
                    string Amount = ((Label)drs.FindControl("lblAmnt")).Text;

                    // Selects the text from the TextBox
                    // which is inside the GridView control
                    string Salary = ((Label)drs.FindControl("lblSal")).Text;
                    int SalValue = Convert.ToInt32(Salary);
                    int BonusVal = Convert.ToInt32(txtperValue.Text);
                    int AmountValues = (SalValue * BonusVal) / 100;
                    Emps.Amount = AmountValues;
                    Emps.BonusValue = BonusVal;

                    try
                    {
                        EmpBll.SaveEmployeesBonusData(Emps);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        protected void BtnApply_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("EMPNO", typeof(string));
            dt.Columns.Add("EMPNAME", typeof(string));
            dt.Columns.Add("Designation", typeof(string));
            dt.Columns.Add("Salary", typeof(string));
            dt.Columns.Add("BonusType", typeof(string));
            dt.Columns.Add("BonusValue", typeof(string));
            dt.Columns.Add("Amount", typeof(string));

            // Iterates through the rows of the GridView control
            foreach (GridViewRow drs in GrdEmployees.Rows)
            {
                DataRow row = dt.NewRow();

                string Empno = ((Label)drs.FindControl("lblempNo")).Text;
                string EmpName = ((Label)drs.FindControl("lblempname")).Text;
                string Designation = ((Label)drs.FindControl("lbldesignation")).Text;
                string Sal = ((Label)drs.FindControl("lblSal")).Text;
                string BonusType = ((Label)drs.FindControl("lblbonustype")).Text;
                string BonusValue = ((Label)drs.FindControl("lblBonusval")).Text;
                BonusType = dllpercentagetype.SelectedValue.ToString();
                string Amount = ((Label)drs.FindControl("lblAmnt")).Text;

                // Selects the text from the TextBox
                // which is inside the GridView control
                string Salary = ((Label)drs.FindControl("lblSal")).Text;

                int SalValue = Convert.ToInt32(Salary);

                int BonusVal = Convert.ToInt32(txtperValue.Text);

                int AmountValues = (SalValue * BonusVal) / 100;

                row["EMPNO"] = Empno;
                row["EMPNAME"] = EmpName;
                row["Designation"] = Designation;
                row["Salary"] = Sal;
                row["BonusType"] = BonusType;

                row["BonusValue"] = BonusVal;
                row["Amount"] = AmountValues;

                dt.Rows.Add(row);
            }

            dt.AcceptChanges();

            GrdEmployees.DataSource = dt;
            ViewState["Data"] = dt;
            GrdEmployees.DataBind();
        }
    }
}