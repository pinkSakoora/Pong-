using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;
    public float transitionTime;
    public Animator transition;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            PostProcessVolume ppVolume = Camera.main.gameObject.GetComponent<PostProcessVolume>();
            if (isPaused)
            {
                ResumeGame();
                ppVolume.enabled = false;
            }
            else
            {
                PauseGame();
                ppVolume.enabled = true;
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        PostProcessVolume ppVolume = Camera.main.gameObject.GetComponent<PostProcessVolume>();
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        ppVolume.enabled = false;
    }

    public void GoToMainMenu()
    {
        StartCoroutine(PlayGame(0));
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    IEnumerator PlayGame(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
