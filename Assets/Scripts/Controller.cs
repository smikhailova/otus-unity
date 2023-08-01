using UnityEngine;
using TMPro;

public class Dropdown : MonoBehaviour
{
    public TextMeshProUGUI infoText;
    public TextMeshProUGUI output;

    private bool isIntArray = true;

    void Start()
    {
        infoText.text = IntArray.InfoText;
    }

    public void HandleDropdownChange(int val)
    {
        switch (val)
        {
            case 0:
                isIntArray = true;
                infoText.text = IntArray.InfoText;
                output.text = "";
                break;
            case 1:
                isIntArray = false;
                infoText.text = FloatArray.InfoText;
                output.text = "";
                break;
            default:
                break;
        }
    }

    public void HandleCreate()
    {
        CreateArray(isIntArray, false);
    }

    public void HandleCreateWithException()
    {
        CreateArray(isIntArray, true);
    }

    void CreateArray(bool isIntArray, bool shouldThrowException)
    {
        if (isIntArray)
        {
            IntArray arr = new(5, 3);
            arr.FillArray(shouldThrowException, ref output);

            SetStringArr(arr.StringifyArray(), out string stringArr);
            if (!shouldThrowException) output.text = "Array: " + stringArr;
            WriteStructWithIntArr(shouldThrowException, arr, stringArr);
        }

        if (!isIntArray)
        {
            FloatArray arr = new(7, 1.3f);
            arr.FillArray(shouldThrowException, ref output);

            SetStringArr(arr.StringifyArray(), out string stringArr);
            if (!shouldThrowException) output.text = "Array: " + stringArr;
            WriteStructWithFloatArr(shouldThrowException, arr, stringArr);
        }
    }

    void SetStringArr(string str, out string stringArr)
    {
        stringArr = str;
    }

    void WriteStructWithIntArr(bool shouldThrowException, IntArray intArr, string stringArr)
    {
        Values val = new(isIntArray, shouldThrowException, intArr, null, stringArr);

        FileWriter.WriteStruct("realIntOutput", val);

        FakeValuesToTestStruct(val);

        FileWriter.WriteStruct("fakeIntOutput", val);

        FakeValuesToTestStructWithRef(ref val);

        FileWriter.WriteStruct("fakeIntOutputWithRef", val);
    }

    void WriteStructWithFloatArr(bool shouldThrowException, FloatArray floatArr, string stringArr)
    {
        Values val = new(isIntArray, shouldThrowException, null, floatArr, stringArr);

        FileWriter.WriteStruct("realFloatOutput", val);

        FakeValuesToTestStruct(val);

        FileWriter.WriteStruct("fakeFloatOutput", val);

        FakeValuesToTestStructWithRef(ref val);

        FileWriter.WriteStruct("fakeFloatOutputWithRef", val);
    }

    void FakeValuesToTestStruct(Values values)
    {
        values.StringArr = "It isn't changed, isn't it?";
    }

    void FakeValuesToTestStructWithRef(ref Values values)
    {
        values.StringArr = "HAHA! Not an array!";
    }
}
