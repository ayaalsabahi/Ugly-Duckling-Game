using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endingModes : MonoBehaviour
{

    public void Rampage()
    {
        //here is what happens when user clicks rampage button
        Debug.Log("Rampage mode");

    }
    public void HomeScreen()
    {
        SceneManager.LoadScene("HomePage");
    }


}
