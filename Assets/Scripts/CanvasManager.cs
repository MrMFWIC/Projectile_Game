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

    public float powerInputValue;
    public float angleInputValue;

    void Start()
    {
        if (fireButton)
        {
            fireButton.onClick.AddListener(() => game.Fire());
        }
    }

    
    void Update()
    {
        powerInput.characterValidation = InputField.CharacterValidation.Integer;
        angleInput.characterValidation = InputField.CharacterValidation.Integer;
    }
}
