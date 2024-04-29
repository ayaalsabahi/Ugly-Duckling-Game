using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderScript : MonoBehaviour
{
    public GameObject playerDuck;
    private Rigidbody duckrb;
    private PlayerController duckpc;
    public GameObject water;

    Slider[] sliders;

    [SerializeField] private Slider slider1;
    [SerializeField] private Slider slider2;
    [SerializeField] private Slider slider3;
    [SerializeField] private Slider slider4;
    [SerializeField] private Slider slider5;
    [SerializeField] private Slider slider6;

    [SerializeField] private TextMeshProUGUI slider1Text;
    [SerializeField] private TextMeshProUGUI slider2Text;
    [SerializeField] private TextMeshProUGUI slider3Text;
    [SerializeField] private TextMeshProUGUI slider4Text;
    [SerializeField] private TextMeshProUGUI slider5Text;
    [SerializeField] private TextMeshProUGUI slider6Text;

    private void Start()
    {
        // Prepare water and duck components
        duckrb = playerDuck.GetComponent<Rigidbody>();
        duckpc = playerDuck.GetComponent<PlayerController>();

        sliders = FindObjectsOfType<Slider>();

        // Set default values
        btn_ResetSliders();

        // Static Friction
        slider1.onValueChanged.AddListener((v) => {

            slider1Text.text = v.ToString("0.00");
            water.GetComponent<Collider>().material.staticFriction = v;

        });

        // Dynamic Friction
        slider2.onValueChanged.AddListener((v) => {

            slider2Text.text = v.ToString("0.00");
            water.GetComponent<Collider>().material.dynamicFriction = v;

        });

        // Drag
        slider3.onValueChanged.AddListener((v) => {

            slider3Text.text = v.ToString("0.00");
            duckrb.drag = v;
        });

        // Angular Drag
        slider4.onValueChanged.AddListener((v) => {

            slider4Text.text = v.ToString("0.00");
            duckrb.angularDrag = v;
        });

        // Mass
        slider5.onValueChanged.AddListener((v) => {

            slider5Text.text = v.ToString("0.00");
            duckrb.mass = v;
        });

        // Move Force
        slider6.onValueChanged.AddListener((v) => {

            slider6Text.text = v.ToString("0.00");
            duckpc.moveForce = v;
        });

    }

    public void btn_ResetSliders()
    {
        for (int i = 0; i < sliders.Length; i++)
        {
            // Setting the default values for all variables
            switch (sliders[i].name)
            {
                case "FrictionSlider":
                    sliders[i].value = 0.0f;
                    break;
                case "DynamicSlider":
                    sliders[i].value = 0.0f;
                    break;
                case "DragSlider":
                    sliders[i].value = 3.0f;
                    break;
                case "AngularDragSlider":
                    sliders[i].value = 0.05f;
                    break;
                case "MassSlider":
                    sliders[i].value = 1.0f;
                    break;
                case "MoveForceSlider":
                    sliders[i].value = 3.0f;
                    break;
                default:
                    // Handle default case
                    break;
            }
            //Debug.Log(sliders[i].name);
        }
      
    }
}
