using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Adding : MonoBehaviour
{
    public TextMeshPro textMesh; 
    public GameObject blockPrefab;

    public int value = 2;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Coin":
                {
                    DestroyImmediate(gameObject); DestroyImmediate(collision.gameObject); 
                    Adding otherBlock = collision.gameObject.GetComponent<Adding>();
                    int sum = value + otherBlock.value;
                    

                    Vector2 newPosition = (transform.position + collision.transform.position)/ 2;
                    GameObject newBlock = Instantiate(blockPrefab, newPosition, Quaternion.identity);
                    Adding newBlockScript = newBlock.GetComponent<Adding>();
                    newBlockScript.value = sum; 
                    break;
                }
            case "CoinTwo":
                {
                    
                    break; 
                }
            case "Void":
                {
                    if (value == 8)
                    {
                        Destroy(gameObject);
                    }
                    break; 
                }
        }
    }
}
