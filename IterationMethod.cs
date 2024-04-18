using static System.Net.Mime.MediaTypeNames;

namespace Labs1;

public class IterationMethod:IFindRoot
{
    private readonly float e;
    public delegate float AllFunction(float x);

    private AllFunction _function;
    private AllFunction _derivedFunction;
    private Dictionary<float, float> _calculatedValue;
    public IterationMethod(AllFunction function, AllFunction derivedFunction,float e = 0.00001f)
    {
        _function = function;
        _derivedFunction = derivedFunction;
        _calculatedValue = new Dictionary<float, float>();
        this.e = e;
    }

    public (float, int) FindRoot(float leftBorder,float rightBorder, int counter = 1)
    {
        float x = FindStartBorder(leftBorder, rightBorder);
        float lam= 1/_derivedFunction(x);
        float oldX;
        do
        {
            oldX = x;
            if (_calculatedValue.ContainsKey(oldX)) x = _calculatedValue[oldX];
            else
            {
                x = oldX - _function(oldX) * lam;
                _calculatedValue.Add(oldX, x);
            }
            counter++;

        } while (Math.Abs(oldX-x) > e);

        return (x,counter);
    }

    private float FindStartBorder(float left, float right)
    {
        return (Math.Abs(_derivedFunction(left))> Math.Abs(_derivedFunction(right)))? left:right;
    }
}