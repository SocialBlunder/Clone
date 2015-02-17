using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Movements : MonoBehaviour {

	public LevelManager levelManager;
	public UI uI;
	public AudioClips audioClips;
	public FloatingPlatform floatingPlatform;
	Animator myAnimator;

	//Movement Variables
	private float moveSpeed = 40.0f;
	private Vector3 jumpPos = new Vector3 (0f, 130f, 0f);
	private Vector3 downRayCast;
	private Vector3 playerPos;
	private bool isOnPlatform;
	
	//Animation Variables
	private bool walkingDirection = true;
	public GameObject robotSmashedLeft;
	public GameObject robotSmashedRight;
	private bool notDead = true;

	// Use this for initialization
	void Start () {
		myAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Variables for jump raycasting
		downRayCast = transform.TransformDirection(Vector3.down);
		playerPos = new Vector3 (transform.position.x, transform.position.y -10f, 0f);
		bool isOnGround = Physics2D.Raycast (playerPos, downRayCast, 4f);

		if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && notDead){
			
			if (walkingDirection && isOnGround){
				myAnimator.CrossFade ("SpriteStandingRight", 0.0f);
			} else if (!walkingDirection && isOnGround){
				myAnimator.CrossFade ("SpriteStandingLeft", 0.0f);
			}

			if (walkingDirection && !isOnGround){
				myAnimator.CrossFade ("JumpRight", 0.0f);
			} else if (!walkingDirection && !isOnGround){
				myAnimator.CrossFade ("JumpLeft", 0.0f);
			}
		}

		//Jump Movements
		if ((Input.GetKeyDown(KeyCode.Space) || 
		     Input.GetKeyDown(KeyCode.UpArrow)) && isOnGround && notDead) {

			rigidbody2D.velocity = jumpPos;
			audioClips.Jump ();

		}

		//Left Movement
		if (Input.GetKey(KeyCode.LeftArrow) && notDead) {
			transform.position += Vector3.left * moveSpeed * Time.deltaTime;

			if (isOnGround){
				myAnimator.CrossFade ("SpriteWalkingLeft", 0.0f);
			} else {
				myAnimator.CrossFade ("JumpLeft", 0.0f);
			}

			walkingDirection = false;
		}

		//Right Movement
		if (Input.GetKey(KeyCode.RightArrow) && notDead) {
			transform.position += Vector3.right * moveSpeed * Time.deltaTime;

			if (isOnGround){
				myAnimator.CrossFade ("SpriteWalkingRight", 0.0f);
			} else {
				myAnimator.CrossFade ("JumpRight", 0.0f);
			}

			walkingDirection = true;
		}

		if (floatingPlatform.movingLeft && isOnPlatform) {
			transform.position += Vector3.left * floatingPlatform.moveSpeed * Time.deltaTime;
		} else if (!floatingPlatform.movingLeft && isOnPlatform) {
			transform.position += Vector3.right * floatingPlatform.moveSpeed * Time.deltaTime;
		}

		//TODO: The transition from walking robot to smashed robot images can be
		//done much better than this with a single sprite sheet and removing tags
		//after smashed. It would require less code and less prefab objects.
		if (Physics2D.Raycast (playerPos, downRayCast, 4f)) {
			RaycastHit2D robotHit = Physics2D.Raycast (playerPos, downRayCast, 4f);

			if (robotHit.transform.gameObject.tag == "Robot" && notDead) {
				Vector3 robotPos = robotHit.transform.position;
				Destroy (robotHit.transform.gameObject);

				audioClips.RobotCrush();
				uI.AddToScore(200);

				GameObject robot = GameObject.Find("Robot");
				
				walkingDirection = robot.GetComponent<Robot>().walkingLeft;
				
				if (walkingDirection){
					GameObject.Instantiate (robotSmashedLeft, robotPos, Quaternion.identity);
				} else if (!walkingDirection) {
					GameObject.Instantiate (robotSmashedRight, robotPos, Quaternion.identity);
				}
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		//Plays audio on collision with objects tagged as Atom
		if (collision.gameObject.CompareTag ("Atom")) {

			audioClips.AtomGet();
			uI.AddAtom();
			uI.AddToScore(100);
		}

		if (collision.gameObject.CompareTag ("FloatingPlatformCollision")) {
			floatingPlatform = collision.gameObject.GetComponent<FloatingPlatform>();
			isOnPlatform = true;
		}

		if (collision.gameObject.CompareTag ("Robot") ||
		    collision.gameObject.CompareTag ("HatchMonster") ||
		    collision.gameObject.CompareTag ("SmallEnemy")) {
			notDead = false;
		
			
			if (walkingDirection){
				myAnimator.CrossFade ("ElectrocutionRight", 0.0f);
			} else {
				myAnimator.CrossFade ("ElectrocutionLeft", 0.0f);
			}

			audioClips.Electrocution();
			
			rigidbody2D.velocity = jumpPos;

			transform.collider2D.isTrigger = true;
		}
	}

	void OnCollisionExit2D(Collision2D collision) {

		if (collision.gameObject.CompareTag ("FloatingPlatformCollision")) {
			isOnPlatform = false;
		}
	}
}