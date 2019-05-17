using System;

using NUnit.Framework;

using calculator.analyzer;

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
  }
}