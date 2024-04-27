using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderScript : MonoBehaviour
{
    [SerializeField] private Slider slider1;
    [SerializeField] private Slider slider2;
    [SerializeField] private Slider slider3;
    [SerializeField] private Slider slider4;

    [SerializeField] private TextMeshProUGUI slider1Text;
    [SerializeField] private TextMeshProUGUI slider2Text;
    [SerializeField] private TextMeshProUGUI slider3Text;
    [SerializeField] private TextMeshProUGUI slider4Text;

    private void Start()
    {
        slider1.onValueChanged.AddListener((v) => {

            slider1Text.text = v.ToString("0.00");

        });

        slider2.onValueChanged.AddListener((v) => {

            slider2Text.text = v.ToString("0.00");

        });
    }
}
