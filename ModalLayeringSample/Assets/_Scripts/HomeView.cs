﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CodeSampleModalLayer
{
    [RequireComponent(typeof(ScrollingBackground))]
    public class HomeView : MonoBehaviour
    {
        [SerializeField]
        private Button button;

        private AppManager appMan = default;
        private ScrollingBackground scrollBackground = default;

        public void Setup()
        {
            appMan = AppManager.Instance;
            scrollBackground = GetComponent<ScrollingBackground>();

            if(scrollBackground != null)
            {
                scrollBackground.Initialize();
            }

            button.onClick.AddListener(CreateInfoModal);
        }

        public void CreateInfoModal()
        {
            InfoModalTemplate m = Instantiate(appMan.InfoModalTemplatePrefab, appMan.DialogParent);
            m.Setup(descText: "This is modal layer: {0}");
        }

        public void Shutdown()
        {
            button.onClick.RemoveAllListeners();
            scrollBackground.Shutdown();
        }
    }
}