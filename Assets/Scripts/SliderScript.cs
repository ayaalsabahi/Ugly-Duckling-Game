using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderScript : MonoBehaviour
{
    public GameObject playerDuck;
    private Rigidbody duckrb;
    public GameObject water;

    Slider[] sliders;

    [SerializeField] private Slider slider1;
    [SerializeField] private Slider slider2;
    [SerializeField] private Slider slider3;
    [SerializeField] private Slider slider4;
    [SerializeField] private Slider slider5;
    [SerializeField] private Slider slider6;
    [SerializeField] private Slider slider7;

    [SerializeField] private TextMeshProUGUI slider1Text;
    [SerializeField] private TextMeshProUGUI slider2Text;
    [SerializeField] private TextMeshProUGUI slider3Text;
    [SerializeField] private TextMeshProUGUI slider4Text;
    [SerializeField] private TextMeshProUGUI slider5Text;
    [SerializeField] private TextMeshProUGUI slider6Text;
    [SerializeField] private TextMeshProUGUI slider7Text;

    private void Start()
    {
        duckrb = playerDuck.GetComponent<Rigidbody>();

        sliders = FindObjectsOfType<Slider>();

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

            slider4Text.text = v.ToString("0.00");

        });

        // Angular Drag
        slider3.onValueChanged.AddListener((v) => {

            slider4Text.text = v.ToString("0.00");

        });

        // Mass
        slider3.onValueChanged.AddListener((v) => {

            slider4Text.text = v.ToString("0.00");

        });

        // Move Speed
        slider3.onValueChanged.AddListener((v) => {

            slider4Text.text = v.ToString("0.00");

        });

        // Move Force
        slider3.onValueChanged.AddListener((v) => {

            slider4Text.text = v.ToString("0.00");

        });
    }

    public void btn_ResetSliders()
    {
        for (int i = 0; i < sliders.Length; i++)
            sliders[i].value = 0;
    }
}
