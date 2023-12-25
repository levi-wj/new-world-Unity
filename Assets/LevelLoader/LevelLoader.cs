using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    [SerializeField] int timeToWait = 5;

    void Start()
    {
        if(timeToWait != 0)
        {
            StartCoroutine(LoadMenuWithWait());
        }

    }

    IEnumerator LoadMenuWithWait()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadLevel(1);
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void Quit()
    {
        Debug.Log("You quit.");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReloadScene(){
        LoadLevel(SceneManager.GetActiveScene().buildIndex);
    }
}
