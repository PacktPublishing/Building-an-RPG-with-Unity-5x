using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// This class is used to make referencing easier in the code
/// </summary>
public static class SceneName
{
  public const string MainMenu = "MainMenu";
  public const string CharacterCustomization = "CH4_CC";
  public const string Level_1 = "CH5";
}

public class LevelController
{
  // let's have a reference to the current scene/level
  public Scene CURRENT_SCENE
  {
    get { return SceneManager.GetActiveScene(); }
  }

  // keep the numerical level value
  public int LEVEL = 0;

  public void OnLevelWasLoaded()
  {
    // if we are in the character customization scene, 
    // let's get a reference to the base game object for future use.
    if (this.CURRENT_SCENE.Equals(SceneName.CharacterCustomization))
    {
      if (GameObject.FindGameObjectWithTag("BASE") != null)
      {
        GameMaster.instance.CHARACTER_CUSTOMIZATION = GameObject.FindGameObjectWithTag("BASE") as GameObject;
      }
    }

    // If we are at any other scene except character customization
    // let's go ahead and get reference to player and player
    // stat position
    if (this.CURRENT_SCENE.name.Equals(SceneName.CharacterCustomization))
    {
      //Debug.Log(string.Format("I am in {0} scene...", SceneManager.GetActiveScene().name));

      // let's get a reference to our player character
      if (GameMaster.instance.PC_GO == null)
      {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
          GameMaster.instance.PC_GO = GameObject.FindGameObjectWithTag("Player") as GameObject;
        }
      }

      if (GameObject.FindGameObjectWithTag("START_POSITION") != null)
      {
        GameMaster.instance.START_POSITION = GameObject.FindGameObjectWithTag("START_POSITION") as GameObject;
      }

      if (GameMaster.instance.START_POSITION != null && GameMaster.instance.PC_GO != null)
      {
        GameMaster.instance.PC_GO.transform.position = GameMaster.instance.START_POSITION.transform.position;
        GameMaster.instance.PC_GO.transform.rotation = GameMaster.instance.START_POSITION.transform.rotation;
      }
    }

    // determine what level we are on
    this.DetermineLevel();
  }

  // this function will set a numerical value for our levels
  private void DetermineLevel()
  {
    switch (this.CURRENT_SCENE.name)
    {
      case SceneName.MainMenu:
      case SceneName.CharacterCustomization:
        {
          this.LEVEL = 0;
          break;
        }

      case SceneName.Level_1:
        {
          this.LEVEL = 1;
          GameMaster.instance.PC_GO.GetComponent<IKHandle>().enabled = true;
          break;
        }
      default:
        {
          this.LEVEL = 0;
          break;
        }
    }
  }

  // this function will be used to load our scenes
  public void LoadLevel()
  {
    switch (GameMaster.instance.LEVEL_CONTROLLER.LEVEL)
    {
      case 0:
        {
          SceneManager.LoadScene(SceneName.CharacterCustomization);
          break;
        }

      // load level 1
      case 1:
        {
          GameMaster.instance.PC_GO = GameObject.FindGameObjectWithTag("Player") as GameObject;
          SceneManager.LoadScene(SceneName.Level_1);
          break;
        }
    }
  }
}
