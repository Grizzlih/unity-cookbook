using UnityEngine;

public class ArrangeActions : MonoBehaviour
{
	private RectTransform _panelRectTransform;

	void Awake()
	{
		// cache reference to parent Rect Transform
		_panelRectTransform = GetComponent<RectTransform>();
	}

	//------------------------------
	// we change the 'SiblingIndex' of the parent GameObject to be one LESS
	// so it is drawn sooner, and so 'below' the next UI object to be drawn
	public void MoveDownOne()
	{
		print ("(before change) " + gameObject.name +  " sibling index = " + _panelRectTransform.GetSiblingIndex());

		int currentSiblingIndex = _panelRectTransform.GetSiblingIndex();
		_panelRectTransform.SetSiblingIndex( currentSiblingIndex - 1 );

		print ("(after change) " + gameObject.name +  " sibling index = " + _panelRectTransform.GetSiblingIndex());
	}

	//------------------------------
	// we change the 'SiblingIndex' of the parent GameObject to be one MORE
	// so it is drawn later, and so 'above' the next UI object to be drawn
	public void MoveUpOne()
	{
		print ("(before change) " + gameObject.name +  " sibling index = " + _panelRectTransform.GetSiblingIndex());

		int currentSiblingIndex = _panelRectTransform.GetSiblingIndex();
		if (currentSiblingIndex > 0)
		{
			_panelRectTransform.SetSiblingIndex( currentSiblingIndex - 1 );
		}
		else
		{
			_panelRectTransform.SetSiblingIndex( currentSiblingIndex + 1 );
		}
		print ("(after change) " + gameObject.name +  " sibling index = " + _panelRectTransform.GetSiblingIndex());
	}
}
