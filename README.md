## A tweening system like DoTween for Unity Engine

Unlike DoTween, this lets you add predicates on tween operations. 


```
var tweener = KTween.To(() => movementSpeed, x => movementSpeed = x, movementSpeed * 2f, 2f, () => { return Input.GetMouseButton(0); });
```


So the ‘movement speed’ will be doubled within 2 seconds while the user is pressing the mouse button. Should support any Unity Engine version.

RoadMap:



* Data type support other than floats. Planned: color, vector, integer and DateTime
* Easing support
* Documentation

Installation:


* Just copy the KTween folder into your unity project.
