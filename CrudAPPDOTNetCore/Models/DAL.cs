using System.Data;
using System.Data.SqlClient;

namespace CrudAPPDOTNetCore.Models
{
    public class DAL
    {

        public Response GetAllEmployes(SqlConnection connection)
        {
            Response response= new Response();
            SqlDataAdapter da = new SqlDataAdapter("select * from produit",connection);
            DataTable dt=new DataTable();
            da.Fill(dt);
            List<Employee> lstemployees = new List<Employee>();
             if(dt.Rows.Count>0 )
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    employee.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    employee.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    employee.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                    lstemployees.Add(employee);
                }
            }
             if(lstemployees.Count > 0 )
            {
                response.StatusCode = 200; //success
                response.StatusMessage = "data found";
                response.listEmploye=lstemployees;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "data not foudn";
                response.listEmploye = null;
            }

            return response;
        }
        public Response GetAllEmployesById(SqlConnection connection,int id)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("select * from produit where id='"+id+"' AND IsAcive=1", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Employee employees = new Employee();
            if (dt.Rows.Count > 0)
            {
                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                    employee.Name = Convert.ToString(dt.Rows[0]["Name"]);
                    employee.Email = Convert.ToString(dt.Rows[0]["Email"]);
                    employee.IsActive = Convert.ToInt32(dt.Rows[0]["IsActive"]);
                    response.StatusCode = 200; //success
                    response.StatusMessage = "data found";
                    response.Employee = employee;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "NO DATA FOUDN";
                response.Employee = null;
            }
            return response;
        }
        public Response AddEmploye(SqlConnection connection, Employee employe)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("insert into produit (Name,Email,IsActive,CreatedOn) values('"+employe.Name+"','"+employe.Email+"','"+employe.IsActive+"',GETDATE())", connection);
            connection.Open();
            int i=cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200; //success
                response.StatusMessage = "data employee saved";
                
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "not saved";
                
            }
            return response;
        }
        public Response UpdateEmploye(SqlConnection connection, Employee employe)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("update  produit set Name='"+employe.Name+"',Email='"+employe.Email+"'  where ID='"+employe.Id+"'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200; //success
                response.StatusMessage = "data updated";

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "no data updated";

            }
            return response;
        }
        public Response DeleteEmploye(SqlConnection connection, int id)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("delete from produit where ID='"+id+"", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200; //success
                response.StatusMessage = "data employee deleted";

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "not deleted";

            }
            return response;
        }
    }
}
