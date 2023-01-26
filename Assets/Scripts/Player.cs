using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField]Gameplay game;
    [SerializeField]CanvasManager cm;
    Animator anim;
    SpriteRenderer sr;
    SceneManager sm;

    public int powerInputValue;
    public int angleInputValue;

    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }

    public void TriggerFire()
    {
        anim.SetTrigger("Fire");
    }

    public void SpawnProjectile()
    {
        powerInputValue = int.Parse(cm.powerInput.text);
        angleInputValue = int.Parse(cm.angleInput.text);
        game.Fire(powerInputValue, angleInputValue);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            anim.SetTrigger("Death");
        }
    }

    public void GameOver()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("Scenes/SampleScene");
    }
}
