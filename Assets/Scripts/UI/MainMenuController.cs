using CoffeyUtils.Sound;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
	[SerializeField] private MusicTrack _mainMenuMusic;
	[SerializeField] private Canvas _mainMenuCanvas;
	[SerializeField] private Canvas _optionsCanvas;
	
	[Header("Buttons to Select")]
	[SerializeField] private GameObject _mainMenuFirstSelected;
	[SerializeField] private GameObject _openOptionsSelect;
	[SerializeField] private GameObject _closeOptionsSelect;
	
	private void Start()
	{
		SetMenuActive(0);
		SetSelected(_mainMenuFirstSelected);
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		_mainMenuMusic.Play();
		_mainMenuMusic.Queue();
	}
	
	public void QuitGame()
	{
		Application.Quit();
		
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#endif
	}
	
	public void StartGame()
	{
		SceneManager.LoadScene(1);
	}
	
	public void OpenOptions()
	{
		SetMenuActive(1);
		SetSelected(_openOptionsSelect);
	}
	
	public void CloseOptions()
	{
		SetMenuActive(0);
		SetSelected(_closeOptionsSelect);
	}
	
	private void SetMenuActive(int menu)
	{
		_mainMenuCanvas.enabled = menu == 0;
		_optionsCanvas.enabled = menu == 1;
	}
	
	private void SetSelected(GameObject obj) => MouseControllerManager.UpdateSelected(obj);
}