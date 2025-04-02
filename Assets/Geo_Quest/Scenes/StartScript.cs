using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StartScript : MonoBehaviour
{
    public GameObject Canvas;
    // Start is called before the first frame update
     
    
    void Start()
    {
        bool CanvasActive = false;
        if (CanvasActive == false)
        {
            Canvas.SetActive(true);
            CanvasActive = true; 
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nMouseDown()
    {
        Canvas.SetActive(false);
    }
}
