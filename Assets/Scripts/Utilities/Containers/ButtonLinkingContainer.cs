using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utilities.Interfaces;

namespace Utilities.Containers
{
    [RequireComponent(typeof(Button))]
    public class ButtonLinkingContainer : LinkingBehavior
    {
        private protected bool LockLatch = false;
        
        private Button Target;

        public UnityEvent OnClick = new UnityEvent();

        public override void LinkingNecessaryComponents()
        {
            if (Target == null)
                Target = GetComponentInChildren<Button>();
        }

        public override void Initialization()
        {
            base.Initialization();
            Target.onClick.AddListener(OnClickEvent);

        }

        private void OnClickEvent()
        {
            if (LockLatch) return;

            OnClick.Invoke();
        }

        private protected virtual void OnDestroy()
        {
            if(Target == null) return;
            Target.onClick.RemoveListener(OnClickEvent);
        }

        public virtual void Lock()
        {
            LockLatch = true;
        }

        public virtual void Unlock()
        {
            LockLatch = false;
        }
    }
}