using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Using TextMeshPro library

public class Keybinds : MonoBehaviour
{
    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public TMP_Text UP, DOWN, LEFT, RIGHT, ACTION1, ACTION2, ACTION3;

    private GameObject currentKey; // Key that we are editing right now

    private Color32 normal = new Color(0, 0, 0);
    private Color32 selected = new Color(0.6901922f, 0.6934152f, 0.8867924f);

    // Start is called before the first frame update
    void Start()
    {
        keys.Add("Up", KeyCode.W);
        keys.Add("Down", KeyCode.S);
        keys.Add("Left", KeyCode.A);
        keys.Add("Right", KeyCode.D);
        keys.Add("Action1", KeyCode.Q);
        keys.Add("Action2", KeyCode.E);
        keys.Add("Action3", KeyCode.R);

        UP.text = keys["Up"].ToString();
        DOWN.text = keys["Down"].ToString();
        LEFT.text = keys["Left"].ToString();
        RIGHT.text = keys["Right"].ToString();
        ACTION1.text = keys["Action1"].ToString();
        ACTION2.text = keys["Action2"].ToString();
        ACTION3.text = keys["Action3"].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keys["Up"]))
        {
            // Do a move action
            Debug.Log("Up");
        }
        if (Input.GetKeyDown(keys["Down"]))
        {
            // Do a move action
            Debug.Log("Down");
        }
        if (Input.GetKeyDown(keys["Left"]))
        {
            // Do a move action
            Debug.Log("Left");
        }
        if (Input.GetKeyDown(keys["Right"]))
        {
            // Do a move action
            Debug.Log("Right");
        }
        if (Input.GetKeyDown(keys["Action1"]))
        {
            // Do a move action
            Debug.Log("Action1");
        }
        if (Input.GetKeyDown(keys["Action2"]))
        {
            // Do a move action
            Debug.Log("Action2");
        }
        if (Input.GetKeyDown(keys["Action3"]))
        {
            // Do a move action
            Debug.Log("Action3");
        }
    }

    private void OnGUI()
    {
        if(currentKey != null)
        {
            Event e = Event.current;
            if(e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<TMP_Text>().text = e.keyCode.ToString();
                currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        if(currentKey != null)
        {
            currentKey.GetComponent<Image>().color = normal;
        }
        currentKey = clicked;
        currentKey.GetComponent<Image>().color = selected;
    }
}
