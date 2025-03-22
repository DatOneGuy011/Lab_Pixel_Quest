using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public TextMeshPro TextMeshPro;
    
    public float amount = 2f;

    private float points = 0f; 

    public string Level_2 = "Level_2";

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        TextMeshPro.text = "Objective: Get Coin";
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector2 (xInput * amount, yInput * amount);
        
        if (points >= 3f)
        {
             TextMeshPro.text = "Objective: Go Next Level";
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Death":
                {
                    points = 0f;
                    string level = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(level);
                    break;
                }
            case "Coin":
                {
                    points += 1f;
                    
                    break;
                }


            case "Finish":
                {
                    if (points >= 3f)
                    {
                        SceneManager.LoadScene(Level_2);
                    }
                    
                    break;
                }
        }
    }
}
