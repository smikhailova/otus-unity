using System.Collections.Generic;
using UnityEngine;

public class LineRendererController : MonoBehaviour
{
    public LineRenderer line;

    private readonly List<Vector3> _path = new();


    public void Awake()
    {
        line.positionCount = 0;
    }

    public void AddPoint(Vector3 point)
    {
        line.positionCount++;
        _path.Add(point);
    }

    void Update()
    {
        for (int i = 0; i < _path.Count; i++)
        {
            line.SetPosition(i, _path[i]);
        }
    }
}
