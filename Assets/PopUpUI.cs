using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpUI : MonoBehaviour
{
    public Quest finalQuest;
    public GameObject finalCanvas;

    // Update is called once per frame
    void Update()
    {
        if (finalQuest.isComplete)
        {
            finalCanvas.SetActive(true);
        }
    }
}
