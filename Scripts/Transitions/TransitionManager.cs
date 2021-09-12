using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace BumpySellotape.Core.Transitions
{
    [RequireComponent(typeof(Animator))]
    public class TransitionManager : MonoBehaviour
    {
        private Animator animator;
        private Action loadContentAction;
        private Action clearContentAction;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        [Button]
        public void DoTransition(TransitionProperties transitionProperties, Action loadContentAction, Action clearContentAction)
        {
            this.loadContentAction = loadContentAction;
            this.clearContentAction = clearContentAction;
            animator.Play("Black Out");
        }

        public void OnSafeToClearOldContent()
        {
            clearContentAction?.Invoke();
        }

        public void OnSafeToLoadNewContent()
        {
            loadContentAction?.Invoke();
        }
    }
}
