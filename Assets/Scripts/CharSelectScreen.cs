using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharSelectScreen : MonoBehaviour
{

    // Pilot characters
    public GameObject Remy;
    public GameObject Al;
    public GameObject Kurt2;

    // Mech characters
    public GameObject Tesla;
    public GameObject Excali;
    public GameObject Flamey;

    private Vector3 PilotPosition;
    private Vector3 MechPosition;
    private Vector3 PilotOffScreen;
    private Vector3 MechOffScreen;

    private int PilotInt = 1;
    private int MechInt = 1;

    private SpriteRenderer RemyRender, AlRender, Kurt2Render;
    private SpriteRenderer TeslaRender, ExcaliRender, FlameyRender;

    private readonly string selectedPilot = "SelectedPilot";
    private readonly string selectedMech = "SelectedMech";

    private void Awake()
    {
        PilotPosition = Remy.transform.position;
        PilotOffScreen = Al.transform.position;

        MechPosition = Tesla.transform.position;
        MechOffScreen = Excali.transform.position;

        RemyRender = Remy.GetComponent<SpriteRenderer>();
        AlRender = Remy.GetComponent<SpriteRenderer>();
        Kurt2Render = Remy.GetComponent<SpriteRenderer>();

        TeslaRender = Tesla.GetComponent<SpriteRenderer>();
        ExcaliRender = Tesla.GetComponent<SpriteRenderer>();
        FlameyRender = Tesla.GetComponent<SpriteRenderer>();
    }

    // Code for Pilot character selection
    public void NextPilot() // Switches to next pilot character when the right arrow button is pressed
    {
        switch(PilotInt)
        {
            case 1: // Changes from Remy to Al
                PlayerPrefs.SetInt(selectedPilot, 1);
                RemyRender.enabled = false;
                Remy.transform.position = PilotOffScreen;
                Al.transform.position = PilotPosition;
                AlRender.enabled = true;
                PilotInt++;
                break;
            case 2: // Changes from Al to Kurt2
                PlayerPrefs.SetInt(selectedPilot, 2);
                AlRender.enabled = false;
                Al.transform.position = PilotOffScreen;
                Kurt2.transform.position = PilotPosition;
                Kurt2Render.enabled = true;
                PilotInt++;
                break;
            case 3: // Changes from Kurt2 back to Remy
                PlayerPrefs.SetInt(selectedPilot, 3);
                Kurt2Render.enabled = false;
                Kurt2.transform.position = PilotOffScreen;
                Remy.transform.position = PilotPosition;
                RemyRender.enabled = true;
                PilotInt++;
                ResetPilotInt();
                break;
            default:
                ResetPilotInt();
                break;
        }
    }

    public void PrevPilot()
    {
        switch (PilotInt)
        {
            case 1: // Changes from Remy to Kurt2
                PlayerPrefs.SetInt(selectedPilot, 2);
                RemyRender.enabled = false;
                Remy.transform.position = PilotOffScreen;
                Kurt2.transform.position = PilotPosition;
                Kurt2Render.enabled = true;
                ResetPilotInt();
                break;
            case 2: // Changes from Al to Remy
                PlayerPrefs.SetInt(selectedPilot, 3);
                AlRender.enabled = false;
                Al.transform.position = PilotOffScreen;
                Remy.transform.position = PilotPosition;
                RemyRender.enabled = true;
                PilotInt--;
                break;
            case 3: // Changes from Kurt2 to Al
                PlayerPrefs.SetInt(selectedPilot, 1);
                Kurt2Render.enabled = false;
                Kurt2.transform.position = PilotOffScreen;
                Al.transform.position = PilotPosition;
                AlRender.enabled = true;
                PilotInt--;
                break;
            default:
                ResetPilotInt();
                break;
        }
    }

    private void ResetPilotInt()
    {
        if (PilotInt >= 3)
        {
            PilotInt = 1;
        }
        else
            PilotInt = 3;
    }


    // Code for Mech character selection

    public void NextMech()
    {
        switch (MechInt)
        {
            case 1: // Tesla to Excalibur
                PlayerPrefs.SetInt(selectedMech, 1);
                TeslaRender.enabled = false;
                Tesla.transform.position = MechOffScreen;
                Excali.transform.position = MechPosition;
                ExcaliRender.enabled = true;
                MechInt++;
                break;
            case 2: // Excalibur to Flamey(Lightbulb)
                PlayerPrefs.SetInt(selectedMech, 2);
                ExcaliRender.enabled = false;
                Excali.transform.position = MechOffScreen;
                Flamey.transform.position = MechPosition;
                FlameyRender.enabled = true;
                MechInt++;
                break;
            case 3: // Flamey(Lightbulb) back to Tesla
                PlayerPrefs.SetInt(selectedMech, 3);
                FlameyRender.enabled = false;
                Flamey.transform.position = MechOffScreen;
                Tesla.transform.position = MechPosition;
                TeslaRender.enabled = true;
                MechInt++;
                ResetMechInt();
                break;
            default:
                ResetMechInt();
                break;
        }
    }

    public void PrevMech()
    {
        switch (MechInt)
        {
            case 1: // Tesla to Flamey(Lightbulb)
                PlayerPrefs.SetInt(selectedMech, 2);
                TeslaRender.enabled = false;
                Tesla.transform.position = MechOffScreen;
                Flamey.transform.position = MechPosition;
                FlameyRender.enabled = true;
                ResetMechInt();
                break;
            case 2: // Excalibur to Tesla
                PlayerPrefs.SetInt(selectedMech, 3);
                ExcaliRender.enabled = false;
                Excali.transform.position = MechOffScreen;
                Tesla.transform.position = MechPosition;
                TeslaRender.enabled = true;
                MechInt--;
                break;
            case 3: // Flamey to Excalibur
                PlayerPrefs.SetInt(selectedMech, 1);
                FlameyRender.enabled = false;
                Flamey.transform.position = MechOffScreen;
                Excali.transform.position = MechPosition;
                ExcaliRender.enabled = true;
                MechInt--;
                break;
            default:
                ResetMechInt();
                break;
        }
    }

    private void ResetMechInt()
    {
        if (MechInt >= 3)
        {
            MechInt = 1;
        }
        else
            MechInt = 3;
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(2);
    }
}
