using System;

[Serializable]
public class TypeConvertion
{
    public int initialIntNum;
    public double initialDoubleNum;
    public char initialCharNum;

    public byte resultByteNum;
    public int resultIntNum;
    public short resultShortNum;

    public TypeConvertion(int initialInt, double initialDouble, char initialChar)
    {
        initialIntNum = initialInt;
        initialDoubleNum = initialDouble;
        initialCharNum = initialChar;
    }

    public void IntToByte()
    {
        resultByteNum = (byte)initialIntNum;
    }

    public void DoubleToInt()
    {
        resultIntNum = (int)initialDoubleNum;
    }

    public void IntToShort()
    {
        resultShortNum = (short)initialIntNum;
    }

    public void CharToInt()
    {
        resultIntNum = (int)initialCharNum;
    }
}