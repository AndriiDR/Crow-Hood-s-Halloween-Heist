using UnityEngine;

public class Player : MonoBehaviour {
	
	private MazeCell currentCell;
	
	private MazeDirection currentDirection;
	
	public void SetLocation (MazeCell cell) {
		if (currentCell != null) {
			currentCell.OnPlayerExited();
		}
		currentCell = cell;
		transform.localPosition = cell.transform.localPosition;
		currentCell.OnPlayerEntered();
	}
	
	private void Move (MazeDirection direction) {
		MazeCellEdge edge = currentCell.GetEdge(direction);
		if (edge is MazePassage) {
			SetLocation(edge.otherCell);
		}
	}
	
	private void Look (MazeDirection direction) {
		transform.localRotation = direction.ToRotation();
		currentDirection = direction;
	}
	
	private void Update () {
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (Vector3.forward * 5f * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (Vector3.back * 5f * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (Vector3.left * 5f * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (Vector3.right * 5f * Time.deltaTime);
		}
		float mouseInput = Input.GetAxis("Mouse X");
		Vector3 lookhere = new Vector3(0,mouseInput,0);
		transform.Rotate(lookhere);
	}
}
