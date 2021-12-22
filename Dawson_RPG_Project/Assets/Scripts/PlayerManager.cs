using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    //Sidekick

    public int sideKickDamage;

    //Unit References

    public Unit playerUnit;
    public Unit enemyUnit;
    public Unit sideKickUnit;

    //Player/Enemy GOs
    [SerializeField] private GameObject bulletHead;
    [SerializeField] private GameObject sideKick;

    //Player Health/Lives Stats
    [SerializeField] private int playerLives;
    [SerializeField] private int bulletHeadHP;
   

    //PlayerStats
    public int accuracy;
    public int charm;
    public int health;
    public int wealth;

    //PLayer $$$ 
    public int money;

    //INVENTORY
    [SerializeField] private int ammo;
    [SerializeField] private string weapon;
    [SerializeField] private string armor;
    [SerializeField] private GameObject potion;


    //Player Charm Lines
    
    [SerializeField] private string[] lines;
    [SerializeField] private string[] seduceLines;
    [SerializeField] private string[] intimidateLines;
    [SerializeField] private int insultDamageModifier;

    //Drinks

    public bool beer;
    public bool wine;
    public bool spirits;

    public int beerPotionHP;
    public int winePotionHP;
    public int spiritsPotionHP;

    //Bribe

    public GameObject inputField; // Bribe Input Field.
    bool bribeWorked;

    private void Awake()
    {
        if (enemyUnit != null)
        {
            enemyUnit = Toolbox.Instance.m_battleSystem.enemyUnit;
        }
        if (playerUnit != null)
        {
            playerUnit = Toolbox.Instance.m_battleSystem.playerUnit;
            bulletHeadHP = playerUnit.currentHP;

            DontDestroyOnLoad(this.gameObject);
        }
        
       

        //Charm Lines

        lines = new[] { "You sir, are not fit for civilized discourse! I say good day to you!",
                        "A pox upon thy name, nave!",
                        "Poppycock, Balderdrash, and Shenanagins! Enough of your Tomfoolery!",
                        };

        seduceLines = new[]
        {
                        "My, you're look curiously handsome at the moment.",
                        "I say, good citizen, thine appeareance doth radiate elegence.",
                        "Hello there, Goodlooking. I'd like to buy you breakfast tomorrow. Rrawr."
        };

        intimidateLines = new[]
        {
                        "One step closer and you'll regret it.",
                        "Don't make me put you on the ground face down.",
                        "I'm gonna make a rug out of you!"
        };
    }
    void Update()
    {
     
    }
    public IEnumerator SideKickAttack()
    {
        yield return new WaitForSeconds(2f);

        Toolbox.Instance.m_battleSystem.sideKickUnit.damage = sideKickDamage;

        bool isDead = Toolbox.Instance.m_battleSystem.enemyUnit.TakeDamage(Toolbox.Instance.m_battleSystem.sideKickUnit.damage);

        Toolbox.Instance.m_battleSystem.enemyHUD.SetHP(Toolbox.Instance.m_battleSystem.enemyUnit.currentHP);

        Toolbox.Instance.m_battleSystem.dialogueText.text = "Sidekick Attacked the " + Toolbox.Instance.m_battleSystem.enemyUnit.tag + "!";

        yield return new WaitForSeconds(2f);
        Toolbox.Instance.m_battleSystem.enemyText.text = "Enemy took " + Toolbox.Instance.m_battleSystem.sideKickUnit.damage + " damage!";
        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            Toolbox.Instance.m_battleSystem.battleState = BattleState.PLAYERWON;
            Toolbox.Instance.m_battleSystem.EndBattle();
        }
        else
        {
            if (Toolbox.Instance.m_battleSystem.wasPlayerTurn) { Toolbox.Instance.m_battleSystem.battleState = BattleState.ENEMYTURN; StartCoroutine(Toolbox.Instance.m_battleSystem.EnemyTurn()); }
            else if (Toolbox.Instance.m_battleSystem.wasSideKickTurn) { Toolbox.Instance.m_battleSystem.battleState = BattleState.PLAYERTURN; Toolbox.Instance.m_battleSystem.PlayerTurn(); }
        }
    }



    public IEnumerator PlayerAttack()
    {
        

        yield return new WaitForSeconds(2f);

        //If Enemy Alive...
        if (Toolbox.Instance.m_battleSystem.enemyUnit != null)
        {
            bool isDead = Toolbox.Instance.m_battleSystem.enemyUnit.TakeDamage(Toolbox.Instance.m_battleSystem.playerUnit.damage); //Apply Damage to Enemy

            Toolbox.Instance.m_battleSystem.enemyHUD.SetHP(Toolbox.Instance.m_battleSystem.enemyUnit.currentHP); //Update UI

            Toolbox.Instance.m_battleSystem.dialogueText.text = "Player Attacked the " + Toolbox.Instance.m_battleSystem.enemyUnit.tag + "!";
            yield return new WaitForSeconds(2f);
            Toolbox.Instance.m_battleSystem.enemyText.text = "Enemy took " + Toolbox.Instance.m_battleSystem.playerUnit.damage + " damage!";
            yield return new WaitForSeconds(2f);

            //Change battleState to..

            if (isDead)
            {
                Toolbox.Instance.m_battleSystem.battleState = BattleState.PLAYERWON;
                Toolbox.Instance.m_battleSystem.EndBattle();
            }
            else
            {
                //Enemy Turn
                Toolbox.Instance.m_battleSystem.battleState = BattleState.ENEMYTURN;
                StartCoroutine(Toolbox.Instance.m_battleSystem.EnemyTurn());

                //Sidekickturn
                //Toolbox.Instance.m_battleSystem.battleState = BattleState.SIDEKICKTURN;
                //StartCoroutine(Toolbox.Instance.m_battleSystem.Enemy2Turn();
            }

            Debug.Log("Player Attacked.");
        }

       

    }

    public IEnumerator DrinkBeer()
    {
        yield return new WaitForSeconds(2f);
        if (beer) { Toolbox.Instance.m_battleSystem.playerUnit.currentHP += beerPotionHP; Toolbox.Instance.m_battleSystem.playerText.text = "Player drank a beer and recovered " + beerPotionHP + " health."; }
        else if (wine) { Toolbox.Instance.m_battleSystem.playerUnit.currentHP += winePotionHP; Toolbox.Instance.m_battleSystem.playerText.text = "Player drank some and recovered " + winePotionHP + " health."; }
        else if (spirits) { Toolbox.Instance.m_battleSystem.playerUnit.currentHP += spiritsPotionHP; Toolbox.Instance.m_battleSystem.playerText.text = "Player drank spirits and recovered " + spiritsPotionHP + " health."; }
        Toolbox.Instance.m_battleSystem.playerHUD.SetHP(Toolbox.Instance.m_battleSystem.playerUnit.currentHP);
        
        Debug.Log("Player Drank.");

        Toolbox.Instance.m_battleSystem.battleState = BattleState.ENEMYTURN;
        StartCoroutine(Toolbox.Instance.m_battleSystem.EnemyTurn());

        //Sidekickturn
    }

    public IEnumerator SayLine()
    {
        yield return new WaitForSeconds(1.5f);
        if (Toolbox.Instance.m_battleSystem.intimidate)
        {
            Toolbox.Instance.m_battleSystem.playerText.text = intimidateLines[Random.Range(0, intimidateLines.Length)];
            yield return new WaitForSeconds(3);
        }
        
        if (Toolbox.Instance.m_battleSystem.persuade)
        {
            Toolbox.Instance.m_battleSystem.playerText.text = lines[Random.Range(0, lines.Length)];
            yield return new WaitForSeconds(3);

        }
        if (Toolbox.Instance.m_battleSystem.seduce)
        {
            Toolbox.Instance.m_battleSystem.playerText.text = seduceLines[Random.Range(0, seduceLines.Length)];
            yield return new WaitForSeconds(3);

        }

        //yield return new WaitForSeconds(3.5f);

        Toolbox.Instance.m_battleSystem.playerUnit.damage *= insultDamageModifier;

        if (Toolbox.Instance.m_battleSystem.enemyUnit != null)
        {
            bool isDead = Toolbox.Instance.m_battleSystem.enemyUnit.TakeDamage(Toolbox.Instance.m_battleSystem.playerUnit.damage);

            if (isDead)
            {
                Toolbox.Instance.m_battleSystem.battleState = BattleState.PLAYERWON;
                Toolbox.Instance.m_battleSystem.EndBattle();
            }
            else
            {
                //Enemy Turn
                Toolbox.Instance.m_battleSystem.battleState = BattleState.ENEMYTURN;
                StartCoroutine(Toolbox.Instance.m_battleSystem.EnemyTurn());

                //Sidekickturn
            }

            Toolbox.Instance.m_battleSystem.enemyHUD.SetHP(Toolbox.Instance.m_battleSystem.enemyUnit.currentHP);

            Toolbox.Instance.m_battleSystem.battleState = BattleState.ENEMYTURN;
            StartCoroutine(Toolbox.Instance.m_battleSystem.EnemyTurn());
        }

            

        


  
    }

    public IEnumerator Bribe()
    {

        yield return new WaitForSeconds(2f);

        Debug.Log("Bribe button pressed.");

        string bribeText = inputField.GetComponent<TMP_InputField>().text;

        yield return new WaitForSeconds(2f);

        if (Toolbox.Instance.m_battleSystem.enemyUnit != null)
        {
            Toolbox.Instance.m_battleSystem.playerText.text = "You offered the " + Toolbox.Instance.m_battleSystem.enemyUnit.tag + bribeText + " dollars.";

            yield return new WaitForSeconds(2f);

            int bribeChance = Random.Range(0, 5);
            if (bribeChance == 1) { bribeWorked = true; }
            else { bribeWorked = false; }

            if (bribeWorked)
            {
                Toolbox.Instance.m_battleSystem.dialogueText.text = "The bribe worked! The " + Toolbox.Instance.m_battleSystem.enemyUnit.tag + " slinks off, counting your money.";

                yield return new WaitForSeconds(2f);

                Toolbox.Instance.m_battleSystem.playerUnit.damage = 1000;
                Toolbox.Instance.m_battleSystem.enemyUnit.TakeDamage(Toolbox.Instance.m_battleSystem.playerUnit.damage);
                Toolbox.Instance.m_battleSystem.enemyHUD.SetHP(Toolbox.Instance.m_battleSystem.enemyUnit.currentHP);
                Toolbox.Instance.m_battleSystem.battleState = BattleState.PLAYERWON;
                Toolbox.Instance.m_battleSystem.EndBattle();

            }
            else if (!bribeWorked)
            {
                Toolbox.Instance.m_battleSystem.dialogueText.text = "The " + Toolbox.Instance.m_battleSystem.enemyUnit.tag + " scoffs at your offer and lunges at you!";
                yield return new WaitForSeconds(2f);
                Toolbox.Instance.m_battleSystem.battleState = BattleState.ENEMYTURN;
                StartCoroutine(Toolbox.Instance.m_battleSystem.EnemyTurn());
            }
        }

        
        
    }

}
