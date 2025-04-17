using BK_Functions.Database;
using BK_Functions.Local.Disciplina;
using BK_Functions.Models;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace BK_Tests.Entities.Disciplina
{
    [TestClass]
    public class DisciplinaTeste
    {
        IDisciplineRepository _discipline;
        public DisciplinaTeste()
        {
            _discipline = new DisciplineRepository();
            new DbCreate().ExecuteDB();
        }

        [Test]
        public void Testa_Get()
        {
            try
            {
                var values = _discipline.Get();
                Assert.That(values.Any());
            }
            catch (Exception)
            {
                Assert.Fail();
            }

        }

        [Test]
        public void Testa_Post()
        {
            try
            {
                var values = _discipline.Post();
                //Assert.That(values.Any());
            }
            catch (Exception)
            {
                Assert.Fail();
            }

        }


    }
}
