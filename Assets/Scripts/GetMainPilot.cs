using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMainPilot : MonoBehaviour
{
    public Sprite Remy, Al, Kurt2;
    private SpriteRenderer mySprite;
    private readonly string selectedPilot = "SelectedPilot";

    private void Awake()
    {
        mySprite = this.GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        int getPilot;

        getPilot = PlayerPrefs.GetInt(selectedPilot);

        switch (getPilot)
        {
            case 1:
                mySprite.sprite = Al;
                break;
            case 2:
                mySprite.sprite = Kurt2;
                break;
            case 3:
                mySprite.sprite = Remy;
                break;
            default:
                mySprite.sprite = Remy;
                break;
        }
    }
}
