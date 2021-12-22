using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cradle;
using UnityEngine.SceneManagement;

public class TwineScene02Trigger : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Application.LoadLevel(3);
        }
    }
}
