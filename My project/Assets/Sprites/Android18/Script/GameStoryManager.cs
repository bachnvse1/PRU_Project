using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStoryManager : MonoBehaviour
{
	public void ShowGameStory()
	{
		SceneManager.LoadScene("GameStoryScene");
	}
}