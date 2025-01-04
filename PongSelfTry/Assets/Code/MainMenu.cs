using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainLoad : MonoBehaviour
{
    public float transitionTime;
    public Animator transition;
    public void PlayGame()
    {
        StartCoroutine(PlayGame(1));
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

    public void StartTransition()
    {
        transition.Play("Fade");
    }
}
