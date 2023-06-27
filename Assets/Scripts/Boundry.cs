using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundry : MonoBehaviour
{
	public Camera MainCamera;
	private Vector3 screenBounds;
	private float objectWidth;
	private float objectHeight;
	public float clampingVariable;
	private Renderer objectRenderer;

	private float screenLeftEdge;
	private float screenRightEdge;
	private float screenTopEdge;
	private float screenBottomEdge;

	// Use this for initialization
	void Start()
	{
		screenBounds = MainCamera.ViewportToWorldPoint(new Vector3(1, 1, MainCamera.transform.position.z)) - MainCamera.transform.position;
		objectRenderer = transform.GetComponent<Renderer>();
		objectWidth = objectRenderer.bounds.extents.x; //extents = size of width / 2
		objectHeight = objectRenderer.bounds.extents.y; //extents = size of height / 2
		
		//Camera mainCamera = Camera.main;
		//Vector3 screenBounds = mainCamera.ViewportToWorldPoint(new Vector3(1, 0.5f, mainCamera.transform.position.z)).x;

	}

	// Update is called once per frame
	void LateUpdate()
	{
		Vector3 viewPos = transform.position;
		viewPos.x = Mathf.Clamp(viewPos.x, -screenBounds.x + objectWidth, screenBounds.x - objectWidth);
		viewPos.y = Mathf.Clamp(viewPos.y, -screenBounds.y + objectHeight, screenBounds.y - objectHeight - clampingVariable);
		transform.position = viewPos;
	}
	private void CalculateScreenEdges()
	{
		screenLeftEdge = GetScreenLeftEdge();
		screenRightEdge = GetScreenRightEdge();
		screenTopEdge = GetScreenTopEdge();
		screenBottomEdge = GetScreenBottomEdge();
	}
	private float GetScreenLeftEdge()
	{
		return MainCamera.ViewportToWorldPoint(new Vector3(0, 0.5f, MainCamera.transform.position.z)).x;
	}

	public float GetScreenRightEdge()
	{
		return MainCamera.ViewportToWorldPoint(new Vector3(1, 0.5f, MainCamera.transform.position.z)).x;
	}

	public float GetScreenTopEdge()
	{
		return MainCamera.ViewportToWorldPoint(new Vector3(0.5f, 1, MainCamera.transform.position.z)).y;
	}

	private float GetScreenBottomEdge()
	{
		return MainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0, MainCamera.transform.position.z)).y;
	}
}
