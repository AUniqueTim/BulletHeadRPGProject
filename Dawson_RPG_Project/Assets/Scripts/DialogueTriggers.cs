using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggers : MonoBehaviour
{
    public static DialogueTriggers instance;
    public static DialogueTriggers Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<DialogueTriggers>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject();
                    singleton.AddComponent<DialogueTriggers>();
                    singleton.name = "(Singleton) DialogueTriggers";
                }
            }
            return instance;
        }
    }
    //END SINGLETON
    public GameObject d1;
    public GameObject speechBubble;


    private void Awake()
    {
        instance = this;
        StartCoroutine(OpeningDialogue());
    }

    public IEnumerator OpeningDialogue()
    {
        yield return new WaitForSeconds(2f);

        if (d1 != null) { d1.SetActive(true); }
        if (speechBubble != null)
        {
            speechBubble.SetActive(true);
        }
        
    }
}
