## A tweening system like DoTween for Unity Engine

Unlike DoTween, this lets you add predicates on tween operations. 

#### Installation:
* Add an entry in your manifest.json as follows:
```C#
"com.kaiyum.ktween": "https://github.com/kaiyumcg/KTween.git"
```

Since unity does not support git dependencies, you need the following entries as well:
```C#
"com.kaiyum.attributeext" : "https://github.com/kaiyumcg/AttributeExt.git",
"com.kaiyum.unityext": "https://github.com/kaiyumcg/UnityExt.git",
"com.kaiyum.editorutil": "https://github.com/kaiyumcg/EditorUtil.git"
```
Add them into your manifest.json file in "Packages\" directory of your unity project, if they are already not in manifest.json file.

#### Usage

```
var tweener = KTween.To(() => movementSpeed, x => movementSpeed = x, movementSpeed * 2f, 2f, () => { return Input.GetMouseButton(0); });
```


So the ‘movement speed’ will be doubled within 2 seconds while the user is pressing the mouse button. Should support any Unity Engine version.

RoadMap:



* Data type support other than floats. Planned: color, vector, integer and DateTime
* Easing support
* Documentation
