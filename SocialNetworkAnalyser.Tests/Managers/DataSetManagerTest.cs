using NUnit.Framework;
using SocialNetworkAnalyser.Business.Managers;
using SocialNetworkAnalyser.Data.Entities;
using SocialNetworkAnalyser.Tests.Helpers;
using SocialNetworkAnalyser.Tests.Helpers.Repositories;
using System;
using System.Linq;
using System.IO;
using System.Text;
using SocialNetworkAnalyser.Business.Models;

namespace SocialNetworkAnalyser.Tests.Managers
{
    [TestFixture]
    public class DataSetManagerTest : BaseTestManager
    {
        private DataSetManager _manager;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _manager = new DataSetManager();
            _manager.SetRepositoryFactory(RepositoryFactory);
        }

        [Test]
        public void Get_GetExistedDataSet_ReturnsDataSet()
        {
            var dataset = DataSet.Create("DataSetA");
            DataSetRepository.Add(dataset);

            var result = _manager.Get(dataset.Id);

            Assert.That(result, Is.EqualTo(dataset));
        }
        [Test]
        public void Get_WrongDataSetId_ReturnsNull()
        {
            var dataset = DataSet.Create("DataSetA");
            DataSetRepository.Add(dataset);

            var result = _manager.Get(Guid.NewGuid());

            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetAll_GetAllExistedDataSets_ReturnsDataSetList()
        {
            var datasetA = DataSet.Create("DataSetA");
            var datasetB = DataSet.Create("DataSetB");
            DataSetRepository.Add(datasetA);
            DataSetRepository.Add(datasetB);

            var result = _manager.GetAll();

            Assert.That(result, Is.EquivalentTo(new []{ datasetA, datasetB }));
        }
        [Test]
        public void GetAll_NoEntities_ReturnsEmptyList()
        {
            var result = _manager.GetAll();

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void ImportDataSet_CorrectlyImported_ReturnsTrue()
        {
            string datasetName = "New DataSet";
            string data = CorrectDataSoure();

            var result = PerformImportDataSet(data, datasetName, _manager.ImportDataSet);
            var addedDataSet = DataSetRepository.DataSets.FirstOrDefault();

            Assert.That(result.Success, Is.True);
            Assert.That(addedDataSet.Name, Is.EqualTo(datasetName));
            Assert.That(FriendshipRepository.Friendships.Count, Is.EqualTo(7));
        }
        [Test]
        public void ImportDataSet_EmptyStream_ThrowsException()
        {
            var exception = Assert.Throws<ArgumentException>(() => _manager.ImportDataSet(null, "New DataSet"));

            Assert.That(exception.Message, Is.EqualTo("Null or empty file stream"));
        }
        [Test]
        public void ImportDataSet_IncorrectLineInInputFile_ReturnsFalse()
        {
            string data = DataSourceWithIncorrectLine();

            var result = PerformImportDataSet(data, "New DataSet", _manager.ImportDataSet);

            Assert.That(result.Success, Is.False);
            Assert.That(result.ErrorMessage, Is.EqualTo("Incorrect line 4: '15'"));
        }


        private string CorrectDataSoure()
        {
            return
@"1 2
1 3
1 4
1 5
1 6
1 7
2 1
2 4
3 7";
        }
        private string DataSourceWithIncorrectLine()
        {
            return
@"1 2
1 3
1 4
15
1 6
1 7
2 1
2 4
3 7";
        }

        private ImportDataSetResult PerformImportDataSet(string data, string datasetName, Func<Stream, string, ImportDataSetResult> ImportDataSet)
        {
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(data)))
            {
                return ImportDataSet(stream, datasetName);
            }
        }
    }
}
