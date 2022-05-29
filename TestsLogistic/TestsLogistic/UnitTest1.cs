using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestsLogistic
{
    public abstract class DatabaseUnitTest<TContext> where TContext : DataContext
    {
        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            CreateFolderForTempDatabase();
        }

        [SetUp]
        public void BeforeTestExecuting()
        {
            RestoreDatabaseFromOriginal();
            RecreateContext();
        }

        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            KillDatabase();
        }

        protected string ConnectionString
        {
            get
            {
                return String.Format(@"Data Source={0};Initial Catalog={1};Integrated Security=True",
                        TestServerName, TestDatabaseName);
            }
        }

        protected TContext Context { get; private set; }

        protected string TestDatabaseOriginalName { get { return "Database"; } }

        protected string ProjectName { get { return "CoolProject"; } }

        protected void RecreateContext()
        {
            Context = (TContext)Activator.CreateInstance(typeof(TContext), ConnectionString);
        }

        private string FolderForTempDatabase
        {
            get { return String.Format(@"R:\{0}.DatabaseTests\", ProjectName); }
        }

        private string TestDatabaseName
        {
            get { return FolderForTempDatabase + ProjectName + ".Tests"; }
        }

        private string TestDatabaseOriginalFileName
        {
            get { return Path.Combine(TestDatabaseDirectory, TestDatabaseOriginalName + ".mdf"); }
        }

        private string TestDatabaseFileName
        {
            get { return Path.Combine(TestDatabaseDirectory, TestDatabaseName + ".mdf"); }
        }

        private void CreateFolderForTempDatabase()
        {
            var directory = new DirectoryInfo(FolderForTempDatabase);
            if (!directory.Exists)
            {
                directory.Create();
            }
        }

        private void RestoreDatabaseFromOriginal()
        {
            KillDatabase();
            CopyFiles();
            AttachDatabase();
        }

        private void KillDatabase()
        {
            Server server = Server;
            SqlConnection.ClearAllPools();
            if (server.Databases.Contains(TestDatabaseName))
            {
                server.KillDatabase(TestDatabaseName);
            }
        }

        private void CopyFiles()
        {
            new FileInfo(TestDatabaseOriginalFileName).CopyTo(TestDatabaseFileName, true);
            string logFileName = GetLogFileName(TestDatabaseFileName);
            new FileInfo(GetLogFileName(TestDatabaseOriginalFileName)).CopyTo(logFileName, true);
            new FileInfo(TestDatabaseFileName).Attributes = FileAttributes.Normal;
            new FileInfo(logFileName).Attributes = FileAttributes.Normal;
        }

        private void AttachDatabase()
        {
            Server server = Server;
            if (!server.Databases.Contains(TestDatabaseName))
            {
                server.AttachDatabase(TestDatabaseName, new StringCollection { TestDatabaseFileName, GetLogFileName(TestDatabaseFileName) });
            }
        }

        private static string GetLogFileName(string databaseFileName)
        {
            return new Regex(".mdf$", RegexOptions.IgnoreCase).Replace(databaseFileName, "_log.ldf");
        }

        private static Server Server { get { return new Server(TestServerName); } }

        private static string TestServerName { get { return "."; } }

        private static string TestDatabaseDirectory
        {
            get
            {
                var debugDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
                DirectoryInfo binDirectory = debugDirectory.Parent;
                DirectoryInfo testProjectDirectory;
                if (binDirectory == null || (testProjectDirectory = binDirectory.Parent) == null)
                {
                    throw new Exception("");
                }
                return Path.Combine(testProjectDirectory.FullName, "Database");
            }
        }
    }
}
}
