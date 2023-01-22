using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    Gameplay game;

    public InputField powerInput;
    public InputField angleInput;
    public Button fireButton;

    public int powerInputValue;
    public int angleInputValue;

    void Start()
    {
        if (fireButton)
        {
            fireButton.onClick.AddListener(() => game.Fire());
        }
    }

    void Update()
    {
        powerInputValue = int.Parse(powerInput.text);
        angleInputValue = int.Parse(angleInput.text);
    }
}
