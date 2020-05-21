using System;
using System.Collections;
using System.Collections.Generic;
using cw11Solution.Models;

namespace cw11Solution.Services
{
    public interface IDbservice
    {

        public void randomize();

        public IEnumerable<Doctor> getDoctor();
        public void deleteDoctor(String id);
        public void updateDoctor(Doctor doctor);
        public void addDoctor(Doctor doctor); 
    }
}