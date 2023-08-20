using UnityEngine;

enum Coordinate : int
{
    x,
    y,
    z
}

public class NumberedCube
{
    public GameObject cube;


    public NumberedCube(int maxHeight, int index, Transform parent)
    {
        int randomNum = Random.Range(1, maxHeight + 1);

        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        cube.transform.localScale = new Vector3(0.9f, randomNum, 1);
        cube.transform.position = new Vector3(index, randomNum / 2f, 0);
        cube.transform.SetParent(parent);

        cube.GetComponent<Renderer>().material.color = new Color(.9f, .9f, .9f);

        CreateNumberOnCube(randomNum);
    }

    private void CreateNumberOnCube(int num)
    {
        GameObject textObject = new("Text");
        textObject.transform.SetParent(cube.transform);
        textObject.transform.localPosition = new Vector3(0, 0, -0.51f);

        TextMesh textMesh = textObject.AddComponent<TextMesh>();
        textMesh.text = num.ToString();
        textMesh.fontSize = num < 10 ? 100 : 80;
        textMesh.anchor = TextAnchor.MiddleCenter;
        textMesh.alignment = TextAlignment.Center;
        textMesh.characterSize = .1f;
        textMesh.font.material.color = Color.white;
    }

    public float GetScaleY()
    {
        return GetScaleCoordinate(Coordinate.y);
    }

    private float GetScaleCoordinate(Coordinate position)
    {

        return position switch
        {
            Coordinate.y => cube.transform.localScale.y,
            _ => 0,
        };
    }

    public float GetLocalX()
    {
        return GetLocalCoordinate(Coordinate.x);
    }

    private float GetLocalCoordinate(Coordinate Coordinate)
    {
        return Coordinate switch
        {
            Coordinate.x => cube.transform.localPosition.x,
            _ => 0,
        };
    }

    public void ChangeColor(Color color, float time = 1)
    {
        LeanTween.color(cube, color, time);
    }


    public void MoveLocalX(float position, float time = 1)
    {
        MoveLocalCoordinate(Coordinate.x, position, time);
    }

    public void MoveLocalXWithPingPong(float position, float time = 1)
    {
        MoveLocalCoordinate(Coordinate.x, position, time).setLoopPingPong(1);
    }

    public void MoveLocalZ(float position, float time = 1)
    {
        MoveLocalCoordinate(Coordinate.z, position, time);
    }

    public void MoveLocalZWithPingPong(float position, float time = 1)
    {
        MoveLocalCoordinate(Coordinate.z, position, time).setLoopPingPong(1);
    }

    private LTDescr MoveLocalCoordinate(Coordinate coordinate, float position, float time = 1)
    {
        return coordinate switch
        {
            Coordinate.x => LeanTween.moveLocalX(cube, position, time),
            Coordinate.z => LeanTween.moveLocalZ(cube, position, time),
            _ => LeanTween.moveLocalX(cube, position, time),
        };
    }
}

