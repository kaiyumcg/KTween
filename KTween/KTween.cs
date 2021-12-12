using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KTweener
{
    public class KTween : MonoBehaviour
    {
        static KTween instance;
        internal List<BaseTweenHandle> tweens;

        private void Awake()
        {
            instance = this;
        }

        internal static KTween Instance
        {
            get
            {
                LoadInstanceIfReq();
                return instance;
            }
        }

        internal static KTween LoadInstanceIfReq()
        {
            if (instance == null)
            {
                var g = new GameObject("_TwMan");
                instance = g.AddComponent<KTween>();
                DontDestroyOnLoad(instance);
            }
            return instance;
        }

        public static TweenHandle<T> To<T>(TwGetterFunc<T> getter, TwSetterFunc<T> setter, T endValue, 
            float within, TwPredicateFunc predicate = null, bool startAutomatically = true)
        {
            LoadInstanceIfReq();
            var tw = new TweenHandle<T>(getter, setter, endValue, within, predicate);
            if (startAutomatically)
            {
                tw.StartTween();
            }
            return tw;
        }
    }
}