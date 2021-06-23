using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{
    public static MapController Instance { get; private set; }
    private static readonly System.Random random = new System.Random();
    private static readonly object syncLock = new object();

    public GameObject Elite1;
    public GameObject Enemy1;
    public GameObject Charge1;
    public GameObject Elite2;
    public GameObject Enemy2;
    public GameObject Charge2;
    public GameObject Elite3;
    public GameObject Enemy3;
    public GameObject Charge3;
    public GameObject Arrow1;
    public GameObject Arrow2;
    public GameObject Arrow3;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        disableOjects();

        beginRandomization();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ArrowMovement(true);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ArrowMovement(false);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneSelect();
        }
    }


    public int mapCircleRandomizer()
    {
        lock (syncLock)
        { // synchronize
            return random.Next(0, 3);
        }
    }

    public int EnemySceneRandomizer()
    {
        lock (syncLock)
        {
            return random.Next(1, 5);
        }
    }

    public int EliteSceneRandomizer()
    {
        lock (syncLock)
        {
            return 1;
        }
    }

    public void disableOjects()
    {
        Elite1.SetActive(false);
        Enemy1.SetActive(false);
        Charge1.SetActive(false);
        Elite2.SetActive(false);
        Enemy2.SetActive(false);
        Charge2.SetActive(false);
        Elite3.SetActive(false);
        Enemy1.SetActive(false);
        Charge1.SetActive(false);
        Arrow1.SetActive(false);
        Arrow2.SetActive(true);
        Arrow3.SetActive(false);
    }

    public void EnableRandoms(int firstRandom, int secondRandom, int thirdRandom)
    {
        switch(firstRandom)
        {
            case 0:
                Elite1.SetActive(true);
                break;

            case 1:
                Enemy1.SetActive(true);
                break;

            case 2:
                Charge1.SetActive(true);
                break;
        }

        switch (secondRandom)
        {
            case 0:
                Elite2.SetActive(true);
                break;

            case 1:
                Enemy2.SetActive(true);
                break;

            case 2:
                Charge2.SetActive(true);
                break;
        }

        switch (thirdRandom)
        {
            case 0:
                Elite3.SetActive(true);
                break;

            case 1:
                Enemy3.SetActive(true);
                break;

            case 2:
                Charge3.SetActive(true);
                break;
        }

    }

    public void ArrowMovement(bool lR)
    {
        if (Arrow1.activeInHierarchy)
        {
            Arrow1.SetActive(false);
            if (lR)
            {
                Arrow2.SetActive(true);
            }

            else
            {
                Arrow3.SetActive(true);
            }
        }

        else if (Arrow2.activeInHierarchy)
        {
            Arrow2.SetActive(false);
            if (lR)
            {
                Arrow3.SetActive(true);
            }

            else
            {
                Arrow1.SetActive(true);
            }
        }

        else if (Arrow3.activeInHierarchy)
        {
            Arrow3.SetActive(false);
            if (lR)
            {
                Arrow1.SetActive(true);
            }

            else
            {
                Arrow2.SetActive(true);
            }
        }
    }

    public void beginRandomization()
    {
        StartCoroutine(DelayAction(3));
    }

    public void SceneSelect()
    {
        if (Arrow1.activeInHierarchy)
        {
            if (Elite1.activeInHierarchy)
            {
                chooseEliteScene();
            }

            if (Enemy1.activeInHierarchy)
            {
                chooseFightScene();
            }

            if (Charge1.activeInHierarchy)
            {
                chooseChargeStation();
            }
        }

        if (Arrow2.activeInHierarchy)
        {
            if (Elite2.activeInHierarchy)
            {
                chooseEliteScene();
            }

            if (Enemy2.activeInHierarchy)
            {
                chooseFightScene();
            }

            if (Charge2.activeInHierarchy)
            {
                chooseChargeStation();
            }
        }

        if (Arrow3.activeInHierarchy)
        {
            if (Elite3.activeInHierarchy)
            {
                chooseEliteScene();
            }

            if (Enemy3.activeInHierarchy)
            {
                chooseFightScene();
            }

            if (Charge3.activeInHierarchy)
            {
                chooseChargeStation();
            }
        }
    }

    public void chooseEliteScene()
    {
        int nextLevel = EliteSceneRandomizer();
        string levelName = "EliteFight" + nextLevel;

        SceneManager.LoadScene(levelName);
    }

    public void chooseFightScene()
    {
        int nextLevel = EnemySceneRandomizer();
        string levelName = "Fight" + nextLevel;

        SceneManager.LoadScene(levelName);
    }

    public void chooseChargeStation()
    {
        SceneManager.LoadScene("ChargeStation");
    }

    IEnumerator DelayAction(float delayTime)
    {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(delayTime);

        int rand1 = mapCircleRandomizer();
        int rand2 = mapCircleRandomizer();
        int rand3 = mapCircleRandomizer();

        EnableRandoms(rand1, rand2, rand3);

        //Do the action after the delay time has finished.
    }
}
