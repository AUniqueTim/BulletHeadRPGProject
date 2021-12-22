using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Interactable : MonoBehaviour
{
    
    public DialogueManager m_DialogueManager;
    public Dialogue dialogue;
    public Interactable interactable;
    public Interactable factoryTrigger;

    public string[] ductDialogue;
    public string ductDialogueName;

    public string[] factoryDialogue;
    public string factoryDialogueName;

    public static Interactable instance;
    public static Interactable Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Interactable>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject();
                    singleton.AddComponent<Interactable>();
                    singleton.name = "(Singleton) Interactable";
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public void TriggerDialogue()
    {
        m_DialogueManager.StartDialogue(dialogue);
    }
    public void TriggerInteractable()
    {
        m_DialogueManager.StartInteractable(interactable);
    }
    public void TriggerFactory()
    {
        m_DialogueManager.StartFactoryInteractable(factoryTrigger);
    }
}
