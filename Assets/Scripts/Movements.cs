using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Movements : MonoBehaviour {

	public LevelManager levelManager;
	public UI uI;
	public AudioClips audioClips;

	//Movement Variables
	private float moveSpeed = 40.0f;
	private int walkingIndex = 0;
	private Vector3 jumpPos = new Vector3 (0f, 130f, 0f);
	private Vector3 downRayCast;
	private Vector3 playerPos;
	
	//Animation Variables
	public Sprite[] walkingSprites;
	private bool walkingDirection;
	public GameObject robotSmashedLeft;
	public GameObject robotSmashedRight;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//Variables for jump raycasting
		downRayCast = transform.TransformDirection(Vector3.down);
		playerPos = new Vector3 (transform.position.x, transform.position.y -10f, 0f);

		//Function that switches sprite image based on movement
		//Must be at beginning of update function to work properly
		WalkingCycle (walkingIndex);

		//Jump Movements
		if ((Input.GetKeyDown(KeyCode.Space) || 
		     Input.GetKeyDown(KeyCode.UpArrow)) && 
		    (Physics2D.Raycast(playerPos, downRayCast, 4f))) {

			rigidbody2D.velocity = jumpPos;
			audioClips.Jump ();

		}

		//Left Movement
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.position += Vector3.left * moveSpeed * Time.deltaTime;
			walkingIndex = 3;
			WalkingCycle(walkingIndex);
			walkingIndex = 2;
		}

		//Right Movement
		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.position += Vector3.right * moveSpeed * Time.deltaTime;
			walkingIndex = 1;
			WalkingCycle(walkingIndex);
			walkingIndex = 0;
		}

		//TODO: The transition from walking robot to smashed robot images can be
		//done much better than this with a single sprite sheet and removing tags
		//after smashed. It would require less code and less prefab objects.
		if (Physics2D.Raycast (playerPos, downRayCast, 4f)) {
			RaycastHit2D robotHit = Physics2D.Raycast (playerPos, downRayCast, 4f);

			if (robotHit.transform.gameObject.tag == "Robot") {
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

		if (collision.gameObject.CompareTag ("Robot")) {
			transform.collider2D.isTrigger = true;
			//levelManager.LoadLevel("GameOver");
		}
	}
	
	//Function that switches sprite image based on movement
	void WalkingCycle (int walkInd) {
		this.GetComponent<SpriteRenderer>().sprite = walkingSprites[walkInd];
	}
}