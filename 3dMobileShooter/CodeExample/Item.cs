using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour {
	
	public string nameItem;
	public int id;
	public int countItem;
	public int isStackable;
	public string pathIcon;
	public string pathPrefab;
	public UnityEvent customEvent;
	[Multiline(5)]
	public string descriptionItem;

	public Sprite icon;
	[Header("Vector3 position")]
	public float positionx;
	public float positiony;
	public float positionz;
	[Header("Vector3 rotation")]
	public float rotationx;
	public float rotationy;
	public float rotationz;
	[Header("Radius")]
	public float radius;

}
