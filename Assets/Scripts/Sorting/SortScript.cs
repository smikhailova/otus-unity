using System.Collections;
using UnityEngine;

public class SortScript : MonoBehaviour
{
    private readonly Color pastelGreenColor = new (.4f, .8f, .4f);

    public int cubesNum = 10;
    public int cubeMaxHeight = 10;
    public NumberedCube[] cubes;

    public void StartSelectionSort()
    {
        InitializeRandomCubes();
        StartCoroutine(SelectionSort(cubes));
    }

    public void StartBubbleSort()
    {
        InitializeRandomCubes();
        StartCoroutine(BubbleSort(cubes));
    }

    void InitializeRandomCubes()
    {
        cubes = new NumberedCube[cubesNum];

        for (int i = 0; i < cubesNum; i++)
        {
            NumberedCube cube = new (cubeMaxHeight, i, this.transform);
            cubes[i] = cube;
        }

        transform.position = new Vector3(-cubesNum / 2f + 2f, -cubeMaxHeight / 2f + .5f, 0);
    }

    IEnumerator BubbleSort(NumberedCube[] arrToSort)
    {
        NumberedCube temp;

        for (int i = 0; i < arrToSort.Length - 1; i++)
        {
            yield return new WaitForSeconds(1);

            for (int j = 0; j < arrToSort.Length - i - 1; j++)
            {
                if (arrToSort[j + 1].GetScaleY()
                    < arrToSort[j].GetScaleY())
                {
                    yield return new WaitForSeconds(1);

                    temp = arrToSort[j];
                    arrToSort[j] = arrToSort[j + 1];
                    arrToSort[j + 1] = temp;

                    arrToSort[j].MoveLocalX(arrToSort[j + 1].GetLocalX());
                    arrToSort[j].MoveLocalZWithPingPong(-3, .5f);

                    arrToSort[j + 1].MoveLocalX(arrToSort[j].GetLocalX());
                    arrToSort[j + 1].MoveLocalZWithPingPong(3, .5f);
                }
            }
            arrToSort[arrToSort.Length - i - 1].ChangeColor(pastelGreenColor);
        }
        arrToSort[0].ChangeColor(pastelGreenColor);
    }

    IEnumerator SelectionSort(NumberedCube[] arrToSort)
    {
        int min;
        NumberedCube temp;

        for (int i = 0; i < arrToSort.Length; i++)
        {
            min = i;

            yield return new WaitForSeconds(1);

            for (int j = i + 1; j < arrToSort.Length; j++)
            {
                if (arrToSort[j].GetScaleY() <
                    arrToSort[min].GetScaleY())
                {
                    min = j;
                }
            }

            if (min != i)
            {
                yield return new WaitForSeconds(1);

                temp = arrToSort[i];
                arrToSort[i] = arrToSort[min];
                arrToSort[min] = temp;

                arrToSort[i].MoveLocalX(arrToSort[min].GetLocalX());
                arrToSort[i].MoveLocalZWithPingPong(-3, .5f);

                arrToSort[min].MoveLocalX(arrToSort[i].GetLocalX());
                arrToSort[min].MoveLocalZWithPingPong(3, .5f);
            }
            arrToSort[i].ChangeColor(pastelGreenColor);
        }
    }
}
