using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameMaster : MonoBehaviour {

	// Use this for initialization
	void Start () {
      DontDestroyOnLoad(this);
   }
	
	// Update is called once per frame
	void Update () {
	
	}

   public void StartGame()
   {
      // NOTE: You should put in the name of the Scene
      // that respresents your level 1
      SceneManager.LoadScene("L1_Awakening");
   }
}
