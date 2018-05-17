using System.Collections;

public static class Utility
{
    public static int Normalize(int min, int max, int value)
    {
        return (value - min) / (max - min);
    }
}