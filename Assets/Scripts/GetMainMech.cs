using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMainMech : MonoBehaviour
{
    public Sprite Tesla, Excali, Flamey;
    private SpriteRenderer mySprite;
    private readonly string selectedMech = "SelectedMech";

    private void Awake()
    {
        mySprite = this.GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        int getMech;

        getMech = PlayerPrefs.GetInt(selectedMech);

        switch(getMech)
        {
            case 1:
                mySprite.sprite = Excali;
                break;
            case 2:
                mySprite.sprite = Flamey;
                break;
            case 3:
                mySprite.sprite = Tesla;
                break;
            default:
                mySprite.sprite = Tesla;
                break;
        }
    }
}
