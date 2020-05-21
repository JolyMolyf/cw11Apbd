using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw11Solution.Models;
using cw11Solution.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cw11Solution.Controllers
{
    [Route("api")]
    [ApiController]
    public class Clinic : ControllerBase
    {
        private IDbservice dbservice;

        public Clinic(IDbservice dbservice)
        {
            this.dbservice = dbservice;
        }


        [HttpGet]
        public IEnumerable<Doctor> Get()
        {
            Console.WriteLine("get");
            return dbservice.getDoctor();
        }

        [HttpPut("add")]
        public void addDoctor(Doctor doctor)
        {
            Console.WriteLine("Added");
            dbservice.addDoctor(doctor);
        }

        [HttpPut("update")]
        public void UpdateDoctor(Doctor doctor)
        {
            Console.WriteLine("Modified");
            dbservice.updateDoctor(doctor);
        }

        [HttpDelete("Delete/{Id}")]
        public void DeleteDoctor(string id)
        {
            Console.WriteLine("Deleted");
            dbservice.deleteDoctor(id);
        }

        [HttpGet("addPatients")]
        public void addPatients()
        {
            dbservice.randomize();
        }
    }
}