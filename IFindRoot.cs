namespace Labs1;

public interface IFindRoot
{ 
    (float, int) FindRoot(float leftBorder,float rightBorder, int counter = 1);
}