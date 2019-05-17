namespace calculator.@operator.spec {

  public interface IBinaryOperator {

    int GetPrecedence();

    bool IsValid(char operator_);

    double Apply(double left, double right);
  }
}