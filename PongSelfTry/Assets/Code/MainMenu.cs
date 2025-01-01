using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainLoad : MonoBehaviour
{
    public float transitionTime;
    public Animator transition;
    public void PlayGame1()
    {
        StartCoroutine(PlayGame(1));
    }
    public void PlayGame2()
    {
        StartCoroutine(PlayGame(2));
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
