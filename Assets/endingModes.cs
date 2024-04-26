using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endingModes : MonoBehaviour
{
    public GameEvent buttonClicked; 
    public void Rampage()
    {
        //here is what happens when user clicks rampage button
        Debug.Log("Rampage mode");
        buttonClicked.Raise();

    }
    public void HomeScreen()
    {
        SceneManager.LoadScene("HomePage");
        buttonClicked.Raise();
    }


}
