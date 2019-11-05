using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLib;
using MusicRest.Controllers;
using MusicRest.DBUtil;

namespace CompleteTest
{
    [TestClass]
    public class UnitTest1
    {

        #region InstanceFields

        private RecordsController _manager;

        #endregion

        [TestInitialize]
        public void TestInit()
        {
            _manager = new RecordsController();

        }

        [TestMethod]
        public void TestMethod1()
        {
            List<Record> records = new List<Record>() {
                new Record("Hoarchim Da!", "Roachim", 56.3, 2000),
                new Record("Kono Andu Da!", "Andu", 29.4, 2018),
                new Record("Kono Nikolai Da!", "Nikolairu", 30, 2019)
            };

            List<Record> testRecords = (List<Record>)_manager.Get();

            Assert.AreEqual(records[0], testRecords[0]);
            Assert.AreEqual(records[1], testRecords[1]);
            Assert.AreEqual(records[2], testRecords[2]);

        }

        [TestMethod]
        public void TestGetOneByTitle()
        {
            RecordManager manager = new RecordManager();

            int Result = manager.GetByTitle("i").Count;

            Assert.AreEqual(2, Result);
        }

    }
}
