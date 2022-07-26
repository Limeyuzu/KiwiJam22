﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        //FindObjectOfType<GlobalSingleton>().ResetState();
    }

    public static IEnumerator LoadGameOverSceneCoroutine(float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }

    public static void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public static void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public static void LoadBattleScene()
    {
        SceneManager.LoadScene("BattleScene");
    }

    public static void LoadEventScene()
    {
        SceneManager.LoadScene("EventScene");
    }

    public static void LoadWinGameScene()
    {
        SceneManager.LoadScene("WinGameScene");
    }

    public static IEnumerator LoadNextScene(float delay = 0)
    {
        yield return new WaitForSeconds(delay);
        LoadNextScene();
    }

    public static void QuitGame()
    {
        Application.Quit();
    }

    public static void LoadChoose()
    {
        SceneManager.LoadScene(1);
    }
}
