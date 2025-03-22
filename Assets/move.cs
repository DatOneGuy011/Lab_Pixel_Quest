using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class move : MonoBehaviour
{
    public TextMeshPro textMeshPro;
    float canJump = 5;
    public float jump = 10f;
    public float amount = 2f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro.text = "Number of Jumps: 5";
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * amount, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && canJump >= 1) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            canJump = canJump - 1;
            textMeshPro.text = "Number of Jumps: " + canJump;
        }
    }

}
