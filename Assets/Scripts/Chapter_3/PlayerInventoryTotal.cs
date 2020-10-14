using UnityEngine;

public class PlayerInventoryTotal : MonoBehaviour
{
	// a cached reference to an instance of class PlayerInventoryDisplay
	private PlayerInventoryDisplayTotal playerInventoryDisplay;

	// counter to record total numebr of stars being carryied
	private int _starTotal = 0;

	//------------------------
	// cache a reference to the PlayerInventoryDisplay object
	// that is in the parent GameObject
	void Awake()
	{
		playerInventoryDisplay = GetComponent<PlayerInventoryDisplayTotal>();
	}

	//------------------------
	// Ensure UI display matches this initial state
	// of whether we are carrying a star or not
	void Start()
	{
        playerInventoryDisplay.OnChangeStarTotal(_starTotal);
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
            // increment the total by 1
            _starTotal++;

			// update the UI display of our star carrying status
            playerInventoryDisplay.OnChangeStarTotal(_starTotal);

			// destroy the star object that we collided with
			Destroy(hit.gameObject);
		}
	}
}
