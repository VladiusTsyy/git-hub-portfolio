using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CurentItem : MonoBehaviour
{
	///[HideInInspector]
	public int Index;
	GameObject InventoryObj;
	Inventory inventory;
	PlayerDead playerDeads;
	public GameObject player;
	public GameObject swipebarmanager;
	public GameObject panelFon;
	public GameObject tooltypeObj;
	public GameObject gameManager;

	public Transform rHand;
	AmmoManager ammomanagerscr;
	Image panelFonImage;
	SwipeBarManager swipebarmanagerscr;
	


	void Start ()
	{
		panelFonImage = panelFon.GetComponent<Image>();
		swipebarmanagerscr =  swipebarmanager.GetComponent<SwipeBarManager>();
		player = GameObject.FindGameObjectWithTag("Player");
		InventoryObj = GameObject.FindGameObjectWithTag("InventoryManager");
		inventory = InventoryObj.GetComponent<Inventory>();
		playerDeads = player.GetComponent<PlayerDead>();
		ammomanagerscr = gameManager.GetComponent<AmmoManager>();
	}

	public void OnEquip()
	{
		if(inventory.item[Index].id == 11)
		{
			ammomanagerscr.ArsenalAutoMachineGunmr += Random.Range(30,60);
			tooltypeObj.SetActive(false);
			panelFonImage.enabled = false;
		
			if(inventory.item[Index].countItem > 1)
			{
				inventory.item[Index].countItem--;
			}
			else
			{
				inventory.item[Index] = new Item();
			}
			inventory.DisplayItems();	 
		}
if(inventory.item[Index].id == 12) /// stop there
		{
			int randomshotgunammo;
			Transform tParent = rHand;
			Transform tChilddestroyweapon = tParent.GetChild(5);
			randomshotgunammo = Random.Range(8,15);
				if(tChilddestroyweapon.GetComponent<Shotgun1>()!=null)
				{
					tChilddestroyweapon.GetComponent<Shotgun1>().ArsenalShotgun1 += randomshotgunammo;
					ammomanagerscr.ArsenalPistol1mr = tChilddestroyweapon.GetComponent<Shotgun1>().ArsenalShotgun1;
				}
				if(tChilddestroyweapon.GetComponent<Shotgun2>()!=null)
				{
					tChilddestroyweapon.GetComponent<Shotgun2>().ArsenalShotgun1 += randomshotgunammo;
					ammomanagerscr.ArsenalPistol1mr = tChilddestroyweapon.GetComponent<Shotgun2>().ArsenalShotgun1;
				}
			
			ammomanagerscr.ArsenalShotgun1mr += randomshotgunammo;
			tooltypeObj.SetActive(false);
			panelFonImage.enabled = false;
		
			if(inventory.item[Index].countItem > 1)
			{
				inventory.item[Index].countItem--;
			}
			else
			{
				inventory.item[Index] = new Item();
			}
			inventory.DisplayItems();	 
		}

		if(inventory.item[Index].id == 13)
		{
			int randompistolammo;
			Transform tParent = rHand;
			Transform tChilddestroyweapon = tParent.GetChild(5);
			randompistolammo = Random.Range(7,15);
				if(tChilddestroyweapon.GetComponent<Pistol_1>()!=null)
				{
					tChilddestroyweapon.GetComponent<Pistol_1>().ArsenalPistol1 += randompistolammo;
					ammomanagerscr.ArsenalPistol1mr = tChilddestroyweapon.GetComponent<Pistol_1>().ArsenalPistol1;
				}
				if(tChilddestroyweapon.GetComponent<pistolethrebet>()!=null)
				{
					tChilddestroyweapon.GetComponent<pistolethrebet>().ArsenalPistol1 += randompistolammo;
					ammomanagerscr.ArsenalPistol1mr = tChilddestroyweapon.GetComponent<Pistol_1>().ArsenalPistol1;
				}
				if(tChilddestroyweapon.GetComponent<pistoletcolt>()!=null)
				{
					tChilddestroyweapon.GetComponent<pistoletcolt>().ArsenalPistol1 += randompistolammo;
					ammomanagerscr.ArsenalPistol1mr = tChilddestroyweapon.GetComponent<pistoletcolt>().ArsenalPistol1;
				}
			
			ammomanagerscr.ArsenalPistol1mr += randompistolammo;
			tooltypeObj.SetActive(false);
			panelFonImage.enabled = false;
		
			if(inventory.item[Index].countItem > 1)
			{
				inventory.item[Index].countItem--;
			}
			else
			{
				inventory.item[Index] = new Item();
			}
			inventory.DisplayItems();	 
		}


			if(inventory.item[Index].id == 14)
		{
			ammomanagerscr.ArsenalAutorifle1mr += Random.Range(15,30);
			int randomautorifleammo;
			Transform tParent = rHand;
			Transform tChilddestroyweapon = tParent.GetChild(5);
			randomautorifleammo = Random.Range(20,40);
			if(tChilddestroyweapon.GetComponent<Uzi>()!=null)
				{
					tChilddestroyweapon.GetComponent<Uzi>().ArsenalAutorifle1 += randomautorifleammo;
					ammomanagerscr.ArsenalPistol1mr = tChilddestroyweapon.GetComponent<Uzi>().ArsenalAutorifle1;
				}
			if(tChilddestroyweapon.GetComponent<Autorifle1>()!=null)
				{
					tChilddestroyweapon.GetComponent<Autorifle1>().ArsenalAutorifle1 += randomautorifleammo;
					ammomanagerscr.ArsenalPistol1mr = tChilddestroyweapon.GetComponent<Autorifle1>().ArsenalAutorifle1;
				}
			ammomanagerscr.ArsenalAutorifle1mr += randomautorifleammo;
			tooltypeObj.SetActive(false);
			panelFonImage.enabled = false;
		
			if(inventory.item[Index].countItem > 1)
			{
				inventory.item[Index].countItem--;
			}
			else
			{
				inventory.item[Index] = new Item();
			}
			inventory.DisplayItems();	 
		}

		if(inventory.item[Index].id == 1)
		{
			playerDeads.AddHealth(25);
			tooltypeObj.SetActive(false);
			panelFonImage.enabled = false;
		
			if(inventory.item[Index].countItem > 1)
			{
				inventory.item[Index].countItem--;
			}
			else
			{
				inventory.item[Index] = new Item();
			}
			inventory.DisplayItems();
		}
		else
		{
			Drop();
		}
	
	
			///if(inventory.item[Index].id == 2 || inventory.item[Index].id == 3 || inventory.item[Index].id == 4  || inventory.item[Index].id == 5)
			///{
				///Item witem = Instantiate<GameObject>(Resources.Load<GameObject>(inventory.item[Index].pathPrefab)).GetComponent<Item>();////Zagruzka obekta cherez witem player deads
				///playerDeads.AddHand(witem);////Zagruzka obyekta v ruki
		///		swipebarmanagerscr.SwipeBar(); ///vizov svayp bara(Swipe BarManager)
		///		if(inventory.item[Index].countItem > 1)
		///	{
		///		inventory.item[Index].countItem--;
		///	}
		///	else
		///	{
		///		inventory.item[Index] = new Item();
		///	}
		///	inventory.DisplayItems();
		///}
		///inventory.tooltypeObj.SetActive(false);
	}
	void Drop()
	{
		if(inventory.item[Index].id == 3)
		{
			Shotgun1 shotgun1script;
			for (int i = 0; i < inventory.itemDatabase.transform.childCount; i++)
			{
	
				Item item = inventory.itemDatabase.transform.GetChild(i).GetComponent<Item>();
				if(item != null)
				{
					if(inventory.item[Index].id == item.id)
					{
						GameObject witem = Instantiate(item.gameObject);////Zagruzka obekta cherez witem player deads
						shotgun1script = witem.GetComponent<Shotgun1>();
						shotgun1script.enabled = true;	
						playerDeads.AddHand(witem);////Zagruzka obyekta v ruki
						swipebarmanagerscr.SwipeBar(item);
						inventory.item[Index] = new Item();
						inventory.tooltypeObj.SetActive(false);
						panelFonImage.enabled = false;
						inventory.DisplayItems();
					}
				}
				
				
			}
		}
		{
		
		if(inventory.item[Index].id == 4 )
		{
			
			for (int i = 0; i < inventory.itemDatabase.transform.childCount; i++)
			{
				Pistol_1 pistol1script;
				Item item = inventory.itemDatabase.transform.GetChild(i).GetComponent<Item>();
				if(item != null)
				{
					if(inventory.item[Index].id == item.id)
					{
						GameObject witem = Instantiate(item.gameObject);////Zagruzka obekta cherez witem player deads
						pistol1script = witem.GetComponent<Pistol_1>();
						pistol1script.enabled = true;	
						playerDeads.AddHand(witem);////Zagruzka obyekta v ruki
						swipebarmanagerscr.SwipeBar(item);
						inventory.item[Index] = new Item();
						inventory.tooltypeObj.SetActive(false);
						panelFonImage.enabled = false;
						inventory.DisplayItems();
					}
				}
				
				
			}
		}
		if(inventory.item[Index].id == 5 )
		{
			
			for (int i = 0; i < inventory.itemDatabase.transform.childCount; i++)
			{
				Autorifle1 autorifle1script;
				Item item = inventory.itemDatabase.transform.GetChild(i).GetComponent<Item>();
				if(item != null)
				{
					if(inventory.item[Index].id == item.id)
					{
						GameObject witem = Instantiate(item.gameObject);////Zagruzka obekta cherez witem player deads
						autorifle1script = witem.GetComponent<Autorifle1>();
						autorifle1script.enabled = true;	
						playerDeads.AddHand(witem);////Zagruzka obyekta v ruki
						swipebarmanagerscr.SwipeBar(item);
						inventory.item[Index] = new Item();
						inventory.tooltypeObj.SetActive(false);
						panelFonImage.enabled = false;
						inventory.DisplayItems();
					}
				}
				
				
			}
		}
		if(inventory.item[Index].id == 6 )
		{
			
			for (int i = 0; i < inventory.itemDatabase.transform.childCount; i++)
			{
				Uzi uziscript;
				Item item = inventory.itemDatabase.transform.GetChild(i).GetComponent<Item>();
				if(item != null)
				{
					if(inventory.item[Index].id == item.id)
					{
						GameObject witem = Instantiate(item.gameObject);////Zagruzka obekta cherez witem player deads
						uziscript = witem.GetComponent<Uzi>();
						uziscript.enabled = true;	
						playerDeads.AddHand(witem);////Zagruzka obyekta v ruki
						swipebarmanagerscr.SwipeBar(item);
						inventory.item[Index] = new Item();
						inventory.tooltypeObj.SetActive(false);
						panelFonImage.enabled = false;
						inventory.DisplayItems();
					}
				}
				
				
			}
		}
		if(inventory.item[Index].id == 7 )
		{
			
			for (int i = 0; i < inventory.itemDatabase.transform.childCount; i++)
			{
				AutoMachineGun Automashingun;
				Item item = inventory.itemDatabase.transform.GetChild(i).GetComponent<Item>();
				if(item != null)
				{
					if(inventory.item[Index].id == item.id)
					{
						GameObject witem = Instantiate(item.gameObject);////Zagruzka obekta cherez witem player deads
						Automashingun = witem.GetComponent<AutoMachineGun>();
						Automashingun.enabled = true;	
						playerDeads.AddHand(witem);////Zagruzka obyekta v ruki
						swipebarmanagerscr.SwipeBar(item);
						inventory.item[Index] = new Item();
						inventory.tooltypeObj.SetActive(false);
						panelFonImage.enabled = false;
						inventory.DisplayItems();
					}
				}
				
				
			}
		}
		if(inventory.item[Index].id == 8 )
		{
			
			for (int i = 0; i < inventory.itemDatabase.transform.childCount; i++)
			{
				Shotgun2 shotgun2scr;
				Item item = inventory.itemDatabase.transform.GetChild(i).GetComponent<Item>();
				if(item != null)
				{
					if(inventory.item[Index].id == item.id)
					{
						GameObject witem = Instantiate(item.gameObject);////Zagruzka obekta cherez witem player deads
						shotgun2scr = witem.GetComponent<Shotgun2>();
						shotgun2scr.enabled = true;	
						playerDeads.AddHand(witem);////Zagruzka obyekta v ruki
						swipebarmanagerscr.SwipeBar(item);
						inventory.item[Index] = new Item();
						inventory.tooltypeObj.SetActive(false);
						panelFonImage.enabled = false;
						inventory.DisplayItems();
					}
				}
				
				
			}
		}
			if(inventory.item[Index].id == 9 )
		{
			
			for (int i = 0; i < inventory.itemDatabase.transform.childCount; i++)
			{
				pistoletcolt pistoletcoltscr;
				Item item = inventory.itemDatabase.transform.GetChild(i).GetComponent<Item>();
				if(item != null)
				{
					if(inventory.item[Index].id == item.id)
					{
						GameObject witem = Instantiate(item.gameObject);////Zagruzka obekta cherez witem player deads
						pistoletcoltscr = witem.GetComponent<pistoletcolt>();
						pistoletcoltscr.enabled = true;	
						playerDeads.AddHand(witem);////Zagruzka obyekta v ruki
						swipebarmanagerscr.SwipeBar(item);
						inventory.item[Index] = new Item();
						inventory.tooltypeObj.SetActive(false);
						panelFonImage.enabled = false;
						inventory.DisplayItems();
					}
				}
				
				
			}
		}
					if(inventory.item[Index].id == 10 )
		{
			
			for (int i = 0; i < inventory.itemDatabase.transform.childCount; i++)
			{
				pistolethrebet pistolethrebetscr;
				Item item = inventory.itemDatabase.transform.GetChild(i).GetComponent<Item>();
				if(item != null)
				{
					if(inventory.item[Index].id == item.id)
					{
						GameObject witem = Instantiate(item.gameObject);////Zagruzka obekta cherez witem player deads
						pistolethrebetscr = witem.GetComponent<pistolethrebet>();
						pistolethrebetscr.enabled = true;	
						playerDeads.AddHand(witem);////Zagruzka obyekta v ruki
						swipebarmanagerscr.SwipeBar(item);
						inventory.item[Index] = new Item();
						inventory.tooltypeObj.SetActive(false);
						panelFonImage.enabled = false;
						inventory.DisplayItems();
					}
				}
				
				
			}
		}																
	}
	}
}