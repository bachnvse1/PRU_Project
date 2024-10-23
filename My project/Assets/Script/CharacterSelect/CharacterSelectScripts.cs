using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectScripts : MonoBehaviour
{
    private int index;
    [SerializeField] GameObject[] characters;
    [SerializeField] TextMeshProUGUI textMeshPro;

    [SerializeField] GameObject[] characterPrefabs;
    public static GameObject selectedCharacter;


    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        SelectCharacter();
    }

    public void OnPrevBtnClick()
    {
        if (index > 0)
        {
            index--;
        }
        SelectCharacter();
    }

    public void OnNextBtnClick()
    {
        if (index < characters.Length - 1)
        {
            index++;
        }
        SelectCharacter();
    }

    public void OnPlayBtnClick()
    {
        SceneManager.LoadScene(1);
    }

    private void SelectCharacter()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            if (i == index)
            {
                characters[i].GetComponent<SpriteRenderer>().color = Color.white;
                characters[i].GetComponent<Animator>().enabled = true;
                textMeshPro.text = characters[i].name;
                selectedCharacter = characterPrefabs[i];
            }

            else
            {
                characters[i].GetComponent<SpriteRenderer>().color = Color.black;
                characters[i].GetComponent<Animator>().enabled = false;
            }
        }
    }

}
