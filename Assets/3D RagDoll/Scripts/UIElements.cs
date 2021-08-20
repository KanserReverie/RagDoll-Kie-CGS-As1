using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This is in all scenes and holds menu functions. It could probably be "static" but the settings pannel changes between some scenes.
public class UIElements : MonoBehaviour
{
    // Saves the Settings Pannel for this scene.
    public GameObject SettingsPannel;           // <--- !!! TO BE SET IN INSPECTOR!!!

    
    
    public void PauseButton()
    {
        Time.timeScale = 0;
    }
    public void ContinueButton()
    {
        Time.timeScale = 1;
    }
    // On the "Retry" Button run this function.
    public void Retry()
    {
        // Unpauses time, just incase. Probs could be removed in this case.
        Time.timeScale = 1;
        // Reloads the current scene.
        // Temp saves the current "ActiveScene".
        Scene scene = SceneManager.GetActiveScene();
        // Loads the temp saved scene or in this case the current scene.
        SceneManager.LoadScene(scene.name);
    }
    
    // This is for the Quit or Exit Buttons.
    public void QuitButton()
    {
        // Unpauses time, just incase. Probs could be removed in this case.
        Time.timeScale = 1;
        // Quits the game.
        Application.Quit();
        // If it is in Editor.
    #if UNITY_EDITOR
        // If in the editor this will just stop playing.
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
    }
    
    // For the Play 1 Button run this function.
    public void PlayGreyBox1()
    {
        // Unpauses time, just incase. Probs could be removed in this case.
        Time.timeScale = 1;
        // Loads the "Play" / Gameplay Scene.
        SceneManager.LoadScene(1);
    }
    
    // For the Play 2 Button run this function.
    public void PlayGreyBox2()
    {
        // Unpauses time, just incase. Probs could be removed in this case.
        Time.timeScale = 1;
        // Loads the "Play" / Gameplay Scene.
        SceneManager.LoadScene(2);
    }
    
    
    // On the "Settings" Button run this function.
    public void OpenSettings()
    {
        // Pauses time to stop the player playing the game while changing the settings.
        Time.timeScale = 0;
        // Turns on the Settings Pannel for this scene.
        SettingsPannel.SetActive(true);
    }
    
    
    // On the "Close Settings" Button run this function.
    public void CloseSettings()
    {
        // Unpauses time for the player.
        Time.timeScale = 1;
        // Turns off the Settings Pannel for this scene.
        SettingsPannel.SetActive(false);
    }
}
