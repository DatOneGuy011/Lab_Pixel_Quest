using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Adding : MonoBehaviour
{

    public GameObject prefab;
    public int num = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Coin":
                {
                    Destroy(collision.gameObject);
                    gameObject.tag = "CoinTwo";
                    int newNum = collision.gameObject.GetComponent<Adding>().num;
                    transform.localScale *= 1.5f;
                    gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                    num *= newNum;
                    gameObject.GetComponentInChildren<TextMeshPro>().text = (num).ToString();

                    

                    break;
                }
            case "CoinTwo":
                {
                    
                    break; 
                }
            case "Void":
                {
                    if (num == 8)
                    {
                        Destroy(gameObject);
                    }
                    break; 
                }
        }
    }
}
