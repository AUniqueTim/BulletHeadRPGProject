using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public static DialogueManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<DialogueManager>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject();
                    singleton.AddComponent<DialogueManager>();
                    singleton.name = "(Singleton) DialogueManager";
                }
            }
            return instance;
        }
    }
    //END SINGLETON
    public TextMeshProUGUI factoryNameText;
    public TextMeshProUGUI factoryDialogueText;

    public Text interactableNameText;
    public Text interactableText;

    public Text nameText;
    public Text dialogueText;
    [SerializeField] private GameObject dialogueCanvas;

    public Dialogue m_dialogue;
    public Interactable m_Interactable;

    private Queue<string> sentences;
    bool dialogueStarted;

    private Queue<string> interactables;
    bool interactbleActivated;

    private Queue<string> factoryInteractables;
    bool factoryTriggerActivated;

    private void Awake()
    {
        instance = this;
        dialogueStarted = false;
        interactbleActivated = false;
        factoryTriggerActivated = false;
    }
    void Start()
    {
        sentences = new Queue<string>();
        interactables = new Queue<string>();
        factoryInteractables = new Queue<string>();
    }

    public void FactoryTrigger(Interactable factoryTrigger)
    {

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !factoryTriggerActivated)
        {
            if (m_Interactable.factoryTrigger != null)
            {
                StartFactoryInteractable(m_Interactable.factoryTrigger);
            }
            
            //FactoryTrigger(m_Interactable.factoryTrigger);
            factoryTriggerActivated = true;
        }
        else if(Input.GetKeyDown(KeyCode.Return) && factoryTriggerActivated)
        {
            DisplayNextFactoryInteractable();
        }

        if (Input.GetKeyDown(KeyCode.Return) && !dialogueStarted)
        {
            StartDialogue(m_Interactable.dialogue);
            dialogueStarted = true;
        }
        else if (Input.GetKeyDown(KeyCode.Return) && dialogueStarted)
        {
            DisplayNextSentence();
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            StartInteractable(m_Interactable.interactable);
        }
    }
    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Dialogue started with" + dialogue.name);
        dialogueStarted = true;
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        Debug.Log(sentence);
    }
    public void EndDialogue()
    {
        Debug.Log("Dialogue ended.");
        dialogueCanvas.SetActive(false);
        dialogueStarted = false;
    }

    public void StartInteractable(Interactable interactable)
    {
        interactbleActivated = true;
        Debug.Log(interactable);
        interactables.Clear();
        interactableNameText.text = interactable.ductDialogueName;
        interactableText.text = interactable.ductDialogue[0];
        foreach (string interact in interactable.ductDialogue)
        {
            interactables.Enqueue(interact);
        }
        DisplayNextInteractable();

        
    }
    public void DisplayNextInteractable()
    {
        if (interactables.Count == 0)
        {
            EndDialogue();
            return;
        }

        string interactable = interactables.Dequeue();
        interactableText.text = interactable;
        Debug.Log(interactable);
    }

    public void StartFactoryInteractable(Interactable factory)
    {
        if (factory != null)
        {
            factoryTriggerActivated = true;
            Debug.Log(factory);
            factoryInteractables.Clear();
            factoryNameText.text = factory.factoryDialogueName;
            factoryDialogueText.text = factory.factoryDialogue[0];
            foreach (string factoryInteractable in factory.factoryDialogue)
            {
                factoryInteractables.Enqueue(factoryInteractable);
            }
            DisplayNextFactoryInteractable();
        }
        
    }
    public void DisplayNextFactoryInteractable()
    {
        if (factoryInteractables.Count == 0)
        {
            EndDialogue();
            return;
        }
        string interactable = factoryInteractables.Dequeue();
        factoryDialogueText.text = interactable;
        Debug.Log(interactable);
    }
}
