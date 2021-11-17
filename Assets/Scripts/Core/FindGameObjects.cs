using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UI;
using UnityEngine.UI;

public class FindGameObjects : MonoBehaviour
{
    public CreateMenu createChip;
    public PartsCounter counter;
    public ChipEditor chipEditor;

    void Start()
    {
        //GetGameObjects();
    }

    void GetGameObjects()
    {
        return;
        GameObject playerGameObj = GameObject.Find("Create");
        if (playerGameObj != null)
            createChip = playerGameObj.GetComponent<CreateMenu>();
        
    }

    void Update()
    {
        if (counter == null)
            counter = FindObjectOfType<PartsCounter>();

        if (createChip == null)
            createChip = FindObjectOfType<CreateMenu>();
        
        if (chipEditor == null)
            chipEditor = FindObjectOfType<ChipEditor> ();
    }
}