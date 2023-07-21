using UnityEngine;
using UnityEngine.UI;
using Utilities.Interfaces;

namespace Utilities.Containers
{
    [RequireComponent(typeof(Image))]
    public class ImageLinkingContainer : LinkingBehavior
    {
        private bool EditingOpen = false;
        private Image Target;

        public override void LinkingNecessaryComponents()
        {
            if (Target == null)
                Target = GetComponentInChildren<Image>();
        }

        public override void Initialization()
        {
            base.Initialization();
        }

        public void SetActive(bool value)
        {
            if (Target.IsActive() != value)
            {
                Target.enabled = value;
            }
        }

        public void SetPosition(Vector3 point)
        {
            Target.rectTransform.position = point;
        }
        
        public Color GetColor()
        {
            return Target.color;
        }

        public RectTransform GetRectTransform()
        {
            return Target.rectTransform;
        }

        public void SetColor(Color color)
        {
            Target.color = color;
        }

        public void SetFillAmount(float fillAmount)
        {
            Target.fillAmount = fillAmount;
        }

        public float GetFillAmount()
        {
            return Target.fillAmount;
        }

        public void SetSprite(Sprite sprite)
        {
            if(!EditingOpen) return;
            
            Target.sprite = sprite;
        }

        public void SetOpen()
        {
            EditingOpen = true;
        }

        public void SetClose()
        {
            EditingOpen = false;
        }

        public void SetAlpha(float value)
        {
            Color getColor = GetColor();
            SetColor(new Color(getColor.r, getColor.b, getColor.g, value));
        }

        public Vector2 GetSize()
        {
            return Target.rectTransform.sizeDelta;
        }

        public void SetSize(Vector2 sizeDelta)
        {
            if (!EditingOpen) return;

            Target.rectTransform.sizeDelta = sizeDelta;
        }
    }
}