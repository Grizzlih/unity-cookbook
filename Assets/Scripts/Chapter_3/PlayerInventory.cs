using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
	// a cached reference to an instance of class PlayerInventoryDisplay
	private PlayerInventoryDisplay playerInventoryDisplay;

	// flag to indicate if player is carrying a star or not
	private bool carryingStar = false;
	private int totalStars = 0;

	//------------------------
	// cache a reference to the PlayerInventoryDisplay object
	// that is in the parent GameObject
	void Awake()
	{
		playerInventoryDisplay = GetComponent<PlayerInventoryDisplay>();
	}

	//------------------------
	// Ensure UI display matches this initial state
	// of whether we are carrying a star or not
	void Start()
	{
		playerInventoryDisplay.OnChangeCarryingStar(carryingStar);
		playerInventoryDisplay.OnChangeStarTotal(totalStars);
	}

    //--------------------------
	// when we hit a star, update carrying flag
	// and update the display
	// (and remove the star GameObject)
	void OnTriggerEnter2D(Collider2D hit)
	{
		// IF we hit something tagged 'Star'
		if (hit.CompareTag("Star"))
		{
			// set our flag to TRUE
			carryingStar = true;
			totalStars++;

			// update the UI display of our star carrying status
			playerInventoryDisplay.OnChangeCarryingStar(carryingStar);
			playerInventoryDisplay.OnChangeStarTotal(totalStars);

			// destroy the star object that we collided with
			Destroy(hit.gameObject);
		}
	}
}
