using System;
using System.Collections.Generic;

public static class PathFinder
{
    private const float MOVE_STRAIT_COST = 1;
    private const float MOVE_DIAGONAL_COST = 1.4f;

    public static Stack<Cell> SearchAStar(Cell entry, Cell target)
    {
        List<Cell> openPoints = new() { entry };
        List<Cell> closedPoints = new ();

        entry.gCost = 0;
        entry.hCost = CalculateDistanceCost(entry, target);
        entry.CalculateFCost();

        while (openPoints.Count > 0)
        {
            Cell currentCell = GetLowestFCostCell(openPoints);

            if (currentCell.Position.x == target.Position.x &&
                currentCell.Position.z == target.Position.z)
            {
                return CalculatePath(currentCell);
            }

            openPoints.Remove(currentCell);
            closedPoints.Add(currentCell);

            foreach (Cell neighbour in GetNeighbours(currentCell))
            {
                if (closedPoints.Contains(neighbour)) continue;

                float tentGCost = currentCell.gCost + CalculateDistanceCost(currentCell, neighbour);
                if (tentGCost < neighbour.gCost)
                {
                    neighbour.cameFromCell = currentCell;
                    neighbour.gCost = tentGCost;
                    neighbour.hCost = CalculateDistanceCost(neighbour, target);
                    neighbour.CalculateFCost();

                    if (!openPoints.Contains(neighbour))
                    {
                        openPoints.Add(neighbour);
                    }
                }
            }
        }

        return null;
    }

    private static Stack<Cell> CalculatePath(Cell endCell)
    {
        Stack<Cell> path = new();

        path.Push(endCell);

        Cell currCell = endCell;
        while (currCell.cameFromCell != null)
        {
            path.Push(currCell.cameFromCell);
            currCell = currCell.cameFromCell;
        }

        return path;
    }

    private static List<Cell> GetNeighbours(Cell current)
    {
        List<Cell> neighbours = new();

        for (int x = -1; x < 2; x += 2)
        {
            Cell horizontalNeighbour = current.GetNeighbour(x, 0);
            AddIfFreeToMove(horizontalNeighbour);

            for (int z = -1; z < 2; z += 2)
            {
                Cell verticalNeighbour = current.GetNeighbour(0, z);

                if (x == -1)
                    AddIfFreeToMove(verticalNeighbour);

                if (horizontalNeighbour.IsFreeToMove() && verticalNeighbour.IsFreeToMove())
                {
                    Cell diagonalNeighbour = current.GetNeighbour(x, z);
                    AddIfFreeToMove(diagonalNeighbour);
                }
            }
        }

        return neighbours;

        void AddIfFreeToMove(Cell newCell)
        {
            if (newCell.IsFreeToMove())
            {
                neighbours.Add(newCell);
            }
        }
    }

    private static float CalculateDistanceCost(Cell a, Cell b)
    {
        float xDistance = MathF.Abs(a.Position.x - b.Position.x);
        float zDistance = MathF.Abs(a.Position.z - b.Position.z);
        float remaining = MathF.Abs(xDistance - zDistance);

        return MOVE_DIAGONAL_COST * MathF.Min(xDistance, zDistance) + MOVE_STRAIT_COST * remaining;
    }

    private static Cell GetLowestFCostCell(List<Cell> pathCellsList)
    {
        Cell lowestFCostCell = pathCellsList[0];

        for (int i = 1; i < pathCellsList.Count; i++)
        {
            if (lowestFCostCell.fCost > pathCellsList[i].fCost)
            {
                lowestFCostCell = pathCellsList[i];
            }
        }

        return lowestFCostCell;
    }
}

