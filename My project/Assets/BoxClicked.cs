using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxClicked : MonoBehaviour
{

    /// <summary>
    /// Called every frame while the mouse is over the GUIElement or Collider.
    /// </summary>
    void OnMouseOver()
    {
        if(Input.GetMouseButtonUp(0)){
            Debug.Log(gameObject.name + gameObject.transform.parent.gameObject.name);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
