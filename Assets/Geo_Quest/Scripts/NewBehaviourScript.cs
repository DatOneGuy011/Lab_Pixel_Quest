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
    
    public float speed = 2f;

    private float points = 0f; 

    public string Level_2 = "Stage_2";

    Rigidbody2D rb;
    void Start()
    {
        int jumps = 5;
        points = 0f; 
        rb = GetComponent<Rigidbody2D>();
        TextMeshPro.text = 'Objective: Get Coin,
            ';
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2 (xInput * speed, 0);
        
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
                    string Stage_1 = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(Stage_1);
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
