using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogues : MonoBehaviour
{
    [SerializeField] private GameObject openingDialogue;
    [SerializeField] private GameObject factoryDialogue;
    public FactoryTrigger m_factoryTrigger;
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            openingDialogue.SetActive(true);
        }

    }
}
