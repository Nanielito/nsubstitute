using NSubstitute;
using NUnit.Framework;

using calculator.@operator.impl;
using calculator.@operator.spec;

namespace test.@operator {
  
  public class BinaryOperatorTest {

    [Test]
    public void OperatorPrecedenceForAdditionAndSubtractionShouldBeTheSame() {
      // ReSharper disable once HeapView.ObjectAllocation.Evident
      var addition = new Addition();
      // ReSharper disable once HeapView.ObjectAllocation.Evident
      var subtraction = new Subtraction();

      Assert.IsTrue(addition.GetPrecedence().Equals(subtraction.GetPrecedence()));
    }
    
    [Test]
    public void OperatorPrecedenceForMultiplicationAndDivisionShouldBeTheSame() {
      // ReSharper disable once HeapView.ObjectAllocation.Evident
      var multiplication = new Multiplication();
      // ReSharper disable once HeapView.ObjectAllocation.Evident
      var division = new Division();

      Assert.IsTrue(multiplication.GetPrecedence().Equals(division.GetPrecedence()));
    }

    [Test]
    public void OperatorPrecedenceForMultiplicationAndDivisionShouldBeHigherThanAdditionAndSubtraction() {
      // ReSharper disable once HeapView.ObjectAllocation.Evident
      var addition = new Addition();
      // ReSharper disable once HeapView.ObjectAllocation.Evident
      var subtraction = new Subtraction();
      // ReSharper disable once HeapView.ObjectAllocation.Evident
      var multiplication = new Multiplication();
      // ReSharper disable once HeapView.ObjectAllocation.Evident
      var division = new Division();

      Assert.IsTrue(multiplication.GetPrecedence() > addition.GetPrecedence());
      Assert.IsTrue(multiplication.GetPrecedence() > subtraction.GetPrecedence());
      Assert.IsTrue(division.GetPrecedence() > addition.GetPrecedence());
      Assert.IsTrue(division.GetPrecedence() > subtraction.GetPrecedence());
    }
    
    [Test]
    public void AddSymbolForAdditionShouldBeValid() {
      // ReSharper disable once HeapView.ObjectAllocation.Evident
      var addition = new Addition();
      const char addSymbol = '+';

      Assert.IsTrue(addition.IsValid(addSymbol));
    }

    [Test]
    public void NonAddSymbolForAdditionShouldBeInvalid() {
      // ReSharper disable once HeapView.ObjectAllocation.Evident
      var addition = new Addition();
      const char nonAddSymbol = '*';

      Assert.IsFalse(addition.IsValid(nonAddSymbol));
    }

    [Test]
    public void SubtractSymbolForSubtractionShouldBeValid() {
      // ReSharper disable once HeapView.ObjectAllocation.Evident
      var subtraction = new Subtraction();
      const char subtractSymbol = '-';

      Assert.IsTrue(subtraction.IsValid(subtractSymbol));
    }

    [Test]
    public void NonSubtractSymbolForSubtractionShouldBeInvalid() {
      // ReSharper disable once HeapView.ObjectAllocation.Evident
      var subtraction = new Subtraction();
      const char nonSubtractSymbol = '/';

      Assert.IsFalse(subtraction.IsValid(nonSubtractSymbol));
    }

    [Test]
    public void MultiplySymbolForMultiplicationShouldBeValid() {
      // ReSharper disable once HeapView.ObjectAllocation.Evident
      var multiplication = new Multiplication();
      const char multiplySymbol = '*';

      Assert.IsTrue(multiplication.IsValid(multiplySymbol));
    }

    [Test]
    public void NonMultiplySymbolForMultiplicationShouldBeInvalid() {
      // ReSharper disable once HeapView.ObjectAllocation.Evident
      var multiplication = new Multiplication();
      const char nonMultiplySymbol = '+';

      Assert.IsFalse(multiplication.IsValid(nonMultiplySymbol));
    }

    [Test]
    public void DivideSymbolForDivisionShouldBeValid() {
      // ReSharper disable once HeapView.ObjectAllocation.Evident
      var division = new Division();
      const char divideSymbol = '/';

      Assert.IsTrue(division.IsValid(divideSymbol));
    }

    [Test]
    public void NonDivideSymbolForDivisionShouldBeInvalid() {
      // ReSharper disable once HeapView.ObjectAllocation.Evident
      var division = new Division();
      const char nonDivideSymbol = '-';

      Assert.IsFalse(division.IsValid(nonDivideSymbol));
    }

    [Test]
    public void AdditionOperatorShouldReturnTheSumValue() {
      const double left = 42;
      const double right = 27;
      const double expectedResult = 69;

      // ReSharper disable once HeapView.ObjectAllocation.Evident
      var addition = new Addition();

      var additionResult = addition.Apply(left, right);

      Assert.AreEqual(expectedResult, additionResult, 0);
    }

    [Test]
    public void SubtractionOperatorShouldReturnTheDifferenceValue() {
      const double left = 42;
      const double right = 27;
      const double expectedResult = 15;

      // ReSharper disable once HeapView.ObjectAllocation.Evident
      var subtraction = new Subtraction();

      var subtractionResult = subtraction.Apply(left, right);

      Assert.AreEqual(expectedResult, subtractionResult, 0);
  }

    [Test]
    public void MultiplicationOperatorShouldReturnTheProductValue() {
      const double left = 42;
      const double right = 3.14;
      const double expectedResult = 131.88;

      // ReSharper disable once HeapView.ObjectAllocation.Evident
      var multiplication = new Multiplication();

      var multiplicationResult = multiplication.Apply(left, right);

      Assert.AreEqual(expectedResult, multiplicationResult, 0);
    }

    [Test]
    public void DivisionOperatorShouldReturnTheQuotientValue() {
      const double left = 42;
      const double right = 2;
      const double expectedResult = 21;

      // ReSharper disable once HeapView.ObjectAllocation.Evident
      var division = new Division();

      var divisionResult = division.Apply(left, right);

      Assert.AreEqual(expectedResult, divisionResult, 0);
    }

    [Test]
    public void Test() {
      var binaryOperator = Substitute.For<IBinaryOperator>();
      const double left = 42;
      const double right = 27;
      const double expectedResult = 69;
      
      binaryOperator.Apply(left, right).Returns(expectedResult);

      Assert.AreEqual(expectedResult, binaryOperator.Apply(left, right), 0);

      binaryOperator.Received(1).Apply(left, Arg.Any<double>());
    }
  }
}