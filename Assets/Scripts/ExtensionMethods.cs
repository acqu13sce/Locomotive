using UnityEngine;
using System.Collections;

public static class ExtensionMethods {
	public static Vector2 toVector2(this Vector3 v){
		return new Vector2(v.x, v.y);
	}
}
