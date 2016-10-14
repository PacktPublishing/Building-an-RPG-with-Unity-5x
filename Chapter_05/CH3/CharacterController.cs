using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour
{

  public Animator animator;

  public float speed = 6.0f;
  public float h = 0.0f;
  public float v = 0.0f;

  public bool attack1 = false;  // used for attack mode 1
  public bool attack2 = false;  // used for attack mode 2
  public bool attack3 = false;  // used for attack mode 3

  public bool jump = false;     // used for jumping
  public bool die = false;      // are we alive?

  public bool DEBUG = false;

  // Use this for initialization
  void Start()
  {
    this.animator = GetComponent<Animator>() as Animator;
  }

  // Update is called once per frame
  private Vector3 moveDirection = Vector3.zero;

  void Update()
  {

    if (Input.GetKeyDown(KeyCode.C))
    {
      this.attack1 = true;
      this.GetComponent<IKHandle>().enabled = false;
    }
    if (Input.GetKeyUp(KeyCode.C))
    {
      this.attack1 = false;
      this.GetComponent<IKHandle>().enabled = true;
    }
    animator.SetBool("Attack1", attack1);

    if (Input.GetKeyDown(KeyCode.Z))
    {
      this.attack2 = true;
      this.GetComponent<IKHandle>().enabled = false;
    }
    if (Input.GetKeyUp(KeyCode.Z))
    {
      this.attack2 = false;
      this.GetComponent<IKHandle>().enabled = true;
    }
    animator.SetBool("Attack2", attack2);

    if (Input.GetKeyDown(KeyCode.X))
    {
      this.attack3 = true;
      this.GetComponent<IKHandle>().enabled = false;
    }
    if (Input.GetKeyUp(KeyCode.X))
    {
      this.attack3 = false;
      this.GetComponent<IKHandle>().enabled = true;
    }
    animator.SetBool("Attack3", attack3);

    if (Input.GetKeyDown(KeyCode.Space))
    {
      this.jump = true;
      this.GetComponent<IKHandle>().enabled = false;
    }
    if (Input.GetKeyUp(KeyCode.Space))
    {
      this.jump = false;
      this.GetComponent<IKHandle>().enabled = true;
    }
    animator.SetBool("Jump", jump);

    if (Input.GetKeyDown(KeyCode.I))
    {
      this.die = true;
      SendMessage("Died");
    }
    animator.SetBool("Die", die);

  }

  void FixedUpdate()
  {
    // The Inputs are defined in the Input Manager
    h = Input.GetAxis("Horizontal"); // get value for horizontal axis
    v = Input.GetAxis("Vertical");   // get value for vertical axis

    speed = new Vector2(h, v).sqrMagnitude;

    if (DEBUG)
      Debug.Log(string.Format("H:{0} - V:{1} - Speed:{2}", h, v, speed));

    animator.SetFloat("Speed", speed);
    animator.SetFloat("Horizontal", h);
    animator.SetFloat("Vertical", v);

  }

  void OnTriggerEnter(Collider other)
  {

  }

}
