using UnityEngine;

public class Player : MonoBehaviour {
	
	private MazeCell currentCell;
	
	private MazeDirection currentDirection;

    public Rigidbody rb;

    private int points;

    private void Start()
    {
        points = 0;
    }

    public void SetLocation (MazeCell cell) {
		if (currentCell != null) {
			currentCell.OnPlayerExited();
		}
		currentCell = cell;
		transform.localPosition = cell.transform.localPosition;
		currentCell.OnPlayerEntered();
	}
	
	/*private void Move (MazeDirection direction) {
		MazeCellEdge edge = currentCell.GetEdge(direction);
		if (edge is MazePassage) {
			SetLocation(edge.otherCell);
		}
	}*/
	
	private void Look (MazeDirection direction) {
		transform.localRotation = direction.ToRotation();
		currentDirection = direction;
	}
	
	private void Update () {
		if (Input.GetKey (KeyCode.W)) {
            rb.AddRelativeForce(Vector3.forward * 30f * Time.deltaTime, ForceMode.Impulse);
			//transform.Translate (Vector3.forward * 5f * Time.deltaTime);
            if (rb.velocity.x > 2f)
            {
                rb.velocity.x.Equals(2f);
            }
		}
		if (Input.GetKey (KeyCode.S)) {
            rb.AddRelativeForce(Vector3.back * 30f * Time.deltaTime, ForceMode.Impulse);
            //transform.Translate (Vector3.back * 5f * Time.deltaTime);
            if (rb.velocity.x < -2f)
            {
                rb.velocity.x.Equals(-2f);
            }
        }
		if (Input.GetKey (KeyCode.A)) {
            rb.AddRelativeForce(Vector3.left * 30f * Time.deltaTime, ForceMode.Impulse);
            //transform.Translate (Vector3.left * 5f * Time.deltaTime);
            if (rb.velocity.z > 2f)
            {
                rb.velocity.z.Equals(2f);
            }
        }
		if (Input.GetKey (KeyCode.D)) {
            rb.AddRelativeForce(Vector3.right * 30f * Time.deltaTime, ForceMode.Impulse);
            //transform.Translate (Vector3.right * 5f * Time.deltaTime);
            if (rb.velocity.z < -2)
            {
                rb.velocity.z.Equals(-2f);
            }
        }
 
		float mouseInput = Input.GetAxis("Mouse X");
		Vector3 lookhere = new Vector3(0,mouseInput,0);
		transform.Rotate(lookhere);
	}

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Candy"))
        {
            points++;
            other.gameObject.SetActive(false);
        }
    }
}
