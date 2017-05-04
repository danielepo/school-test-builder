using Entities;
using Entities.Extensions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml.Wordprocessing;
using System;

namespace BL.Test
{
    class DocumentGeneratorForTests : DocumentGenerator
    {
        internal Table GetTable(int fileVersion, Professor professor = null)
        {
            return Table(fileVersion, professor);
        }
        
    }
    [TestFixture]
    public class DocumentGeneratorTest
    {
        private DocumentGeneratorForTests sut;
        

        [Test]
        public void TableHasElements()
        {
            sut = new DocumentGeneratorForTests();
            var table = sut.GetTable(0);

            Assert.That(table.HasChildren);
        }

        [Test]
        public void TableHasFiveChildren()
        {
            sut = new DocumentGeneratorForTests();
            var table = sut.GetTable(0);

            Assert.That(table.ChildElements.Count, Is.EqualTo(5));
        }

        [Test]
        public void TableHasCorrectElementTypes()
        {
            sut = new DocumentGeneratorForTests();
            var table = sut.GetTable(0);

            Assert.That(table.ChildElements[0], Is.TypeOf<TableProperties>());
            Assert.That(table.ChildElements[1], Is.TypeOf<TableGrid>());
            Assert.That(table.ChildElements[2], Is.TypeOf<TableRow>());
            Assert.That(table.ChildElements[3], Is.TypeOf<TableRow>());
            Assert.That(table.ChildElements[4], Is.TypeOf<TableRow>());
        }


        [Test]
        public void TableHasCorrectProfessor()
        {
            sut = new DocumentGeneratorForTests();
            var table = sut.GetTable(0,new Professor
            {
                Name = "Nome",
                Surname = "Cognome"
            });
            var professorRow = table.ChildElements[2];
            var professor = professorRow.ChildElements[1].InnerText;

            Assert.That(professor, Is.EqualTo("Nome Cognome"));
        }
            
    }
}