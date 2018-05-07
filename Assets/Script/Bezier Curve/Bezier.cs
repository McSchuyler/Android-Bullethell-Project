using UnityEngine;

public class Bezier : MonoBehaviour {

	public static Vector2 GetPoint(Vector2 p1, Vector2 p2, Vector2 p3, float t)
    {
        //use equation instead of nested lerp
        t = Mathf.Clamp01(t);
        float oneMinusT = 1 - t;
        return
            oneMinusT * oneMinusT * p1 +
            2f * oneMinusT * t * p2 +
            t * t * p3;

        //this also return the same result
        //return Vector2.Lerp(Vector2.Lerp(p1,p2,t),Vector2.Lerp(p2,p3,t),t);
    }

    public static Vector2 GetFirstDerivative(Vector2 p1, Vector2 p2, Vector2 p3, float t)
    {
        return
            2f * (1f - t) * (p2 - p1) +
            2f * t * (p3 - p2);
    }

    public static Vector2 GetPoint(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, float t)
    {
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return
            oneMinusT * oneMinusT * oneMinusT * p0 +
            3f * oneMinusT * oneMinusT * t * p1 +
            3f * oneMinusT * t * t * p2 +
            t * t * t * p3;
    }

    public static Vector2 GetFirstDerivative(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, float t)
    {
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return
            3f * oneMinusT * oneMinusT * (p1 - p0) +
            6f * oneMinusT * t * (p2 - p1) +
            3f * t * t * (p3 - p2);
    }
}
