using calculator.@operator.spec;

namespace calculator.@operator.impl {
  
  public class Addition : IBinaryOperator {

    private const int  ADD_PRECEDENCE =   1;
    private const char ADD_OPERATOR   = '+';

    public int GetPrecedence() {
      return ADD_PRECEDENCE;
    }

    public bool IsValid(char operator_) {
      return ADD_OPERATOR.Equals(operator_);
    }

    public double Apply(double left, double right) {
      return left + right;
    }
  }
}