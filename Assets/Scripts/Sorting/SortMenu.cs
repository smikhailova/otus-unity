using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

enum SortType : int
{
    Selection = 0,
    Bubble = 1
}

public class SortMenu : MonoBehaviour
{
    public SortScript Sorter;
    public SortScript ActiveSorter;

    private int cubesNum = 10;
    private int cubesMaxHeight = 10;

    public TMP_InputField numInput;
    public TMP_InputField maxHeightInput;

    private SortType sortType = SortType.Selection;


    public void HandleDropdownChange(int val)
    {
        switch (val)
        {
            case 0:
                sortType = SortType.Selection;
                break;
            case 1:
                sortType = SortType.Bubble;
                break;
            default:
                break;
        }
    }

    public void HandleNumInputChange()
    {
        cubesNum = int.Parse(numInput.text);
    }

    public void HandleMaxHeightInputChange()
    {
        cubesMaxHeight = int.Parse(maxHeightInput.text);
    }

    public void StartSorting()
    {
        if (ActiveSorter != null)
        {
            ResetSorting();
        }

        ActiveSorter = Instantiate(Sorter);

        ActiveSorter.cubesNum = cubesNum;
        ActiveSorter.cubeMaxHeight = cubesMaxHeight;

        switch (sortType)
        {
            case SortType.Selection:
                ActiveSorter.StartSelectionSort();
                break;
            case SortType.Bubble:
                ActiveSorter.StartBubbleSort();
                break;
            default:
                break;
        }
    }

    public void ResetSorting()
    {
        Destroy(ActiveSorter.gameObject);
    }

    public void HandleMainMenuClick()
    {
        SceneManager.LoadScene(0);
    }
}
