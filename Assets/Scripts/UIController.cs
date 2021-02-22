using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Text wealthText;
    public int currentWealth = 0;
    // Start is called before the first frame update
    void Start()
    {
        UpdateWealth(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            UpdateWealth(1);
        }
    }

    public void UpdateWealth(int update)
    {
        currentWealth += update;
        wealthText.text = currentWealth.ToString();
    }
}
