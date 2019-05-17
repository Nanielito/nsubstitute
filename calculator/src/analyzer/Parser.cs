using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using calculator.analyzer.utils;
using calculator.@operator.impl;
using calculator.@operator.spec;

namespace calculator.analyzer {
  
  public class Parser {
    
    // ReSharper disable once HeapView.ObjectAllocation.Evident
    private static readonly IDictionary BINARY_OPERATORS = new Dictionary<char, IBinaryOperator>() {
      // ReSharper disable once HeapView.ObjectAllocation.Evident
      { AnalyzerConstants.ADD, new Addition() },
      // ReSharper disable once HeapView.ObjectAllocation.Evident
      { AnalyzerConstants.MINUS, new Subtraction() },
      // ReSharper disable once HeapView.ObjectAllocation.Evident
      { AnalyzerConstants.MULTIPLY, new Multiplication() },
      // ReSharper disable once HeapView.ObjectAllocation.Evident
      { AnalyzerConstants.DIVIDE, new Division() }
    };

    // ReSharper disable once HeapView.ObjectAllocation.Evident
    private Stack<char> operators = new Stack<char>();
    // ReSharper disable once HeapView.ObjectAllocation.Evident
    private Stack<double> operands = new Stack<double>();

    internal static int Precedence(char operator_) {
      var binaryOperator = BINARY_OPERATORS[operator_];

      return ((IBinaryOperator) binaryOperator)?.GetPrecedence() ?? 0;
    }
    
    private double Apply(double left, char operator_, double right) {
      // ReSharper disable once HeapView.ObjectAllocation.Possible
      foreach (IBinaryOperator binaryOperator in BINARY_OPERATORS.Values) {
        if (binaryOperator.IsValid(operator_) == true) {
          return binaryOperator.Apply(left, right);
        }
      }
      
      // ReSharper disable once HeapView.ObjectAllocation.Evident
      throw new ArgumentException(string.Format("Can't apply binary operation {0}", operator_.ToString()));
    }

    public bool IsOperatorsEmpty() {
      return operators.Count == 0;
    }

    public char OperatorsTop() {
      return operators.First();
    }

    public void PushOperator(char operator_) {
      operators.Push(operator_);
    }

    public char PopOperator() {
      return operators.Pop();
    }

    public void PushOperand(double operand) {
      operands.Push(operand);
    }

    public double PopOperand() {
      return operands.Pop();
    }

    public void ResolveOperations() {
      var right = operands.Pop();
      var left = operands.Pop();
      var operator_ = operators.Pop();

      operands.Push(Apply(left, operator_, right));
    }
  }
}