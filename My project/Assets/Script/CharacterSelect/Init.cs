using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        GameObject selectedCharacter = CharacterSelectScripts.selectedCharacter;
        Instantiate(selectedCharacter, transform.position, Quaternion.identity);
        //playerObject.name = selectedCharacter.name;
    }
}
