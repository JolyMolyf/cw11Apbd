using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using cw11Solution.Models;
using Microsoft.EntityFrameworkCore;

namespace cw11Solution.Services
{
    public class DbService : IDbservice
    {
        private readonly DataBaseContext dbContext;
        public DbService(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void randomize()
        {
           List<String> names = new List<string>()
           {
               "Greg", "Lewis", "Nick", "Neik", "David", "Onil" 
           };
           List<String> lastname = new List<string>()
           {
               "Hou", "Mod", "Ads", "Doid", "Adams", "Smith"
           };
           
           
           Patient pt = new Patient();

           pt.IdPatient = 1;
           pt.FirstName = names.PickRandom();
           pt.LastName = lastname.PickRandom(); 
           pt.BirthDate = DateTime.Now;

           dbContext.Attach(pt);
           dbContext.SaveChanges(); 


        }

        public IEnumerable<Doctor> getDoctor()
        {
            var doctors = dbContext.Doctors.ToList(); 
           
           return doctors; 

        }

        public void deleteDoctor(String id)
        {
            IQueryable<Doctor> doc = dbContext.Doctors.Where(d => d.IdDoctor == Int32.Parse(id)); 
            dbContext.Doctors.Remove(doc.First());
            dbContext.SaveChanges();
        }

        public void updateDoctor(Doctor doctor)
        {
            dbContext.Doctors.Attach(doctor);
            dbContext.Entry(doctor).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void addDoctor(Doctor doctor)
        {
            dbContext.Add(doctor);
            dbContext.SaveChanges();
        }
    }
}