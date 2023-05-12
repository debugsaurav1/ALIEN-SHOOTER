using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundry : MonoBehaviour
{
	public Camera MainCamera;
	public Vector3 screenBounds;
	public float objectWidth;
	public float objectHeight;
	private Renderer objectRenderer;

	// Use this for initialization
	void Start()
	{
		screenBounds = MainCamera.ViewportToWorldPoint(new Vector3(1, 1, MainCamera.transform.position.z)) - MainCamera.transform.position;
		objectRenderer = transform.GetComponent<Renderer>();
		objectWidth = objectRenderer.bounds.extents.x; //extents = size of width / 2
		objectHeight = objectRenderer.bounds.extents.y; //extents = size of height / 2
	}

	// Update is called once per frame
	void LateUpdate()
	{
		Vector3 viewPos = transform.position;
		viewPos.x = Mathf.Clamp(viewPos.x, -screenBounds.x + objectWidth, screenBounds.x - objectWidth);
		viewPos.y = Mathf.Clamp(viewPos.y, -screenBounds.y + objectHeight, screenBounds.y - objectHeight);
		transform.position = viewPos;
	}
}
