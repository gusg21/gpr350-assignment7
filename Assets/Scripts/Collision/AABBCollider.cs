using Codice.Client.BaseCommands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AABBCollider : PhysicsCollider
{
	public Vector3 Extents => transform.localScale;
	public Vector3 HalfExtents => Extents * 0.5f;
	public Vector3 Center => transform.position;

	public Vector3 Min => // TODO : implement
	public Vector3 Max => // TODO : implement

	public Vector3 ClosestPoint(Vector3 pos)
	{
		// TODO : implement
	}
}
