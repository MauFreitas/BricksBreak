using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StarMenu : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit button Pushed");
    }
    public void StarGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
