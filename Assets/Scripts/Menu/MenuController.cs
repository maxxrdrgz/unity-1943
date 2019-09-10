using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    /** 
        Loads the gameplay scene
    */
    public void PlayGame(){
        SceneManager.LoadScene("Gameplay");
    }
}
