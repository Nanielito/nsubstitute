using System;

using NUnit.Framework;

using calculator.analyzer;

namespace test.analyzer {
  
  public class ParserTest {
  
    [Test]
    public void AnEmptyParserShouldNotContainsOperators() {
      // ReSharper disable once HeapView.ObjectAllocation.Evident
      var parser = new Parser();

      Assert.IsTrue(parser.IsOperatorsEmpty());
    }

    [Test]
    public void ANonEmptyParserShouldNotContainsOperatorsWhenASymbolWasNotPushed() {
      // ReSharper disable once HeapView.ClosureAllocation
      // ReSharper disable once HeapView.ObjectAllocation.Evident
      var parser = new Parser();
      const double value = 42;

      parser.PushOperand(value);

      Assert.IsTrue(parser.IsOperatorsEmpty());
      // ReSharper disable once HeapView.DelegateAllocation
      Assert.Throws(typeof(InvalidOperationException), () => parser.OperatorsTop());
      // ReSharper disable once HeapView.DelegateAllocation
      Assert.Throws(typeof(InvalidOperationException), () => parser.PopOperator());
    }

    [Test]
    public void ANonEmptyParserShouldContainsOperatorsWhenASymbolWasPushed() {
      // ReSharper disable once HeapView.ObjectAllocation.Evident
      var parser = new Parser();
      const double left = 42;
      const double right = 27;
      const char operator_ = '+';
      const char expectedOperator = '+';

      parser.PushOperand(left);
      parser.PushOperator(operator_);
      parser.PushOperand(right);

      Assert.IsFalse(parser.IsOperatorsEmpty());
      Assert.AreEqual(expectedOperator.ToString(), parser.OperatorsTop().ToString());
    }

    [Test]
    public void AnEmptyParserShouldNotResolveOperations() {
      // ReSharper disable once HeapView.ClosureAllocation
      // ReSharper disable once HeapView.ObjectAllocation.Evident
      var parser = new Parser();

      // ReSharper disable once HeapView.DelegateAllocation
      Assert.Throws(typeof(InvalidOperationException), () => parser.ResolveOperations());
    }

    [Test]
    public void ANonEmptyParserShouldResolveOperations() {
      // ReSharper disable once HeapView.ClosureAllocation
      // ReSharper disable once HeapView.ObjectAllocation.Evident
      var parser = new Parser();
      const double left = 42;
      const double right = 27;
      const char operator_ = '+';
      const double expectedResult = 69;

      parser.PushOperand(left);
      parser.PushOperator(operator_);
      parser.PushOperand(right);
      parser.ResolveOperations();

      Assert.AreEqual(expectedResult, parser.PopOperand(), 0);
    }
  }
}