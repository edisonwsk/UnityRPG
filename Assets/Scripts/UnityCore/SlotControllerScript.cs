﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using UnityRPG;

public class SlotControllerScript : MonoBehaviour
{
	public GameDataObject gameDataObject { get; set; }

	public DragItemControllerScript dragItem;
	public BoxCollider2D boxCollider2D;

	public Text slotText;

	// Use this for initialization
	void Start ()
	{
		
	}

	void OnLevelWasLoaded(int level)
	{
		loadGameData();
	}

	private void loadGameData()
	{
		gameDataObject = GameObject.FindObjectOfType<GameDataObject>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (this.boxCollider2D == null) {
			this.boxCollider2D = this.gameObject.GetComponent<BoxCollider2D>();
		}

		if (dragItem != null) {
			dragItem.transform.position = gameObject.transform.position;
		}

	}

	private void updateSlotText()
	{
		if(dragItem!= null)
		{
			slotText.text = dragItem.name;
		}
		else{
			slotText.text = "Empty";
		}
	}
		
	public virtual DragItemControllerScript getItem()
	{
		if (this.dragItem != null) {

			gameDataObject.playerGameCharacter.inventory.Remove (this.dragItem.item);

			Debug.Log("Removed item " + this.dragItem.gameObject.name + "  from " + gameObject.name);

			DragItemControllerScript tempItem = dragItem;
			this.dragItem = null;
			return tempItem;

		}
		return null;
	}

	public virtual bool addItem(DragItemControllerScript dragItem)
	{
		Debug.Log ("Added item " + dragItem.gameObject.name + "  to " + gameObject.name);

		if (this.dragItem == null) {
			this.dragItem = dragItem;
			this.dragItem.addToSlot (this);

			gameDataObject.playerGameCharacter.inventory.Add (this.dragItem.item);

			return true;
		} else {
			return false;
		}
	}

}
