using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public Text console;
    private static GameMaster _instance;

    public static GameMaster Instance
    {
        get
        {
            return _instance;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        if (GameMaster.Instance!= null) { 
            Destroy(this);
        }   
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        {
            //Debug.Log(mousePos.x + "," + mousePos.y);
            console.text = mousePos.x + "," + mousePos.y;
        }
        
    }
}
