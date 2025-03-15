using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class buttonScript : MonoBehaviour
{
    public GameObject panel; 
    public void TurnOffPanel()
    {
        panel.SetActive(false);
    }
    
}
