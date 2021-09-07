using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputField))]
public class CustomTextSubmission : MonoBehaviour
{
    GameMaster gm;
    InputField inpf;
    public GameObject inputPanel;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameMaster.Instance;
        inpf = GetComponent<InputField>();
        Reset();
    }

    private void Reset()
    {
        inpf.text = null;
        inputPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inputPanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                gm.CustomStampEvent(inpf.text);
                Reset();                
            }
        }
    }
}
