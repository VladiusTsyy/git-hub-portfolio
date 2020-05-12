using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Tooltype : MonoBehaviour,IPointerClickHandler {
	Inventory inventory;
	public int tooltypeswitch = 0;
	public GameObject buttonEq0;
	public GameObject buttonEq1;
	public GameObject buttonEq2;
	public GameObject buttonEq3;
	public GameObject buttonEq4;
	public GameObject buttonEq5;
	public GameObject buttonEq6;
	public GameObject buttonEq7;
	public int index;
	public GameObject gameManager;
	AmmoManager ammomanagerscr;
	public Text ammotext;
	int ammomanagerArsenal; 
	

	// Use this for initialization
	void Start () 
	{
		ammomanagerscr = gameManager.GetComponent<AmmoManager>();
		buttonEq0.SetActive(false);
		buttonEq1.SetActive(false);
		buttonEq2.SetActive(false);
		buttonEq3.SetActive(false);
		buttonEq4.SetActive(false);
		buttonEq5.SetActive(false);
		buttonEq6.SetActive(false);
		buttonEq7.SetActive(false);
		inventory = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	public void OnPointerClick(PointerEventData pointerEventData)
	{
		buttonManager();
		tooltypeswitch +=1;
		CurentItem currentItem = GetComponent<CurentItem>();
		Item item = inventory.item[currentItem.Index];
		if(tooltypeswitch == 1 && item != null)
		{
			ammotext.enabled = false;
			inventory.tooltypeObj.SetActive(true);
			inventory.icon.sprite = item.icon;
			inventory.itemName.text = item.nameItem;
			inventory.description.text = item.descriptionItem;
			if(item.id == 3)
			{
				ammotext.enabled = true;
				inventory.tooltypeObj.SetActive(true);
				inventory.icon.sprite = item.icon;
				inventory.itemName.text = item.nameItem;
				inventory.description.text = item.descriptionItem;
				ammomanagerArsenal = ammomanagerscr.ArsenalShotgun1mr;
				ammotext.text ="Ammo  "+ ammomanagerArsenal.ToString();
			}
			if(item.id == 4)
			{
				ammotext.enabled = true;
				inventory.tooltypeObj.SetActive(true);
				inventory.icon.sprite = item.icon;
				inventory.itemName.text = item.nameItem;
				inventory.description.text = item.descriptionItem;
				ammomanagerArsenal = ammomanagerscr.ArsenalPistol1mr;
				ammotext.text ="Ammo  "+ ammomanagerArsenal.ToString();
			}
			if(item.id == 5)
			{
				ammotext.enabled = true;
				inventory.tooltypeObj.SetActive(true);
				inventory.icon.sprite = item.icon;
				inventory.itemName.text = item.nameItem;
				inventory.description.text = item.descriptionItem;
				ammomanagerArsenal = ammomanagerscr.ArsenalAutorifle1mr;
				ammotext.text ="Ammo  "+ ammomanagerArsenal.ToString();
			}
			if(item.id == 6)
			{
				ammotext.enabled = true;
				inventory.tooltypeObj.SetActive(true);
				inventory.icon.sprite = item.icon;
				inventory.itemName.text = item.nameItem;
				inventory.description.text = item.descriptionItem;
				ammotext.text ="Ammo  "+ ammomanagerArsenal.ToString();
			}
				if(item.id == 7)
			{
				ammotext.enabled = true;
				inventory.tooltypeObj.SetActive(true);
				inventory.icon.sprite = item.icon;
				inventory.itemName.text = item.nameItem;
				inventory.description.text = item.descriptionItem;
				ammomanagerArsenal = ammomanagerscr.ArsenalAutoMachineGunmr;
				ammotext.text ="Ammo  "+ ammomanagerArsenal.ToString();
			}
				if(item.id == 8)
			{
				ammotext.enabled = true;
				inventory.tooltypeObj.SetActive(true);
				inventory.icon.sprite = item.icon;
				inventory.itemName.text = item.nameItem;
				inventory.description.text = item.descriptionItem;
				ammotext.text ="Ammo  "+ ammomanagerArsenal.ToString();
			}
				if(item.id == 9)
			{
				ammotext.enabled = true;
				inventory.tooltypeObj.SetActive(true);
				inventory.icon.sprite = item.icon;
				inventory.itemName.text = item.nameItem;
				inventory.description.text = item.descriptionItem;
				ammomanagerArsenal = ammomanagerscr.ArsenalPistol1mr;
				ammotext.text ="Ammo  "+ ammomanagerArsenal.ToString();
			}
				if(item.id == 10)
			{
				ammotext.enabled = true;
				inventory.tooltypeObj.SetActive(true);
				inventory.icon.sprite = item.icon;
				inventory.itemName.text = item.nameItem;
				inventory.description.text = item.descriptionItem;
				ammomanagerArsenal = ammomanagerscr.ArsenalPistol1mr;
				ammotext.text ="Ammo  "+ ammomanagerArsenal.ToString();
			}
			
		}
		if(tooltypeswitch == 2)		
		{
			inventory.tooltypeObj.SetActive(false);
			tooltypeswitch = 0;
		}	
		
	}
	private void buttonManager()
	{
		CurentItem currentItem = GetComponent<CurentItem>();
		index = currentItem.Index;
			if(index == 0)
			{
				buttonEq0.SetActive(true);
				buttonEq1.SetActive(false);
				buttonEq2.SetActive(false);
				buttonEq3.SetActive(false);
				buttonEq4.SetActive(false);
				buttonEq5.SetActive(false);
				buttonEq6.SetActive(false);
				buttonEq7.SetActive(false);
			}		
			if(index == 1)
			{
				buttonEq1.SetActive(true);
				buttonEq0.SetActive(false);
				buttonEq2.SetActive(false);
				buttonEq3.SetActive(false);
				buttonEq4.SetActive(false);
				buttonEq5.SetActive(false);
				buttonEq6.SetActive(false);
				buttonEq7.SetActive(false);
			}
			if(index == 2)
			{
				buttonEq2.SetActive(true);
				buttonEq0.SetActive(false);
				buttonEq1.SetActive(false);
				buttonEq3.SetActive(false);
				buttonEq4.SetActive(false);
				buttonEq5.SetActive(false);
				buttonEq6.SetActive(false);
				buttonEq7.SetActive(false);

			}
			if(index == 3)
			{
				buttonEq3.SetActive(true);
				buttonEq0.SetActive(false);
				buttonEq1.SetActive(false);
				buttonEq4.SetActive(false);
				buttonEq5.SetActive(false);
				buttonEq6.SetActive(false);
				buttonEq7.SetActive(false);
			}
			if(index == 4)
			{
				buttonEq4.SetActive(true);
				buttonEq0.SetActive(false);
				buttonEq1.SetActive(false);
				buttonEq2.SetActive(false);
				buttonEq3.SetActive(false);
				buttonEq5.SetActive(false);
				buttonEq6.SetActive(false);
				buttonEq7.SetActive(false);
			}
			if(index == 5)
			{
				buttonEq5.SetActive(true);
				buttonEq0.SetActive(false);
				buttonEq1.SetActive(false);
				buttonEq2.SetActive(false);
				buttonEq3.SetActive(false);
				buttonEq4.SetActive(false);
				buttonEq6.SetActive(false);
				buttonEq7.SetActive(false);
			}
			if(index == 6)
			{
				buttonEq6.SetActive(true);
				buttonEq0.SetActive(false);
				buttonEq1.SetActive(false);
				buttonEq2.SetActive(false);
				buttonEq3.SetActive(false);
				buttonEq4.SetActive(false);
				buttonEq5.SetActive(false);
				buttonEq7.SetActive(false);
			}
			if(index == 7)
			{
				buttonEq7.SetActive(true);
				buttonEq0.SetActive(false);
				buttonEq1.SetActive(false);
				buttonEq2.SetActive(false);
				buttonEq3.SetActive(false);
				buttonEq4.SetActive(false);
				buttonEq5.SetActive(false);
				buttonEq6.SetActive(false);
			}
	}
}
