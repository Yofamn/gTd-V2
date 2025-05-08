using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake(){
        if(instance){
            Destroy(this);
        }
        else {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }
    public static void LoadScene(string newSceneName){
        print(newSceneName);
        SceneManager.LoadScene(newSceneName);
        Cursor.lockState = CursorLockMode.None;
    }
    public static void Quit(){
        Application.Quit();
    }
}
