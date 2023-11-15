using System.Collections;
using System.Collections.Generic;
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
		// TODO : implement
	}
}
