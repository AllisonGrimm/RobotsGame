using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    public static CharacterController2D character;
    public int currentWealth = 0;

    private int enemiesLeft = 0;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

        UpdateWealth(0);
    }

    // Update is called once per frame
    void Update()
    {
        bool isCharge = false;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLeft = enemies.Length;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

        if (SceneManager.GetActiveScene().ToString() == "Charge Station")
        {
            isCharge = true;
            character.currentHealth = character.maxHealth;
        }

        if (enemiesLeft == 0 && !isCharge)
        {
            SceneManager.LoadScene("Map");
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            SceneManager.LoadScene("Map");
        }
    }

    public void UpdateWealth(int update)
    {
        currentWealth += update;
        UIController.Instance.wealthText.text = currentWealth.ToString();
    }

    public void PauseGame()
    {
        if (UIController.Instance.pauseScreen.activeInHierarchy)
        {
            UIController.Instance.pauseScreen.SetActive(false);
            Time.timeScale = 1.0f;

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            UIController.Instance.pauseScreen.SetActive(true);
            Time.timeScale = 0.0f;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void ToggleSettings()
    {
        if (UIController.Instance.settingsScreen.activeInHierarchy)
        {
            UIController.Instance.settingsScreen.SetActive(false);
            Time.timeScale = 1.0f;
        }
        else
        {
            UIController.Instance.settingsScreen.SetActive(true);
            Time.timeScale = 0.0f;

        }
    }
}
