using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float horizontalInput;
    private float movementSpeed = 2000f;
    private float maxHorizontalVelocity = 10f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        if ((horizontalInput < 0 && rb.velocity.x > -maxHorizontalVelocity) || (horizontalInput > 0 && rb.velocity.x < maxHorizontalVelocity))
        {
            rb.AddForce(new Vector3(horizontalInput * movementSpeed * Time.deltaTime, 0f, 0f));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SpawnTrigger")
        {
            SpawnController spawnController = other.gameObject.GetComponentInParent<SpawnController>();
            spawnController.SpawnNextFloor();
        }
    }
}
