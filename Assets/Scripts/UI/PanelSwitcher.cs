using System.Collections.Generic;
using CoffeyUtils;
using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
	[SerializeField] private int _defaultPanel;
	[SerializeField] private List<Canvas> _panels;
	[SerializeField, ReadOnly] private int _openPanel;
	//[SerializeField] private List<GameObject> _selectObj;

	public int CurrentlyOpenPanel => _openPanel;
	
	private void Start()
	{
		OpenPanel(_defaultPanel);
	}
	
	[Button]
	public void OpenPanel(int num)
	{
		if (num < 0 || num >= _panels.Count) 
		{
			Debug.LogError("Cannot open panel #" + num, gameObject);
			return;
		}
		_openPanel = num;
		foreach (var panel in _panels)
		{
			panel.enabled = false;
		}
		_panels[num].enabled = true;
		//if (num < _selectObj.Count) SelectObj(_selectObj[num]);
	}
	
	public void SelectObj(GameObject obj)
	{
		MouseControllerManager.UpdateSelected(obj);
	}
}
