using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.DataAccess;
using DiagnosticCenterBillManagementSystem.Models;

namespace DiagnosticCenterBillManagementSystem.BusinessLogic
{
    public class PatientInfoManager
    {
        PatientGetway patientGetway = new PatientGetway();

        public int SavePatient(Patient patient)
        {
            return patientGetway.SavePatient(patient);
        }
        public bool IsPatientExist(Patient patient)
        {
            int countPatient = patientGetway.GetPatientByMobile(patient.Mobile);
            if(countPatient !=0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int SavePatientTest(PatientTest test, TestsSetup set)
        {
            return patientGetway.SavePatientTest(test,set);
        }
    }
}