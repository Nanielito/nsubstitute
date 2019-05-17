using System.Text;

using calculator.analyzer.utils;

namespace calculator.analyzer {
  
  public class Lexer {
  
    private Parser parser;

    private static string AddSpaces(string expression) {
      return expression;
    }
    
    private static int Precedence(char operator_) {
      return Parser.Precedence(operator_);
    }
    
    public Lexer() {
      // ReSharper disable once HeapView.ObjectAllocation.Evident
      parser = new Parser();
    }

    private bool IsEmpty() {
      return parser.IsOperatorsEmpty();
    }

    private char Top() {
      return parser.OperatorsTop();
    }

    private void AddOperator(char operator_) {
      parser.PushOperator(operator_);
    }

    private char RemoveOperator() {
      return parser.PopOperator();
    }

    private void AddOperand(double operand) {
      parser.PushOperand(operand);
    }

    private double RemoveOperand() {
      return parser.PopOperand();
    }

    private void Resolve() {
      parser.ResolveOperations();
    }

    public double Evaluate(string expression) {
      var tokens = AddSpaces(expression).ToCharArray();

      for (var i = 0; i < tokens.Length; i++) {
        if (tokens[i] == AnalyzerConstants.SPACE) {
        }
        else if (tokens[i] == AnalyzerConstants.OPEN_PARENTHESIS) {
          AddOperator(tokens[i]);
        }
        else if (char.IsDigit(tokens[i])) {
          // ReSharper disable once HeapView.ObjectAllocation.Evident
          StringBuilder sb = new StringBuilder();

          while (i < tokens.Length && char.IsDigit(tokens[i])) {
            sb.Append(tokens[i]);
            i++;
          }

          AddOperand(double.Parse(sb.ToString()));
        }
        else if (tokens[i] == AnalyzerConstants.CLOSE_PARENTHESIS) {
          while (IsEmpty() == false && Top() != AnalyzerConstants.OPEN_PARENTHESIS) {
            Resolve();
          }

          RemoveOperator();
        }
        else {
          while (IsEmpty() == false && Precedence(Top()) >= Precedence(tokens[i])) {
            Resolve();
          }

          AddOperator(tokens[i]);
        }
      }

      while (IsEmpty() == false) {
        Resolve();
      }

      return RemoveOperand();
    }
  }
}