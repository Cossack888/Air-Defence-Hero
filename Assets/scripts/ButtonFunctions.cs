using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public GameObject[] turrets;
    [SerializeField] GameObject gunActivator;
    [SerializeField] GameObject GameOverMenu;
    [SerializeField] GameObject pauseMenu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PauseGame();
        }
    }
    public void PauseGame()
    {
        turrets = GameObject.FindGameObjectsWithTag("turret");
        foreach (GameObject turret in turrets)
        {
            turret.SetActive(false);
        }
        gunActivator.SetActive(false);
        if (!GameOverMenu.activeSelf)
        {
            pauseMenu.SetActive(true);
        }
        Time.timeScale = 0f;
    }
    public void ActivateGameOverMenu()
    {
        GameOverMenu.SetActive(true);
    }
    public void ResumeGame()
    {
        turrets = GameObject.FindGameObjectsWithTag("turret");
        foreach (GameObject turret in turrets)
        {
            turret.SetActive(true);
        }
        pauseMenu.SetActive(false);
        gunActivator.SetActive(true);
        Time.timeScale = 1f;
    }
    public void EndGame()
    {
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
