public struct Values
{
	public bool IsIntArray;
	public bool ShouldThrowException;
	public IntArray IntArr;
	public FloatArray FloatArr;
	public string StringArr;

    public Values(
        bool isIntArray,
        bool shouldThrowException,
        IntArray intArr,
        FloatArray floatArr,
        string stringArr
    )
    {
        this.IsIntArray = isIntArray;
        this.ShouldThrowException = shouldThrowException;
        this.IntArr = intArr;
        this.FloatArr = floatArr;
        this.StringArr = stringArr;
    }
}
