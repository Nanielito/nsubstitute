using calculator.@operator.spec;

namespace calculator.@operator.impl {
  
  public class Division : IBinaryOperator {
    
    private const int  DIVIDE_PRECEDENCE =   2;
    private const char DIVIDE_OPERATOR   = '/';

    public int GetPrecedence() {
      return DIVIDE_PRECEDENCE;
    }

    public bool IsValid(char operator_) {
      return DIVIDE_OPERATOR.Equals(operator_);
    }

    public double Apply(double left, double right) {
      return left / right;
    }
  }
}