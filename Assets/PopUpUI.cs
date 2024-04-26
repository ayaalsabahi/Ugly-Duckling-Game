using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpUI : MonoBehaviour
{
    public Quest finalQuest;
    public GameObject finalCanvas;
    private bool setBefore = false; 
    // Update is called once per frame
    void Update()
    {
        if (finalQuest.isComplete & !setBefore)
        {
            finalCanvas.SetActive(true);
            setBefore = true; 
        }
    }

    public void removeQuest()
    {
        Debug.Log("I am being set inactive");
        finalCanvas.SetActive(false);
        setBefore = true; 
    }
}
