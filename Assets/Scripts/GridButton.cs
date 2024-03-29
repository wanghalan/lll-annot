﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GridButton : MonoBehaviour, IPointerEnterHandler
{
    GameMaster gm;
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameMaster.Instance;
        button = GetComponent<Button>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        gm.hoveredButton = button;
        // Debug.Log("Entered button " + name);        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gm.hoveredButton = null;
    }

    public void NormalClick()
    {
        // A normal click symbolizes the moving of the person himself
        //gm.consoleText.text = "Observer moved " + name;
        gm.StampEvent("Observer location", name);
    }
}
