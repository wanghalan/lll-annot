using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Tutorial seen from https://www.youtube.com/watch?v=VyIo5tlNNeA

public class PopulateGrid : MonoBehaviour
{
    public GameObject prefab;
    public GridLayoutGroup glg;
    public int cell_x_count = 20;
    public int cell_y_count = 10;
    public int padding = 50;
    public int spacing = 3;
    // Start is called before the first frame update
    void Start()
    {        
        Calibrate();
        Populate();
    }

    private void FixedUpdate()
    {
        //Debug.Log("Calibrating");
        Calibrate();
    }

    Vector3 ConverToWorldPosition(Vector3 mousePos)
    {
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        return worldPosition;
    }

    void Calibrate()
    {
        //GridLayoutGroup glg = gameObject.GetComponent<GridLayoutGroup>();

        float cell_x_size = (Screen.width - 2 * padding - spacing * cell_x_count) / cell_x_count;
        float cell_y_size = (Screen.height - 2 * padding - spacing * cell_y_count) / cell_y_count;
        Debug.Log("Cell x: " + cell_x_size);
        Debug.Log("Cell y: " + cell_y_size);
        glg.cellSize= new Vector2(cell_x_size, cell_y_size);
        glg.spacing = new Vector2(spacing, spacing);
        Debug.Log("Cell size: "+ glg.cellSize.x);
    }

    void Populate()
    {
        for (int i = 0; i < 200; i++)
        {
            GameObject newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponentInChildren<Text>().text = i.ToString();
        }
    }
}
