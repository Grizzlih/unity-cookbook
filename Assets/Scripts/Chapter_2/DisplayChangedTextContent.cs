using UnityEngine;
using UnityEngine.UI;

public class DisplayChangedTextContent : MonoBehaviour
{
	public InputField inputField;
	private Text textDisplay;

	private void Awake()
	{
		textDisplay = GetComponent<Text>();
	}

	public void DisplayNewValue()
	{
		textDisplay.text = $"last entry = '{inputField.text}'";
	}
}
