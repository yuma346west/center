namespace ConsoleApp.DependencyServices.Interface;

public interface IMath
{
    void Plus(int a);
    void Minus(int a);
    void Multi(int a);
    void Divide(int a);
    int Latest();
    int Current();

    void Calculate();
    void TryParseCalculateMethod();
}