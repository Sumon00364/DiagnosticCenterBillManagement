using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.Models;
using DiagnosticCenterBillManagementSystem.DataAccess;

namespace DiagnosticCenterBillManagementSystem.BusinessLogic
{
    public class TestSetupManager
    {
        TestSetupGetway testSetupGetway = new TestSetupGetway();

        public int SaveTestSetup(TestsSetup test)
        {
            return testSetupGetway.SaveTestSetup(test);
        }

        public List<TestTypeSetupView> GetAllTests()
        {
            return testSetupGetway.GetAllTestSetup();
        }

        public List<TestsSetup> GetAllTestWithoutType()
        {
            return testSetupGetway.GetAllTests();
        }

        public double GetFee(string id)
        {
            return testSetupGetway.GetFee(id);
        }
        public bool IsTestsExists(TestsSetup test)
        {
            int existsTests = testSetupGetway.GetTestSetupByName(test.Name);
            if(existsTests != 0)
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