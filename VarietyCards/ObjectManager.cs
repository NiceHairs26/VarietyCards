using System;
using UnityEngine;

namespace VarietyCards
{
	// Token: 0x02000003 RID: 3
	public static class ObjectManager
	{
		// Token: 0x06000007 RID: 7 RVA: 0x00002220 File Offset: 0x00000420
		private static Mesh CreateMesh()
		{
			Vector3[] vertices = new Vector3[]
			{
				new Vector3(-0.5f, -0.5f, 0f),
				new Vector3(0.5f, -0.5f, 0f),
				new Vector3(0f, 0.5f, 0f)
			};
			Vector2[] uv = new Vector2[]
			{
				new Vector2(0f, 0f),
				new Vector2(1f, 0f),
				new Vector2(0.5f, 1f)
			};
			int[] triangles = new int[]
			{
				0,
				1,
				2
			};
			Mesh mesh = new Mesh();
			mesh.vertices = vertices;
			mesh.uv = uv;
			mesh.triangles = triangles;
			mesh.RecalculateBounds();
			mesh.RecalculateNormals();
			mesh.RecalculateTangents();
			return mesh;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002318 File Offset: 0x00000518
		public static GameObject CreateObject(string name, Color color)
		{
			Mesh sharedMesh = ObjectManager.CreateMesh();
			GameObject gameObject = new GameObject(name);
			MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
			meshFilter.sharedMesh = sharedMesh;
			MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
			meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
			meshRenderer.sharedMaterial.color = color;
			meshRenderer.sharedMaterial.EnableKeyword("_EMISSION");
			meshRenderer.sharedMaterial.SetColor("_EmissionColor", color * 1f);
			return gameObject;
		}
	}
}
