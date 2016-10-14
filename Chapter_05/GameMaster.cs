using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.Collections;

public class GameMaster : MonoBehaviour
{
  public static GameMaster instance;

  // let's have a reference to the player character GameObject
  public GameObject PC_GO;

  // reference to player Character Customization
  public PC PC_CC;

  public GameObject START_POSITION;

  public GameObject CHARACTER_CUSTOMIZATION;

  public LevelController LEVEL_CONTROLLER;
  public AudioController AUDIO_CONTROLLER;

  // Ref to UI Elements ...
  public bool DISPLAY_SETTINGS = false;
  public UIController UI;

  void Awake()
  {
    // simple singlton
    if (instance == null)
    {
      instance = this;

      // initialize Level Controller
      instance.LEVEL_CONTROLLER = new LevelController();

      // initialize Audio Controller
      instance.AUDIO_CONTROLLER = new AudioController();
      instance.AUDIO_CONTROLLER.AUDIO_SOURCE = GameMaster.instance.GetComponent<AudioSource>();
      instance.AUDIO_CONTROLLER.SetDefaultVolume();
    }
    else if (instance != this)
    {
      Destroy(this);
    }

    // keep the game object when moving from
    // one scene to the next scene
    DontDestroyOnLoad(this);
  }

  // for each level/scene that has been loaded
  // do some of the preparation work
  void OnLevelWasLoaded()
  {
    GameMaster.instance.LEVEL_CONTROLLER.OnLevelWasLoaded();
  }

  // Use this for initialization
  void Start()
  {
    // let's find a reference to the UI controller of the loaded scene
    if (GameObject.FindGameObjectWithTag("UI") != null)
    {
      GameMaster.instance.UI = GameObject.FindGameObjectWithTag("UI").GetComponent<UIController>();
    }

    GameMaster.instance.UI.SettingsCanvas.gameObject.SetActive(GameMaster.instance.DISPLAY_SETTINGS);
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void MasterVolume(float volume)
  {
    GameMaster.instance.AUDIO_CONTROLLER.MasterVolume(volume);
  }

  public void StartGame()
  {
    GameMaster.instance.LoadLevel();
  }

  public void LoadLevel()
  {
    GameMaster.instance.LEVEL_CONTROLLER.LoadLevel();
  }
}

