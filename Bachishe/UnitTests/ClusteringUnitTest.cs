using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clustering;
using Clustering.Clusterizators;
using Clustering.DataBase;
using Clustering.Managers;
using Clustering.Normalizers;
using Clustering.Objects;

namespace TestProjectForClustering
{
    [TestClass]
    public class ClusteringUnitTest
    {
        private RawSet rs;
        double[] vars = { 0.5, 123.2, 300 };

        [TestInitialize]
        public void ArrangeSet()
        {
            rs = new RawSet();
            foreach (var num in vars)
            {
                rs.Add(new RawObject(new[] { num }, rs));
            }
        }

        [DataTestMethod]
        public void DirectNormalizerTest()
        {
            //Arrange 
            var normalizer = new DirectNormalizer();
            //Act
            var res = normalizer.Normalize(rs);
            //Assert
            for (int i = 0; i < res.CleanObjects.Count; i++)
            {
                Assert.AreEqual(res.CleanObjects[i].ObjData[0], vars[i]);
            }
        }

        [DataTestMethod]
        public void NormalizerInProcessingManagerTest()
        {
            //Arrange 
            var normalizer = new DirectNormalizer();
            var mng = new ProcessingManager(new DBScanClusteringManager(), new DirectNormalizer(), new SQLiteReader());
            //Act
            var mngSet = mng.Normalizer.Normalize(rs);
            var normSet = normalizer.Normalize(rs);
            //Assert
            Assert.AreNotSame(mngSet, normSet);
            for (int i = 0; i < mngSet.CleanObjects.Count; i++)
            {
                Assert.AreEqual(mngSet.CleanObjects[i].ObjData[0], normSet.CleanObjects[i].ObjData[0]);
            }
        }

        [DataTestMethod]
        public void FileLoggerTest()
        {
            //Arrange
            string msg = "some text for test";
            //Act
            FileLogger.Instance.Log(msg);
            //Assert
            var sr = new StreamReader("clust.log", System.Text.Encoding.UTF8);
            string savedText = sr.ReadToEnd();
            Assert.IsTrue(savedText.Contains(msg));
            sr.Close();
        }

        [TestMethod]
        public void ClusterizerFabricsTest()
        {
            //Arrange 
            var sm = new DBScanClusteringManager();
            var km = new KMeansClusteringManager(3);
            //Assert
            Assert.IsInstanceOfType(sm._clusterizer, typeof(DBScanAdapter));
            Assert.IsInstanceOfType(km._clusterizer, typeof(KMeansAlglibAdapter));
        }

        [DataTestMethod]
        public void DBScanClusterizerTest()
        {
            double[] dbVars = { 0.5, 300.1, 300 };
            int clusterCount = 2;
            //Arrange 
            var dbs = new DBScanClusteringManager();
            var norm = new DirectNormalizer();
            var dbRs = new RawSet();
            foreach (var num in dbVars)
            {
                dbRs.Add(new RawObject(new[] { num, 0 }, dbRs));
            }
            dbs.CleanSet = norm.Normalize(dbRs);
            //Act
            var res = dbs.Clusterize();
            //Assert
            Assert.AreEqual(clusterCount, res.Clusters.Count);
        }
    }
}
