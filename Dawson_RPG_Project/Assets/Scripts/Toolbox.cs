using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbox : MonoBehaviour
{
    public static Toolbox instance;
    public static Toolbox Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Toolbox>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject();
                    singleton.AddComponent<Toolbox>();
                    singleton.name = "(Singleton) Toolbox";
                }
            }
            return instance;
        }
    }
    //END SINGLETON

    public PlayerMovement m_playerMovement;
    public PlayerManager m_playerManager;
    public EnemyManager m_enemyManager;
    public BattleCanvasUI m_battleCanvas;
    public DialogueManager m_dialogueManager;
    public DialogueTriggers m_dialogueTriggers;
    public Interactable m_Interactable;
    public SceneManager m_sceneManager;
    public BattleSystem m_battleSystem;
    public Unit m_Unit;
    public Enemy m_Enemy;

    private void Awake()
    {
        instance = this;
    }
}
