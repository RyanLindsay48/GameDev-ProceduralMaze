using UnityEngine;

public enum Direction {
	Forward,
	Backward,
	Left,
	Right
}

public class Player : MonoBehaviour {
	public float movementSpeed;
	public float rotationSpeed;
	private GameObject player;
	private GameObject playerCamera;
	private Vector3 currentDirection;



	public void SetLocation (MazeCell cell) {
		player = GameObject.FindGameObjectWithTag("Player");
		playerCamera = GameObject.FindGameObjectWithTag("PlayerCamera");

		player.transform.position = cell.transform.position;
	}

	private void FixedUpdate () {
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
			Move(Direction.Forward);
		} 
		else if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
			Move(Direction.Backward);
		} 
		else if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			Move(Direction.Left);
		}
		else if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
			Move(Direction.Right);
		}
		else if (Input.GetAxis("Mouse X") != 0f) {
			Look(Input.GetAxis("Mouse X"));
		}
	}

	private void Move (Direction direction) {
		if (direction == Direction.Forward) {
			currentDirection = playerCamera.transform.forward;
		} 
		else if (direction == Direction.Backward) {
			currentDirection = -playerCamera.transform.forward;
		} 
		else if (direction == Direction.Left) {
			currentDirection = -playerCamera.transform.right;
		}
		else { // (direction == Direction.Right) 
			currentDirection = playerCamera.transform.right;
		}

		currentDirection.y = transform.position.y;
		currentDirection.Normalize();
		player.GetComponent<Rigidbody>().MovePosition(player.transform.position + currentDirection * movementSpeed * Time.deltaTime);

		//updateLocation
	}

	private void Look (float rotation) {
		player.transform.Rotate(0, rotation * Time.deltaTime * rotationSpeed, 0);		
	}
}
