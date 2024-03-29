﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using System.IO;

[Serializable] public class stringMapping : SerializableDictionary<KeyCode, string> { }
public class GameMaster : MonoBehaviour
{
    public Text consoleText;
    public Text timeText;
    // public Text historyText;
    public UnityEngine.UIElements.ScrollView sv;
    private static GameMaster _instance;
    [HideInInspector]
    public Button hoveredButton; //The button that is currently being hovered over

    public stringMapping myMapping;
    private static string savePath;
    private static string tempLocation;

    [Tooltip("The amount of time after one click after which another input can be added")]
    public float clickTimeThresh = 0.1f;
    private float lastClickedTime;
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
        if (GameMaster.Instance != null) {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
        lastClickedTime = Time.time;
        savePath = Application.persistentDataPath +"/"+ System.DateTime.Now.ToString("yyMMdd_hhmmss") + ".txt";
        Debug.Log("Files will be saved to: " + savePath);
        consoleText.text = ""; //Clearing console text
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = System.DateTime.Now.ToString();

        Vector3 mousePos = Input.mousePosition;
        {
            //Debug.Log(mousePos.x + "," + mousePos.y);
            //console.text = mousePos.x + "," + mousePos.y;
        }

        //List<KeyCode> codes = new List<KeyCode> { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.C};
        //string[] strings = new string[] { w_text, a_text, s_text, d_text };

        // Debug.Log((Time.time - lastClickedTime));
        if (hoveredButton != null && (Time.time - lastClickedTime) > clickTimeThresh) 
        {

            foreach (KeyCode kcode in myMapping.Keys)
            {
                if (Input.GetKey(kcode))
                {
                    lastClickedTime = Time.time;
                    hoveredButton.onClick.Invoke();
                    StampEvent(myMapping[kcode], hoveredButton.name);
                    // hoveredButton = null;
                    break;                    
                }
            }
        }
    }

    public void StampEvent(string eventDescript, string location){
        string saveStr = System.DateTime.Now.ToString("yy/MM/dd hh:mm:ss.fff") + "," + location + "," + eventDescript;
        consoleText.text = saveStr;
        WriteString(saveStr);
    }

    public void CustomStampEvent(string eventDescript)
    {
        string saveStr = System.DateTime.Now.ToString("yy/MM/dd hh:mm:ss.fff") + "," + tempLocation + "," + eventDescript;
        consoleText.text = saveStr;
        tempLocation = null;
        WriteString(saveStr);
    }

    public static void WriteString(string str)
    {
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(savePath, true);
        writer.WriteLine(str);
        writer.Close();
    }
}
