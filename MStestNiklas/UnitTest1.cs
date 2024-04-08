using KompletteringNiklas;

namespace MStestNiklas
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class ProgramTests
        {
            [TestMethod]
            public void FiltreradeFrukterMedA()
            {
                // Arrange
                filterMetod filter = new filterMetod();
                string[] allaFrukter = { "apple", "banan", "apelsin", "kiwi", "ananas" };
                List<string> förväntadResultat = new List<string> { "apple", "apelsin", "ananas" };

                // Act
                List<string> resultat = filter.FiltreradeFrukterMedA(allaFrukter);

                // Assert
                CollectionAssert.AreEqual(förväntadResultat, resultat);
            }

            [TestMethod]
            public void FiltreradeNamnEgenBokstav()
            {
                // Arrange
                egenBosktav egenBokstav = new egenBosktav();
                string[] allaNamn = { "Anna", "bodil", "Calle", "David", "Eva" };
                egenBokstav.X = "B";
                List<string> förväntadResultat = new List<string> { "bodil" };

                // Act
                List<string> resultat = egenBokstav.FiltreradeNamnEgenBokstav(allaNamn);

                // Assert
                CollectionAssert.AreEqual(förväntadResultat, resultat);
            }

            [TestClass]
            public class FileCreationTests
            {
                [TestMethod]
                public void Test_Frukt_FileCreation()
                {
                    // Arrange
                    var class1 = new filterMetod();
                    var expectedFileName = "frukterMedA.txt";

                    // Act
                    var inputFrukter = new string[] { "Apple", "Banana", "Avocado" };
                    var filtreradLista = class1.FiltreradeFrukterMedA(inputFrukter);
                    var fruktmap = Directory.CreateDirectory("AllaFrukterMedA").FullName;
                    var filePath = Path.Combine(fruktmap, expectedFileName);
                    File.WriteAllLines(filePath, filtreradLista);

                    // Assert
                    Assert.IsTrue(File.Exists(filePath));
                    var linesInFile = File.ReadAllLines(filePath);
                    CollectionAssert.AreEqual(filtreradLista, linesInFile);
                }

                [TestMethod]
                public void Test_Namn_FileCreation()
                {
                    // Arrange
                    var egenBokstav = new egenBosktav();
                    var expectedFileName = "NamnMedX.txt";

                    // Act
                    egenBokstav.X = "X";
                    var inputNamn = new string[] { "Xavier", "Xena", "Xander" };
                    var filtreradNamnLista = egenBokstav.FiltreradeNamnEgenBokstav(inputNamn);
                    var xMappen = Directory.CreateDirectory("XFolder").FullName;
                    var xMappenNamn = Path.Combine(xMappen, expectedFileName);
                    File.WriteAllLines(xMappenNamn, filtreradNamnLista);

                    // Assert
                    Assert.IsTrue(File.Exists(xMappenNamn));
                    var linesInFile = File.ReadAllLines(xMappenNamn);
                    CollectionAssert.AreEqual(filtreradNamnLista, linesInFile);
                }
            }
        }

    }
}