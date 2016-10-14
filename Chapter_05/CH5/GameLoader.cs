using UnityEngine;
using System.Collections;


public class GameLoader : MonoBehaviour
{

  public GameObject gameMaster;

  void Awake()
  {
    if (GameMaster.instance == null)
    {
      GameObject.Instantiate(this.gameMaster);
    }
  }
}

