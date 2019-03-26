using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace TyranidsTest
{
    //UnitOfWork_Precondition_Outcome
    // 3 Unit test types: Calculation, Interaction and Value.

    [TestClass]
    public class Tests
    {
        private string _emptyUsername, _emptyPassword;

        [TestInitialize]
        public void Initalize()
        {
            _emptyUsername = string.Empty;
            _emptyPassword = string.Empty;
        }
    }
}
