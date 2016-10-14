using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class PlayerAgent : MonoBehaviour {

    //[SerializeField]
    public PC playerCharacterData;

    void Awake()
    {
        PC tmp = new PC();
        tmp.NAME = "Maximilian";
        tmp.HEALTH = 100.0f;
        tmp.DEFENSE = 50.0f;
        tmp.DESCRIPTION = "Our Hero";
        tmp.DEXTERITY = 33.0f;
        tmp.INTELLIGENCE = 80.0f;
        tmp.STRENGTH = 60.0f;

        this.playerCharacterData = tmp;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(this.playerCharacterData.HEALTH<0.0f)
        {
            this.playerCharacterData.HEALTH = 0.0f;

            this.transform.GetComponent<CharacterController>().die = true;
        }
	}
}
