using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    public Camera goodCamera;
    public Camera badCamera;

    
    // Start is called before the first frame update
    void Awake()
    {
        goodCamera.enabled = false;
        badCamera.enabled = true;
    }

}
