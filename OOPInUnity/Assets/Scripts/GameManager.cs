/*
* (Conner Ogle)
* (Assignment 6)
* (Manages the scenes and menus)
*/
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public int score;
    //variable to track current level
    private string CurrentLevelName = string.Empty;

    public GameObject pauseMenu;


   /* #region This code makes this class a Singleton
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //make sure this game manager persists across scenes
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Debug.LogError("Trying to instantiate a second instance of a singleton Game Manager");
        }
    }
    #endregion*/

    //methods to load and unload scenes
    public void LoadLevel(string LevelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(LevelName, LoadSceneMode.Additive);
        if ( ao == null)
        {
            Debug.LogError("[GameManager] Unable to load level " + LevelName);
            return;
        }

        CurrentLevelName = LevelName;
    }

    public void UnloadLevel(string LevelName)
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(LevelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload level " + LevelName);
            return;
        }


    }

    //pausing and unpausing
    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }
    public void Unpause()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
    }

    public void UnloadCurrentLevel()
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(CurrentLevelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload level " + CurrentLevelName);
            return;
        }


    }
}



