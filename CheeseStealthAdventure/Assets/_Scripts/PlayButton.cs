using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class PlayButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MenuScreen()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void LoadOptions()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    public void LoadCredits()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(5);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void XtraChz()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }

    public void CheeseCrisis()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(4);
    }

}
