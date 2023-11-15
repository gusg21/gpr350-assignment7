using UnityEngine;

public class OBBCollider : PhysicsCollider
{
	public Vector3 Extents => transform.localScale;
	public Vector3 HalfExtents => Extents * 0.5f;
	public Vector3 Center => transform.position;

	public Vector3 AxisX => transform.right;
	public Vector3 AxisY => transform.up;
	public Vector3 AxisZ => transform.forward;

	public Vector3 ClosestPoint(Vector3 pos)
	{
		Vector3 difference = pos - Center;

		float dotU = Vector3.Dot(difference, AxisX);
		float dotV = Vector3.Dot(difference, AxisY);
		float dotW = Vector3.Dot(difference, AxisZ);

		float u = Mathf.Clamp(dotU, -HalfExtents.x, HalfExtents.x);
		float v = Mathf.Clamp(dotV, -HalfExtents.y, HalfExtents.y);
		float w = Mathf.Clamp(dotW, -HalfExtents.z, HalfExtents.z);

		Vector3 closest = AxisX * u + AxisY * v + AxisZ * w;

		return closest + Center;
	}
}
