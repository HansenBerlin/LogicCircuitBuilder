using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BindingManager : MonoBehaviour
{
    
    private static BindingManager _instance;
    public static BindingManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new BindingManager();
            }
            return _instance;
        }
        set
        {
            _instance = value;
        }
    }
 
    public Dictionary<string, TMP_Text> UITextBindings = new Dictionary<string, TMP_Text>();
}