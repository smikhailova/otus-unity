using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//public class TypeConvertion
//{
//    public readonly static int intNum = 8450;
//    public readonly static double doubleNum = 245.45;
//    public readonly static char charNum = '9';

//    public static byte IntToByte()
//    {
//        return (byte)intNum;
//    }

//    public static int DoubleToInt()
//    {
//        return (int)doubleNum;
//    }

//    public static short IntToShort()
//    {
//        return (short)intNum;
//    }

//    public static int CharToInt()
//    {
//        return (int)charNum;
//    }
//}

public class ButtonUIScript : MonoBehaviour
{
    public class TypeConvertion
    {
        public readonly static int intNum = 8450;
        public readonly static double doubleNum = 245.45;
        public readonly static char charNum = '9';

        public static byte IntToByte()
        {
            return (byte)intNum;
        }

        public static int DoubleToInt()
        {
            return (int)doubleNum;
        }

        public static short IntToShort()
        {
            return (short)intNum;
        }

        public static int CharToInt()
        {
            return (int)charNum;
        }
    }

    public TMP_Text initial;

    public TMP_Text result;

    public Button intToByteButton;
    public Button doubleToIntButton;
    public Button intToShortButton;
    public Button charToIntButton;

    void Start()
    {
        Button intToByteBtn = intToByteButton.GetComponent<Button>();
        intToByteBtn.onClick.AddListener(ConvertIntToByteOnClick);

        Button doubleToIntBtn = doubleToIntButton.GetComponent<Button>();
        doubleToIntBtn.onClick.AddListener(ConvertDoubleToIntOnClick);

        Button intToShortBtn = intToShortButton.GetComponent<Button>();
        intToShortBtn.onClick.AddListener(ConvertIntToShortOnClick);

        Button charToIntBtn = charToIntButton.GetComponent<Button>();
        charToIntBtn.onClick.AddListener(ConvertCharToIntOnClick);
    }

    void ConvertIntToByteOnClick()
    {
        initial.text = TypeConvertion.intNum.ToString();
        result.text = TypeConvertion.IntToByte().ToString();
    }

    void ConvertDoubleToIntOnClick()
    {
        initial.text = TypeConvertion.doubleNum.ToString();
        result.text = TypeConvertion.DoubleToInt().ToString();
    }

    void ConvertIntToShortOnClick()
    {
        initial.text = TypeConvertion.intNum.ToString();
        result.text = TypeConvertion.IntToShort().ToString();
    }

    void ConvertCharToIntOnClick()
    {
        initial.text = TypeConvertion.charNum.ToString();
        result.text = TypeConvertion.CharToInt().ToString();
    }
}
