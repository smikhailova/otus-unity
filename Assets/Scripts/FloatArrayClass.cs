using System;
using System.Linq;
using TMPro;

public class FloatArray
{
    public static readonly string InfoText = "You are going to create float array";

    private readonly float[] arr;
    private readonly int arrSize;

    public FloatArray(int size, float firstNum)
	{
        float[] floatArr = new float[size];
        floatArr[0] = firstNum;

        arr = floatArr;
        arrSize = size;
    }

    public void FillArray(bool shouldThrowException, ref TextMeshProUGUI output)
    {
        int maxIndex = shouldThrowException ? arrSize + 1 : arrSize;

        try
        {
            for (int i = 1; i < maxIndex; i++)
            {
                arr[i] = arr[i - 1] * arr[i - 1];
            }
        }
        catch (IndexOutOfRangeException ex)
        {
            output.text = "Exception: " + ex.Message;
        }
    }

    public string StringifyArray()
    {
        return String.Join(", ",
            arr
            .Select(i => i.ToString())
            .ToArray());
    }
}

