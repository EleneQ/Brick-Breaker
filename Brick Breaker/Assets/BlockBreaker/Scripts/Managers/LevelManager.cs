using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField] float delayToLoad = 2f;

    private void Awake()
    {
        instance = this;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public IEnumerator ReplayLevel()
    {
        yield return new WaitForSeconds(delayToLoad);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(delayToLoad);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public IEnumerator LoadGameOverScreen()
    {
        yield return new WaitForSeconds(delayToLoad);
        SceneManager.LoadScene("GameOver");
    }
}
