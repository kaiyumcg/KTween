using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KTweener
{
    internal static class TWutil
    {
        internal static T GetNextValue<T>(T current, T start, T end, float within)
        {
            if (typeof(T) == typeof(float))
            {
                var cur = (float)(object)current;
                var st = (float)(object)start;
                var en = (float)(object)end;
                var speed = Mathf.Abs(st - en) / within;
                if (st < en)
                {
                    cur += speed * Time.deltaTime;
                    if (cur > en) { cur = en; }
                }
                else
                {
                    cur -= speed * Time.deltaTime;
                    if (cur < en) { cur = en; }
                }

                //cur = Mathf.Lerp(cur, en, speed * Time.deltaTime);
                return (T)(object)cur;
            }
            else
            {
                throw new System.NotImplementedException();
            }
        }

        internal static bool IsClose<T>(T v1, T v2)
        {
            if (typeof(T) == typeof(float))
            {
                var t1 = (float)(object)v1;
                var t2 = (float)(object)v2;
                return Mathf.Approximately(t1, t2);
            }
            else
            {
                throw new System.NotImplementedException();
            }
        }
    }
}