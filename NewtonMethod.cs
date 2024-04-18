using static System.Net.Mime.MediaTypeNames;

namespace Labs1;

public class NewtonMethod:IFindRoot
{
    private Dictionary<float, float> calculatedValue;
    private readonly float e;
    public delegate float AllFunction(float x);

    private AllFunction _function;
    private AllFunction _firstDerivedFunction;
    private AllFunction _secondDerivedFunction;

    public NewtonMethod(AllFunction function, AllFunction firstDerivedFunction, AllFunction secondDerivedFunction,float e = 0.001f)
    {
        calculatedValue = new Dictionary<float, float>();
        _function = function;
        _firstDerivedFunction = firstDerivedFunction;
        _secondDerivedFunction = secondDerivedFunction;
        this.e = e;
    }

    public (float, int) FindRoot(float leftBorder,float rightBorder, int counter)
    {
        float nextX = FindStartBorder(leftBorder,rightBorder); 
        float oldX;
        do
        {
            oldX = nextX;
            if (calculatedValue.ContainsKey(oldX)) nextX = calculatedValue[oldX];
            else
            {
                nextX = oldX - _function(oldX) / _firstDerivedFunction(oldX);
                calculatedValue.Add(oldX, nextX);
            }
            
            counter++;
        } while (Math.Abs(nextX - oldX) > e);
        return (nextX,counter);
    }

    private float FindStartBorder(float leftBorder, float rightBorder)
    {
        return (_function(leftBorder)*_secondDerivedFunction(leftBorder)>0) ? leftBorder : rightBorder;
    }
}