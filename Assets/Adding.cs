using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adding : MonoBehaviour
{
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Coin":
                {
                    points += 1f;
                    
                    break;
                }
        }
    }
}
