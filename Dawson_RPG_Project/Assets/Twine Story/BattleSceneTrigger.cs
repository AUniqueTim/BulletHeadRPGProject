using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cradle;
using UnityEngine.SceneManagement;

public class BattleSceneTrigger : MonoBehaviour

{
    [SerializeField] private GameObject d1;
    [SerializeField] private GameObject speechBubble;

    //public Unit enemyUnit;
    //public Unit playerUnit;
    //public Unit sideKickUnit;

    //private void Awake()
    //{
    //    enemyUnit = Toolbox.Instance.m_battleSystem.enemyUnit;
    //    playerUnit = Toolbox.Instance.m_battleSystem.playerUnit;
    //    sideKickUnit = Toolbox.Instance.m_battleSystem.sideKickUnit;
    //}


    // The following cues types are supported(replace 'passage' with the name of a passage):

    // passage_Enter() - called immediately when a passage is entered.This means after Begin, DoLink or GoTo are called and whenever a sub-passage is embedded via a macro(i.e.Twine's display macro)

    //passage_Exit() - called on the current passages just before a new main passage is entered via DoLink or GoTo. (An embedded sub-passage's exit cue is called before that of the passage which embedded it, in a last-in-first-out order.)
    // passage_Done() - called when the passage is done executing and the story has entered the Idle state.All passage output is available.
    // passage_link_Done() - called after a link's action has been completed, and before the next passage is entered (if specified). (replace 'link' with the name of a link)
    // passage_Update() - when the story is in the Idle state, this cue is called once per frame.
    // passage_Output(StoryOutput output) - whenever a passage generates output (text, links, etc.), this cue receives it.



    void Attack_Enter()
    {
        Application.LoadLevel(2);
        //SceneManager.LoadScene(2);
        
    }
    void KeepFollowingtheLight_Enter()
    {
        Application.LoadLevel(1);
    }
    void EndDialogue_Enter()
    {
        d1.SetActive(false);
        speechBubble.SetActive(false);
    }

}
