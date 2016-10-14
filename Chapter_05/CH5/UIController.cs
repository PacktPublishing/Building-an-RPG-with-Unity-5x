using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour
{
  public Canvas SettingsCanvas;
  public Slider ControlMainVolume;

  public void Update()
  {

  }

  public void DisplaySettings()
  {
    GameMaster.instance.DISPLAY_SETTINGS = !GameMaster.instance.DISPLAY_SETTINGS;
    this.SettingsCanvas.gameObject.SetActive(GameMaster.instance.DISPLAY_SETTINGS);
  }

  public void MainVolume()
  {
    GameMaster.instance.MasterVolume(ControlMainVolume.value);
  }

  public void StartGame()
  {
    GameMaster.instance.StartGame();
  }

  public void LoadLevel()
  {
    if(GameObject.FindGameObjectWithTag("BASE"))
    {
      GameMaster.instance.PC_CC = GameObject.FindGameObjectWithTag("BASE").GetComponent<CharacterCustomization>().PC_CC;
    }
    GameMaster.instance.LEVEL_CONTROLLER.LEVEL = 1;
    GameMaster.instance.LoadLevel();
  }
}
