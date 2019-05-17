using System;

using NSubstitute;
using NUnit.Framework;

using calculator.analyzer;
using calculator.@operator.spec;

namespace test.analyzer {
  
  public class LexerTest {
    
    [Test]
    public void AWellFormedExpressionShouldReturnAResult() {
      // ReSharper disable once HeapView.ObjectAllocation.Evident
      var lexer = new Lexer();
      const string expression = "100 * ( 2 + 12 ) / 14";
      const double expectedResult = 100;

      Assert.AreEqual(expectedResult, lexer.Evaluate(expression), 0);
    }

    [Test]
    public void AWrongFormedExpressionShouldNotReturnAResult() {
      // ReSharper disable once HeapView.ClosureAllocation
      // ReSharper disable once HeapView.ObjectAllocation.Evident
      var lexer = new Lexer();
      const string expression = "100 * ( 2 & 12 ) / 14";

      // ReSharper disable once HeapView.DelegateAllocation
      Assert.Throws(typeof(ArgumentException), () => lexer.Evaluate(expression));
    }
    
    [Test]
    public void Test() {
      var binaryOperator = Substitute.For<IBinaryOperator>();
      // ReSharper disable once HeapView.ObjectAllocation.Evident
      var lexer = new Lexer();
      const string expression = "100 * ( 2 + 12 ) / 14";
      const double expectedResult = 100;

      binaryOperator.Apply(2, 12).Returns(14);
      Assert.AreEqual(14, binaryOperator.Apply(2, 12), 0);
      binaryOperator.Received(1).Apply(2, 12);
      
      binaryOperator.Apply(100, 14).Returns(1400);
      Assert.AreEqual(1400, binaryOperator.Apply(100, 14), 0);
      binaryOperator.Received(1).Apply(100, 14);
      
      binaryOperator.Apply(1400, 14).Returns(100);
      Assert.AreEqual(100, binaryOperator.Apply(1400, 14), 0);
      binaryOperator.Received(1).Apply(1400, 14);

      binaryOperator.Received(3).Apply(Arg.Any<double>(), Arg.Any<double>());
      
      Assert.AreEqual(expectedResult, lexer.Evaluate(expression), 0);
    }
  }
}