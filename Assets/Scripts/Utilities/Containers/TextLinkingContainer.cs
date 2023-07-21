using System;
using TMPro;
using UnityEngine;
using Utilities.Interfaces;

namespace Utilities.Containers
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    [Serializable]
    public class TextLinkingContainer : LinkingBehavior
    {
        private bool EditingOpen = false;
        private TextMeshProUGUI Target;

        public override void LinkingNecessaryComponents()
        {
            if (Target == null)
                Target = GetComponentInChildren<TextMeshProUGUI>();
        }

        public override void Initialization()
        {
            base.Initialization();
            SetOpen();
        }

        public void SetText(string text)
        {
            if (EditingOpen)
                Target.text = text;
        }

        public string GetText()
        {
            return Target.text;
        }

        public void SetOpen()
        {
            EditingOpen = true;
        }

        public void SetClose()
        {
            EditingOpen = false;
        }

        public void SetActive(bool value)
        {
            if (Target.IsActive() != value)
            {
                Target.enabled = value;
            }
        }
        
        public Color GetColor()
        {
            return Target.color;
        }

        public void SetColor(Color color)
        {
            Target.color = color;
        }
    }
}