using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour{
    public int score;

    void StartGame(){
        
    }

    void PauseGame(){
        Time.timeScale = 0f;
    }

    void ResumeGame(){
        Time.timeScale = 1f;
    }

    void ResetGame(){

    }

    void ExitGame(){
        Application.Quit();
    }
}
