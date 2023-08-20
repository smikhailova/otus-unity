using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PathFindingController : MonoBehaviour
{
    public GameObject GrassPrefab;
    public GameObject WallPrefab;
    public GameObject TargetPrefab;

    public int WorldWidth = 10;
    public int WorldHeight = 10;


    void Start()
    {
        Map.Init(GenerateGround(), WorldWidth, WorldHeight);
    }

    private List<GameObject> GenerateGround()
    {
        List<GameObject> items = new();

        for (int x = 0; x < WorldWidth; x++)
        {
            for (int z = 0; z < WorldHeight; z++)
            {
                GameObject item = Instantiate(GrassPrefab, new Vector3(x, 0, z), Quaternion.identity);
                items.Add(item);
            }
        }

        return items;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.Z))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                GameObject gameObject = hit.transform.gameObject;

                if (gameObject.CompareTag("Grass"))
                {
                    Vector3 pos = new((int)gameObject.transform.position.x, .5f, (int)gameObject.transform.position.z);

                    Instantiate(WallPrefab, pos, Quaternion.identity);

                    Map.Field[
                        (int)gameObject.transform.position.x,
                        (int)gameObject.transform.position.z
                    ] = CellType.Wall;
                }
            }
        }

        if (Input.GetMouseButton(0) && !Input.GetKey(KeyCode.Z))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                GameObject gameObject = hit.transform.gameObject;

                if (gameObject.CompareTag("Grass"))
                {
                    Vector3 pos = new((int)gameObject.transform.position.x, 0, (int)gameObject.transform.position.z);

                    Instantiate(TargetPrefab, pos, Quaternion.identity);

                    Map.Field[
                        (int)gameObject.transform.position.x,
                        (int)gameObject.transform.position.z
                    ] = CellType.Target;
                }
            }
        }
    }

    public void HandleMainMenuClick()
    {
        SceneManager.LoadScene(0);
    }
}
