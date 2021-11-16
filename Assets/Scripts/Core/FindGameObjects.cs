using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FindGameObjects : MonoBehaviour
{
    public CreateMenu createChip;
    public PartsCounter chipCounter;
    public PartsCounter wireCounter;
    
    void Start()
    {
        GetGameObjects();
    }

    void GetGameObjects()
    {
        GameObject playerGameObj = GameObject.Find("Create");
        if (playerGameObj != null)
            createChip = playerGameObj.GetComponent<CreateMenu>();
        playerGameObj = GameObject.Find("Chips");
        if (playerGameObj != null)
            chipCounter = playerGameObj.GetComponent<PartsCounter>();
        playerGameObj = GameObject.Find("Wires");
        if (playerGameObj != null)
            wireCounter = playerGameObj.GetComponent<PartsCounter>();
    }

    void Update()
    {
        while (createChip == null)
            GetGameObjects();
    }
}