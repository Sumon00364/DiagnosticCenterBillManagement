using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.DataAccess;
using DiagnosticCenterBillManagementSystem.Models;

namespace DiagnosticCenterBillManagementSystem.BusinessLogic
{
    public class TestTypeManager
    {
        TestTypeGetway testTypeGetway = new TestTypeGetway();

        public int SaveTestType(TestType testType)
        {
            return testTypeGetway.SaveTestType(testType);
        }

        public List<TestType> GetAllTestType()
        {
            return testTypeGetway.GetAllTestType();
        }

        public bool IsTestTypeExists(TestType test)
        {
            int existingTest = testTypeGetway.GetTestTypeByName(test.Name);

            if(existingTest != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}