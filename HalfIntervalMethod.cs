namespace Labs1;

public class HalfIntervalMethod:IFindRoot
{
    public delegate float AllFunction(float x);

    public HalfIntervalMethod(AllFunction function,float e = 0.00001f)
    {
        _function = function;
        this.e = e;
    }

    public (float, int) FindRoot(float leftBorder, float rightBorder, int counter = 1)
    {
        float x = (rightBorder + leftBorder) / 2;
        while (rightBorder - leftBorder >= 2 * e)
        {
            x = (rightBorder + leftBorder) / 2;
            if (_function(x) == 0) break;
            else if (_function(leftBorder) * _function(x) < 0) rightBorder = x;
            else if(_function(x)*_function(rightBorder)<0) leftBorder = x;
            counter++;
        }

        return (x, counter);
    }

    private readonly float e;
    private AllFunction _function;
}