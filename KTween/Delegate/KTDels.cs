using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KTweener
{
    public delegate void TwCallbackFunc();
    public delegate bool TwPredicateFunc();
    public delegate T TwGetterFunc<T>();
    public delegate void TwSetterFunc<T>(T val);
}