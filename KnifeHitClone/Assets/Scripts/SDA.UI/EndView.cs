using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SDA.UI
{
    public class EndView : BaseView
    {
        [SerializeField]
        private Button backEndButton;

        public Button PlayButton => backEndButton;
    }
}