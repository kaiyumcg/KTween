##A tweening system like DoTween.

Unlike DoTween, this lets you add predicates on tween operations. 


```
var tweener = KTween.To(() => movementSpeed, x => movementSpeed = x, movementSpeed * 2f, 2f, () => { return Input.GetMouseButton(0); });
```


So the ‘movement speed’ will be doubled within 2 seconds while the user is pressing the mouse button.

RoadMap:



* Data type support other than floats. Planned: color, vector, integer and DateTime
* Easing support
