using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 2f;


    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float yInput = Input.GetAxis("Vertical"); 
        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * Speed, yInput * Speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Death":
                {
                    string level = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(level);
                    break;
                }   
        }
    }
}
