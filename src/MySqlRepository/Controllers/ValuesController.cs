using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySqlRepository.Common;
using MySql.Data.MySqlClient;
using MySqlRepository.Models;

namespace MySqlRepository.Controllers
{
    [Route("api")]
    public class ValuesController : Controller
    {

        [HttpGet("GetDepartment/{id}", Name = "GetDepartment")]
        public List<Department> GetDepartment(int id)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "Planogram";
            List<Department> departmentList = new List<Department>();
            //return new string[] { "value1", "value2" };
            
            try
            {
                if (dbCon.IsConnect())
                {
                    //suppose col0 and col1 are defined as VARCHAR in the DB
                    string query = "SELECT * FROM Department where StoreNbr = " + id;
                    var cmd = new MySqlCommand(query, dbCon.Connection);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var department = new Department();
                        department.Departmentname = reader.GetString("Departmentname");
                        department.DepartmentNbr = Convert.ToInt32(reader.GetString("DepartmentNbr"));
                        department.PlanogramCount = Convert.ToInt32(reader.GetString("PlanogramCount"));
                        department.StoreNbr = Convert.ToInt32(reader.GetString("StoreNbr"));

                        departmentList.Add(department);

                        //departmentList.Append(department);

                    }
                    reader.Close();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            } 
           
            return departmentList;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
         var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "Planogram";
            if (dbCon.IsConnect())
            {
                //suppose col0 and col1 are defined as VARCHAR in the DB
                string query = "SELECT * FROM Department";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string someStringFromColumnZero = reader.GetString(0);
                    string someStringFromColumnOne = reader.GetString(1);
                    Console.WriteLine(someStringFromColumnZero + "," + someStringFromColumnOne);
                }
            }

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
