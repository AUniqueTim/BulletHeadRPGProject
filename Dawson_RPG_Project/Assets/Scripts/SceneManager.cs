using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    //Dialogue Canvas GOs

    [SerializeField] private GameObject ductDialogueGO;
    [SerializeField] private GameObject factoryDialogueGO;

    //private void Awake()
    //{
    //    ductDialogueGO = GetComponent<GameObject>();
    //}
    private void Update()
    {
        if (ductDialogueGO != null)
        {
            if (ductDialogueGO.activeInHierarchy && Input.GetKeyDown(KeyCode.E))
            {
                LoadWorldMap();
            }
        }
        if (factoryDialogueGO != null)
        {
            if (factoryDialogueGO.activeInHierarchy && Input.GetKeyDown(KeyCode.E))
            {
                Application.LoadLevel(0);
            }
        }

    }

    public void LoadWorldMap()
    {
        Application.LoadLevel(1);
    }

}
