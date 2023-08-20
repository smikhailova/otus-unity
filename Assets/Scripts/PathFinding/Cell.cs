using UnityEngine;

public class Cell
{
    public Vector3Int Position { get; }

    public Cell cameFromCell = null;

    public float gCost = int.MaxValue;
    public float hCost;
    public float fCost;


    public CellType Type
    {
        get
        {
            if (!Map.Exist(Position))
                return CellType.OutOfRange;

            return Map.Field[Position.x, Position.z];
        }
        private set { Map.Field[Position.x, Position.z] = value; }
    }

    public Cell(Vector3Int position)
    {
        Position = position;
    }

    public bool IsFreeToMove()
    {
        if (!Map.Exist(Position)) return false;

        return Type switch
        {
            CellType.Wall => false,
            CellType.Grass => true,
            CellType.Target => true,
            _ => false
        };
    }

    public Cell GetNeighbour(int stepX, int stepZ)
    {
        return new Cell(new Vector3Int(Position.x + stepX, 0, Position.z + stepZ));
    }

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }

    public override string ToString()
    {
        return Position.x + " " + Position.z;
    }
}
