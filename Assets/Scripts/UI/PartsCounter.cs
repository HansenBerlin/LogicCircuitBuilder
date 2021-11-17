using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class PartsCounter : MonoBehaviour
    {
        public int count;
        public string searchTag = "CountPart";

        void Start()
        {
            if (searchTag != null)
            {
                FindObjectwithTag(searchTag);
            }
        }

        public void CountParts()
        {
            FindObjectwithTag(searchTag);
        }
 
        public void FindObjectwithTag(string _tag)
        {
            count = 0;
            Transform parent = transform;
            GetChildObject(parent, _tag);
        }
 
        public void GetChildObject(Transform parent, string _tag)
        {
            for (int i = 0; i < parent.childCount; i++)
            {
                Transform child = parent.GetChild(i);
                if (child.tag == _tag)
                {
                    count++;
                    Debug.Log("added, now is: " + count);
                }
                if (child.childCount > 0)
                {
                    GetChildObject(child, _tag);
                }
            }
        }
    }
}