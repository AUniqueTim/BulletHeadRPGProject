using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TwineStoryCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hP;
    [SerializeField] private TextMeshProUGUI gP;
    [SerializeField] private TextMeshProUGUI accuracy;
    [SerializeField] private TextMeshProUGUI charm;
    [SerializeField] private TextMeshProUGUI health;
    [SerializeField] private TextMeshProUGUI wealth;

    public Unit playerUnit;
    public Unit enemyUnit;

    public PlayerManager m_playerManager;

    private void Update()
    {
        hP.text = playerUnit.currentHP.ToString();
        gP.text = m_playerManager.money.ToString();
        accuracy.text = m_playerManager.accuracy.ToString();
        charm.text = m_playerManager.charm.ToString();
        health.text = m_playerManager.health.ToString();
        wealth.text = m_playerManager.wealth.ToString();
    }

    public void StartBattleScene()
    {
        Application.LoadLevel(2);
    }
}
