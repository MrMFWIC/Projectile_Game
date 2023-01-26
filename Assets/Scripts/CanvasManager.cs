using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Gameplay))]
public class CanvasManager : MonoBehaviour
{
    Gameplay game;

    public InputField powerInput;
    public InputField angleInput;
    public Button fireButton;

    void Start()
    {
        game = GetComponent<Gameplay>();

        if (fireButton)
        {
            fireButton.onClick.AddListener(() => game.player.TriggerFire());
        }
    }

    void Update()
    {
       
    }
}