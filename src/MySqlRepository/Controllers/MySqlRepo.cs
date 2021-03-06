﻿using System;
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
    public class MySqlRepo : Controller
    {

        [HttpGet("GetDepartment/{storeNbr}", Name = "GetDepartment")]
        public List<Department> GetDepartment(int storeNbr)
        {

            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "Planogram";
            List<Department> departmentList = new List<Department>();

            MySqlDataReader reader = null; //cmd.ExecuteReader();
            try
            {
                string query = "SELECT * FROM Department where StoreNbr = " + storeNbr;

                    dbCon.IsConnect();
                    var cmd = new MySqlCommand(query, dbCon.Connection);
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var department = new Department();
                        department.Departmentname = reader.GetString("Departmentname");
                        department.DepartmentNbr = Convert.ToInt32(reader.GetString("DepartmentNbr"));
                        department.PlanogramCount = Convert.ToInt32(reader.GetString("PlanogramCount"));
                        department.StoreNbr = Convert.ToInt32(reader.GetString("StoreNbr"));

                        departmentList.Add(department);
                    }
                }
            

            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }

            finally
            {
                reader.Close();
                dbCon.Close();  
            }   
           
            return departmentList;
        }


        [HttpGet("GetPlanograms/{storeNbr}/{DeptNbr}", Name = "GetPlanograms")]
        public List<Planogram> GetPlanograms(int storeNbr, int DeptNbr)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "Planogram";
            List<Planogram> planogramList = new List<Planogram>();
            MySqlDataReader reader = null;
            try
            {
                if (dbCon.IsConnect())
                {
                    string query = "SELECT * FROM Planogram where StoreNbr = " + storeNbr + " and DeptNbr = " + DeptNbr;
                    var cmd = new MySqlCommand(query, dbCon.Connection);
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var planogram = new Planogram();
                        planogram.StoreNbr = Convert.ToInt32(reader.GetString("StoreNbr"));
                        planogram.DeptNbr = Convert.ToInt32(reader.GetString("DeptNbr"));
                        planogram.UPCNbr = Convert.ToInt32(reader.GetString("UPCNbr"));
                        planogram.PlanogramId = Convert.ToInt32(reader.GetString("PlanogramId"));
                        planogram.ModularPlanId = Convert.ToInt32(reader.GetString("ModularPlanId"));

                        planogram.CategoryNbr = reader.GetString("CategoryNbr");
                        planogram.CategoryName = reader.GetString("CategoryName");
                        planogram.PlanogramDesc = reader.GetString("PlanogramDesc");
                        planogram.EffectiveFrom = Convert.ToDateTime(reader.GetString("EffectiveFrom"));


                        planogram.DiscontinueDate = Convert.ToDateTime(reader.GetString("DiscontinueDate"));
                        planogram.Width = reader.GetString("Width");

                        planogramList.Add(planogram);
                    }
                    
                }
            }

            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }

            finally
            {
                reader.Close();
                dbCon.Close();
            }
            
            return planogramList;

        }





        [HttpGet("GetPlanogramsOnUPC/{UPCNbr}", Name = "GetPlanogramsOnUPC")]
        public List<Planogram> GetPlanograms(int UPCNbr)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "Planogram";
            List<Planogram> planogramList = new List<Planogram>();
            MySqlDataReader reader = null;
            try
            {
                if (dbCon.IsConnect())
                {
                    string query = "SELECT * FROM Planogram where UPCNbr = " + UPCNbr ;
                    var cmd = new MySqlCommand(query, dbCon.Connection);
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var planogram = new Planogram();
                        planogram.StoreNbr = Convert.ToInt32(reader.GetString("StoreNbr"));
                        
                        planogram.DeptNbr = Convert.ToInt32(reader.GetString("DeptNbr"));
                        planogram.UPCNbr = Convert.ToInt32(reader.GetString("UPCNbr"));
                        planogram.PlanogramId = Convert.ToInt32(reader.GetString("PlanogramId"));
                        planogram.ModularPlanId = Convert.ToInt32(reader.GetString("ModularPlanId"));

                        planogram.CategoryNbr = reader.GetString("CategoryNbr");
                        planogram.CategoryName = reader.GetString("CategoryName");
                        planogram.PlanogramDesc = reader.GetString("PlanogramDesc");
                        planogram.EffectiveFrom = Convert.ToDateTime(reader.GetString("EffectiveFrom"));


                        planogram.DiscontinueDate = Convert.ToDateTime(reader.GetString("DiscontinueDate"));
                        planogram.Width = reader.GetString("Width");

                        planogramList.Add(planogram);
                    }
                }
            }

            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }

            finally
            {
                reader.Close();
                dbCon.Close();
            }

            return planogramList;

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
