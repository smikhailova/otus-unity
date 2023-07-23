using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class ButtonUIScript : MonoBehaviour
{
    public TMP_Text initial;
    public TMP_Text result;

    public Button intToByteButton;
    public Button doubleToIntButton;
    public Button intToShortButton;
    public Button charToIntButton;

    void Start()
    {
        TypeConvertion convertionObj = new(8450, 245.45, '9');

        Button intToByteBtn = intToByteButton.GetComponent<Button>();
        intToByteBtn.onClick.AddListener(delegate { ConvertIntToByteOnClick(convertionObj); });

        Button doubleToIntBtn = doubleToIntButton.GetComponent<Button>();
        doubleToIntBtn.onClick.AddListener(delegate { ConvertDoubleToIntOnClick(convertionObj); });

        Button intToShortBtn = intToShortButton.GetComponent<Button>();
        intToShortBtn.onClick.AddListener(delegate { ConvertIntToShortOnClick(convertionObj); });

        Button charToIntBtn = charToIntButton.GetComponent<Button>();
        charToIntBtn.onClick.AddListener(delegate { ConvertCharToIntOnClick(convertionObj); });
    }

    void ConvertIntToByteOnClick(TypeConvertion convertionObj)
    {
        convertionObj.IntToByte();

        initial.text = convertionObj.initialIntNum.ToString();
        result.text = convertionObj.resultByteNum.ToString();

        SaveDataToFile(
            "IntToByte",
            convertionObj.initialIntNum.ToString(),
            convertionObj.resultByteNum.ToString()
        );
    }

    void ConvertDoubleToIntOnClick(TypeConvertion convertionObj)
    {
        convertionObj.DoubleToInt();

        initial.text = convertionObj.initialDoubleNum.ToString();
        result.text = convertionObj.resultIntNum.ToString();

        SaveDataToFile(
            "DoubleToInt",
            convertionObj.initialDoubleNum.ToString(),
            convertionObj.resultIntNum.ToString()
        );
    }

    void ConvertIntToShortOnClick(TypeConvertion convertionObj)
    {
        convertionObj.IntToShort();

        initial.text = convertionObj.initialIntNum.ToString();
        result.text = convertionObj.resultShortNum.ToString();

        SaveDataToFile(
            "IntToShort",
            convertionObj.initialIntNum.ToString(),
            convertionObj.resultShortNum.ToString()
        );
    }

    void ConvertCharToIntOnClick(TypeConvertion convertionObj)
    {
        convertionObj.CharToInt();

        initial.text = convertionObj.initialCharNum.ToString();
        result.text = convertionObj.resultIntNum.ToString();

        SaveDataToFile(
            "CharToInt",
            convertionObj.initialCharNum.ToString(),
            convertionObj.resultIntNum.ToString()
        );
    }

    void SaveDataToFile(string convertionType, string initial, string result)
    {
        string destination = "Assets/Resources/output.txt";

        if (!File.Exists(destination)) File.CreateText(destination).Dispose();

        StreamWriter writer = new(destination, true);

        writer.WriteLine(convertionType);
        writer.Write("Initial: " + initial.ToString() + "; ");
        writer.WriteLine("Result: " + result.ToString() + "; ");
        writer.WriteLine();
        writer.Close();
    }
}
