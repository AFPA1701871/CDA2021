using NUnit.Framework;
using System;
using TestsUnitaires;

namespace UnitTest
{
    public class CompteTest
    {
        Compte compte;

        [SetUp]
        public void Setup()
        {
            double soldeDepart = 11.99;
            compte = new Compte("Mr Toto", soldeDepart);
        }

        [Test]
        public void Debit_MontantValide()
        {
            // Arrange
            double montantDebite = 4.55;
            double attendu = 7.44;
            
            // Act
            compte.Debit(montantDebite);

            // Assert
            double soldeActuel = compte.Solde;
            Assert.AreEqual(attendu, soldeActuel, 0.001, "Compte mal débité");
        }

        [Test]
        public void Debit_MontantNegatif()
        {
            // Arrange
            double montantDebite = -4;

            // Act et  Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => compte.Debit(montantDebite));
        }

        [Test]
        public void Debit_MontantSuperieurSolde()
        {
            // Arrange
            double montantDebite = 44.55;

            // Act et  Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => compte.Debit(montantDebite));
        }

    }
}