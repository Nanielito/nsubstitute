using calculator.@operator.spec;

namespace calculator.@operator.impl {
  
  public class Multiplication : IBinaryOperator {
    
    private const int  MULTIPLY_PRECEDENCE =   2;
    private const char MULTIPLY_OPERATOR   = '*';

    public int GetPrecedence() {
      return MULTIPLY_PRECEDENCE;
    }

    public bool IsValid(char operator_) {
      return MULTIPLY_OPERATOR.Equals(operator_);
    }

    public double Apply(double left, double right) {
      return left * right;
    }
  }
}