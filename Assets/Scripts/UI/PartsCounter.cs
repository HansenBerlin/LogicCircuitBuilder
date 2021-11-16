using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsCounter : MonoBehaviour
{
    public int count;

    public void CountParts()
    {
        Debug.Log("Count");
        foreach(Transform child in transform)
        {
            count = 0;
            if (child.tag == "CountPart")
                count++;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
