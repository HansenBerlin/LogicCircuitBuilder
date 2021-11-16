using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FindGameObjects : MonoBehaviour
{
    public CreateMenu createChip;

    void Start()
    {
        GetGameObjects();
    }

    void GetGameObjects()
    {
        GameObject playerGameObj = GameObject.Find("Create");
        if (playerGameObj != null)
            createChip = playerGameObj.GetComponent<CreateMenu>();
    }

    void Update()
    {
        while (createChip == null)
            GetGameObjects();
    }
}