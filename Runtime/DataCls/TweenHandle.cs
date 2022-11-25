using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KTweener
{
    public class TweenHandle<T> : BaseTweenHandle
    {
        TwGetterFunc<T> getter = null;
        TwSetterFunc<T> setter = null;
        T endValue = default;
        T startValue = default;

        internal TweenHandle(TwGetterFunc<T> getter, TwSetterFunc<T> setter, T endValue, float within, TwPredicateFunc predicate)
        {
            this.getter = getter;
            this.setter = setter;
            this.endValue = endValue;
            this.handle = null;
            this.runner = KTween.LoadInstanceIfReq();
            this.predicate = predicate;
            this.withIn = within;
            this.completionCallback = null;
            this.isRunning = false;
            this.startValue = getter.Invoke();
        }

        public void StartTween()
        {
            var tList = KTween.Instance.tweens;
            if (tList == null) { tList = new List<BaseTweenHandle>(); }
            if (tList.Contains(this) == false)
            {
                tList.Add(this);
            }

            handle = runner.StartCoroutine(TweenerCOR());
            IEnumerator TweenerCOR()
            {
                isRunning = true;
                while (true)
                {
                    var curValue = getter.Invoke();
                    var shouldRun = true;
                    if (predicate != null)
                    {
                        shouldRun = predicate.Invoke();
                    }

                    if (shouldRun)
                    {
                        curValue = TWutil.GetNextValue(curValue, startValue, endValue, withIn);   
                        var isClose = TWutil.IsClose(curValue, endValue);
                        if (isClose)
                        {
                            completionCallback?.Invoke();
                            completionCallback = null;
                            handle = null;
                            isRunning = false;
                            break;
                        }
                    }
                    setter?.Invoke(curValue);
                    yield return null;
                }
            }
        }
    }
}