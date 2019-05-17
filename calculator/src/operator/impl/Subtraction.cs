using calculator.@operator.spec;

namespace calculator.@operator.impl {

  public class Subtraction : IBinaryOperator {
   
    private const int  SUBTRACT_PRECEDENCE =   1;
    private const char SUBTRACT_OPERATOR   = '-';

    public int GetPrecedence() {
      return SUBTRACT_PRECEDENCE;
    }

    public bool IsValid(char operator_) {
      return SUBTRACT_OPERATOR.Equals(operator_);
    }

    public double Apply(double left, double right) {
      return left - right;
    }
  }
}