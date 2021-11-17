using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class TopBarController : MonoBehaviour
    {
        public PartsCounter counter;
        public TMP_Text partsCurrentCountUi;
        public TMP_Text partsMaxAllowedUi;
        public int partsMaxAllowed;

        private void Update()
        {
            if (counter == null)
                counter = FindObjectOfType<PartsCounter>();

            if (counter != null)
                partsCurrentCountUi.text = counter.count.ToString();
        }

        private void Start()
        {
            partsMaxAllowedUi.text = partsMaxAllowed.ToString();
        }
    }
}