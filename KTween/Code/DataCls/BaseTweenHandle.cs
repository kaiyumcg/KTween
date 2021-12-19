using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KTweener
{
    public class BaseTweenHandle
    {
        private protected Coroutine handle = null;
        private protected KTween runner = null;
        private protected TwPredicateFunc predicate = null;
        private protected float withIn = 0.0f;
        private protected TwCallbackFunc completionCallback = null;
        TwCallbackFunc stopCallback = null;
        private protected bool isRunning;
        internal BaseTweenHandle() { }

        public bool IsValid { get { return handle != null && isRunning; } }
        public bool IsPlaying() { return isRunning; }

        public void Kill()
        {
            runner.StopCoroutine(handle);
            var tList = KTween.Instance.tweens;
            if (tList == null) { tList = new List<BaseTweenHandle>(); }
            if (tList.Contains(this))
            {
                tList.Remove(this);
            }
            this.stopCallback?.Invoke();
            this.stopCallback = null;
            isRunning = false;
            handle = null;
        }

        public void OnComplete(TwCallbackFunc callback)
        {
            this.completionCallback += callback;
        }

        public void OnStop(TwCallbackFunc callback)
        {
            this.stopCallback += callback;
        }
    }
}