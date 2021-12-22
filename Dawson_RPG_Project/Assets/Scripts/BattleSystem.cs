using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;



public enum BattleState { START, PLAYERTURN, ENEMYTURN, PLAYERWON, PLAYERLOST, SIDEKICKTURN}
public class BattleSystem : MonoBehaviour
{

    public BattleState battleState;

    public GameObject playerPrefab;
    public GameObject sideKickPrefab;
    public GameObject[] enemyPrefab;
    [SerializeField] private GameObject returnToWorldMapButton;

    public Transform playerPos;
    public Transform enemyPos;
    public Transform sideKickPos;

    public BattleCanvasUI playerHUD;
    public BattleCanvasUI enemyHUD;
    public BattleCanvasUI sideKickHUD;

    public Unit playerUnit;
    public Unit enemyUnit;
    public Unit sideKickUnit;

    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI playerText;
    public TextMeshProUGUI enemyText;

    public TMP_Dropdown attackDropdown;
    public TMP_Dropdown drinkDropdown;
    public TMP_Dropdown charmDropdown;

    public bool intimidate;
    public bool persuade;
    public bool seduce;

    public int ammo;
    public int grenades;

    public string weapon;
    public string armor;
    public string gadget;

    public int bulletDamage;
    public int grenadeDamage;
    public int meleeDamage;

    public bool wasSideKickTurn;
    public bool wasPlayerTurn;
    

    private void Start()
    {
        battleState = BattleState.START;
        StartCoroutine(StartCombat());
    }
    public void Update()
    {
        //ATTACK DROPDOWN

        if (attackDropdown.options[attackDropdown.value].text == "BULLET!")
        {
            ammo -= 1;
            playerUnit.damage += playerUnit.damage + bulletDamage;
        }
        if (attackDropdown.options[attackDropdown.value].text == "GRENADE!")
        {
            grenades -= 1; ;
            playerUnit.damage += playerUnit.damage + grenadeDamage;

        }
        if (attackDropdown.options[attackDropdown.value].text == "MELEE!")
        {
            playerUnit.damage += playerUnit.damage + meleeDamage;
        }

        //DRINK DROPDOWN

        if (drinkDropdown.options[drinkDropdown.value].text == "BEER!")
        {
            Toolbox.Instance.m_playerManager.beer = true;
        }
        if (drinkDropdown.options[drinkDropdown.value].text == "WINE!")
        {
            Toolbox.Instance.m_playerManager.wine = true;
        }
        if (drinkDropdown.options[drinkDropdown.value].text == "SPIRITS!")
        {
            Toolbox.Instance.m_playerManager.spirits = true;
        }

        //CHARM DROPDOWN

        if (charmDropdown.options[charmDropdown.value].text == "SEDUCE!")
        {
            seduce = true;
        }
        if (charmDropdown.options[charmDropdown.value].text == "INTIMIDATE!")
        {
            intimidate = true;
        }
        if (charmDropdown.options[charmDropdown.value].text == "PERSUADE!")
        {
            persuade = true;
        }
    }

    IEnumerator StartCombat()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerPos);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(Toolbox.Instance.m_enemyManager.enemyClone, enemyPos);
        enemyUnit = enemyGO.GetComponent<Unit>();

        GameObject sideKickGO = Instantiate(sideKickPrefab, sideKickPos);
        sideKickUnit = sideKickGO.GetComponent<Unit>();

        if (enemyUnit != null)
        {
            dialogueText.text = "You were attacked by a " + enemyUnit.tag + "!";
        }
        

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        battleState = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    public IEnumerator SideKickTurn()
    {
        dialogueText.text = "Waiting for Sidekick...";
        yield return new WaitForSeconds(2f);
        
        battleState = BattleState.SIDEKICKTURN;

        StartCoroutine(Toolbox.Instance.m_playerManager.SideKickAttack());

        yield return new WaitForSeconds(2f);

        wasSideKickTurn = true;
        wasPlayerTurn = false;




    }
    public void PlayerTurn()
    {
        dialogueText.text = "Waiting for action...";
        battleState = BattleState.PLAYERTURN;

        seduce = false;
        persuade = false;
        intimidate = false;

        wasPlayerTurn = true;
        wasSideKickTurn = false;
    }
    public void AttackButton()
    {
        if (battleState != BattleState.PLAYERTURN)
        {
            return;
        }
        StartCoroutine(Toolbox.Instance.m_playerManager.PlayerAttack());

    }
    public void DrinkButton()
    {
        if (battleState != BattleState.PLAYERTURN)
        {
            return;
        }
        StartCoroutine(Toolbox.Instance.m_playerManager.DrinkBeer());
    }
    public void CharmButton()
    {
        if (battleState != BattleState.PLAYERTURN)
        {
            return;
        }
        StartCoroutine(Toolbox.Instance.m_playerManager.SayLine());
    }
    public void BribeButton()
    {
        if (battleState != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(Toolbox.Instance.m_playerManager.Bribe());
    }
    public void ReturnToWorldMap()
    {
        Application.LoadLevel(0);
    }
    public void EndBattle()
    {
        if (battleState == BattleState.PLAYERWON)
        {
            dialogueText.text = "Battle won!!! Congratulations!";
            PlayerWon();
        }
        else if (battleState == BattleState.PLAYERLOST)
        {
            dialogueText.text = "Battle lost!!! :( Unfortunate!";
            PlayerLost();
        }

        //Apply XP Gain
        //Display XP Gain
        
        returnToWorldMapButton.SetActive(true); //Return to World Map
        //Application.LoadLevel(0);
    }

    public IEnumerator EnemyTurn()
    {
        //if (wasSideKickTurn) { battleState = BattleState.PLAYERTURN; PlayerTurn(); }
        //else if (wasPlayerTurn) { battleState = BattleState.ENEMYTURN; EnemyTurn(); }
        Debug.Log("Enemy Turn started.");

        dialogueText.text = "The " + enemyUnit.tag + " moves suddenly towards you.";

        yield return new WaitForSeconds(2f);

        //Apply Damage to Player
        int[] damageModifier = new int[] { 1,10 };
        Toolbox.Instance.m_enemyManager.enemyDamageModifier = damageModifier[Random.Range(0, damageModifier.Length)];
        enemyUnit.damage += Toolbox.Instance.m_enemyManager.enemyDamageModifier;
        playerText.text = "Player took " + enemyUnit.damage + " damage!";
        bool isDead  = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(2f);

        //wasPlayerTurn = false;

        if (isDead)
        {
            battleState = BattleState.PLAYERLOST;
            EndBattle();
        }
        else if (wasPlayerTurn) { battleState = BattleState.SIDEKICKTURN; StartCoroutine(SideKickTurn()); }

        else { battleState = BattleState.PLAYERTURN; PlayerTurn(); }

        yield return new WaitForSeconds(2f);

        wasPlayerTurn = false;
        wasSideKickTurn = false;



    }
    public void PlayerWon()
    {

    }
    public void PlayerLost()
    {

    }
}
