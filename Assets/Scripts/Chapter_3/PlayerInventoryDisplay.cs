using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerInventory))]
public class PlayerInventoryDisplay : MonoBehaviour
{
	// reference to a UI Text object
	// public - so we have to assign via the Inspector
	public Text starText;
	public Text starTextTotalMessage;
	public Image imageStarGO;
	public Sprite iconNoStart;
	public Sprite iconStar;
	public Image iconStarsYellow;
	public GameObject panelSlotGrid;
	public GameObject starSlotPrefab;

	private const int NUM_INVENTORY_SLOTS = 5;
	private readonly PickupUI[] _slots = new PickupUI[NUM_INVENTORY_SLOTS];

	private void Awake()
	{
		float width = 50 + (NUM_INVENTORY_SLOTS * 50);
		panelSlotGrid.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
		for (int i = 0; i < NUM_INVENTORY_SLOTS; i++)
		{
			GameObject starSlotGO = Instantiate(starSlotPrefab, panelSlotGrid.transform, true);
			starSlotGO.transform.localScale = new Vector3(1, 1, 1);
			_slots[i] = starSlotGO.GetComponent<PickupUI>();
		}
	}


	//------------------------------
	// update the text message on screen
	// to indicate if we are carrying the star or not
	public void OnChangeCarryingStar(bool carryingStar)
	{
		string message;
		Sprite icon;
		if (carryingStar)
		{
			message = "Carrying star :-)";
			icon = iconStar;
		}
		else
		{
			message = "no start :-(";
			icon = iconNoStart;
		}
		starText.text = message;
		imageStarGO.sprite = icon;
	}

	public void OnChangeStarTotal(int starTotal)
	{
		string starMessage = "total stars = " + starTotal;
		starTextTotalMessage.text = starMessage;
		float newWidth = 100 * starTotal;
		iconStarsYellow.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newWidth);

		for (int i = 0; i < NUM_INVENTORY_SLOTS; i++)
		{
			PickupUI slot = _slots[i];
			if (i < starTotal)
			{
				slot.DisplayColorIcon();
			}
			else
			{
				slot.DisplayGreyIcon();
			}
		}
	}
}