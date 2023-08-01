using System.IO;

public static class FileWriter
{
	public static void WriteStruct(string fileName, Values values)
	{
        string destination = "Assets/OutputFiles/" + fileName + ".txt";

        if (!File.Exists(destination)) File.CreateText(destination).Dispose();

        StreamWriter writer = new(destination, true);

        string isArrIntAnswer = values.IsIntArray ? "Yes" : "No";
        string shouldThrowExcAnswer = values.ShouldThrowException ? "Yes" : "No";

        writer.WriteLine("Is Array Int? " + isArrIntAnswer);
        writer.WriteLine("Should Exception Be Thrown? " + shouldThrowExcAnswer);
        writer.WriteLine("Array: " + values.StringArr);

        writer.WriteLine();
        writer.Close();
    }
}

