using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagerScript : MonoBehaviour
{



    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }


    public void GuessTheNumber()
    {
        SceneManager.LoadScene(1);
    }

    public void Hangman()
    {
        SceneManager.LoadScene(2);
        
    }

}
