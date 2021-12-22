using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuctTrigger : MonoBehaviour
{
    [SerializeField] private GameObject ductDialogueCanvas;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ductDialogueCanvas.SetActive(true);
        }
        
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ductDialogueCanvas.SetActive(false); 
        }
    }
}
