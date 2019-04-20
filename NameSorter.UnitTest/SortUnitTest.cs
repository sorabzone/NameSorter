using NameSorter.Engine;
using NameSorter.Engine.OutputService;
using NameSorter.Engine.Service;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;

namespace NameSorter.UnitTest
{
    [TestFixture(@"TestData\unsorted-names-list.txt", TypeArgs = new Type[] { typeof(string) })]
    public class SortUnitTest
    {
        private string _inputFile;
        private FileOutputService _fileService;
        private NameSortWorker _forwardNameSortWorker;
        private NameSortWorker _backwardNameSortWorker;

        public SortUnitTest(string inputFile)
        {
            ConsoleOutputService svc = new ConsoleOutputService();
            _inputFile = inputFile;
            _fileService = new FileOutputService();
            _forwardNameSortWorker = new NameSortWorker(new ForwardSortStrategy());
            _backwardNameSortWorker = new NameSortWorker(new BackwardSortStrategy());
        }

        /// <summary>
        /// When file not found
        /// </summary>
        [TestCase]
        public void When_Invalid_Filename()
        {
            Assert.Throws<System.IO.FileNotFoundException>(delegate ()
            {
                _forwardNameSortWorker.SortNames("Random.txt");
            });
        }

        /// <summary>
        /// Sorting using forward strategy
        /// </summary>
        /// <returns></returns>
        [TestCase]
        public void When_Forward_Strategy()
        {
            var expectedResult = new string[]
                                {
                                "Marin Alvarez",
                                "Adonis Nathan Archer",
                                "Bdonis Julius Archer",
                                "Janet Parsons",
                                "Beau Nathan Yoder",
                                "Shelby Mathan Yoder",
                                };

            var sortedNames = _forwardNameSortWorker.SortNames(_inputFile);

            CollectionAssert.AreEqual(expectedResult, sortedNames);
        }

        /// <summary>
        /// Sorting using backward strategy
        /// </summary>
        /// <returns></returns>
        [TestCase]
        public void When_Backward_Strategy()
        {
            var expectedResult = new string[]
                                {
                                "Marin Alvarez",
                                "Bdonis Julius Archer",
                                "Adonis Nathan Archer",
                                "Janet Parsons",
                                "Shelby Mathan Yoder",
                                "Beau Nathan Yoder",
                                };

            var sortedNames = _backwardNameSortWorker.SortNames(_inputFile);

            CollectionAssert.AreEqual(expectedResult, sortedNames);
        }

        /// <summary>
        /// Testing output file name
        /// </summary>
        /// <returns></returns>
        [TestCase]
        public async Task When_Output_File()
        {
            var expectedResult = new string[]
                                {
                                "Marin Alvarez",
                                "Bdonis Julius Archer",
                                "Adonis Nathan Archer",
                                "Janet Parsons",
                                "Shelby Mathan Yoder",
                                "Beau Nathan Yoder",
                                };

            var sortedNames = _backwardNameSortWorker.SortNames(_inputFile);
            await _fileService.GenerateOutput(sortedNames);

            Assert.AreEqual(true, File.Exists("sorted-names-list.txt"));
        }

        /// <summary>
        /// Testign contents of outfile file generated
        /// </summary>
        /// <returns></returns>
        [TestCase]
        public async Task When_Output_File_Content()
        {
            var expectedResult = new string[]
                                {
                                "Marin Alvarez",
                                "Bdonis Julius Archer",
                                "Adonis Nathan Archer",
                                "Janet Parsons",
                                "Shelby Mathan Yoder",
                                "Beau Nathan Yoder",
                                };

            var sortedNames = _backwardNameSortWorker.SortNames(_inputFile);
            await _fileService.GenerateOutput(sortedNames);

            string[] actualResult = File.ReadAllLines("sorted-names-list.txt");

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Testing whether the output file contents are overwritten or not
        /// </summary>
        /// <returns></returns>
        [TestCase]
        public async Task When_Output_File_OverWrite()
        {
            //Initial output file content
            string[] createText = { "Hello", "And", "Welcome" };
            File.WriteAllLines("sorted-names-list.txt", createText);

            var expectedResult = new string[]
                                {
                                "Marin Alvarez",
                                "Bdonis Julius Archer",
                                "Adonis Nathan Archer",
                                "Janet Parsons",
                                "Shelby Mathan Yoder",
                                "Beau Nathan Yoder",
                                };

            var sortedNames = _backwardNameSortWorker.SortNames(_inputFile);
            await _fileService.GenerateOutput(sortedNames);

            string[] actualResult = File.ReadAllLines("sorted-names-list.txt");

            CollectionAssert.AreNotEqual(createText, actualResult);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}
