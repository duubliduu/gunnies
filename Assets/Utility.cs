using UnityEngine;

public static class Utility
{
    public static Vector3 GetVelocityToAngle(float angle, float speed)
    {
        float x = Mathf.Cos(angle) * speed;
        float y = Mathf.Sin(angle) * speed;

        return new Vector3(x, y);
    }

    public static float GetAngleBetween(Vector3 from, Vector3 to)
    {
        Vector3 dir = to - from;

        return Mathf.Atan2(dir.y, dir.x);
    }
}