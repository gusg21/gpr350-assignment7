using UnityEngine;

public class AABBCollider : PhysicsCollider
{
    public Vector3 Extents => transform.localScale;
    public Vector3 HalfExtents => Extents * 0.5f;
    public Vector3 Center => transform.position;

    public Vector3 Min => Center - HalfExtents;
    public Vector3 Max => Center + HalfExtents;

    public Vector3 ClosestPoint(Vector3 pos)
    {
        var min = Min; // Don't recompute
        var max = Max;

        return new(
            Mathf.Clamp(pos.x, min.x, max.x),
            Mathf.Clamp(pos.y, min.y, max.y),
            Mathf.Clamp(pos.z, min.z, max.z)
        );
    }
}