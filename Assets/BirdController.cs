using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float rotationSpeed = 0.1f;

    public float forwardSpeed = 0.1f;

    public float maxVelocity = 1f;

    private Rigidbody rb;

    private KeyCode? lastKeyCode = null;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        bool xAxisInputReceived = false;
        if ((lastKeyCode == KeyCode.W || lastKeyCode == null) && Input.GetKey(KeyCode.W))
        {
            lastKeyCode = KeyCode.W;
            xAxisInputReceived = true;
            transform.Rotate(-rotationSpeed, 0, 0);
        }
        if ((lastKeyCode == KeyCode.S || lastKeyCode == null) && Input.GetKey(KeyCode.S))
        {
            lastKeyCode = KeyCode.S;
            xAxisInputReceived = true;
            transform.Rotate(rotationSpeed, 0, 0);
        }

        if (!xAxisInputReceived)
        {
            Vector3 targetRotation = transform.rotation.eulerAngles;
            targetRotation.x = 0f;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRotation), 0.05f);
        }

        bool yAxisInputReceived = false;
        if ((lastKeyCode == KeyCode.D || lastKeyCode == null) && Input.GetKey(KeyCode.D))
        {
            lastKeyCode = KeyCode.D;
            yAxisInputReceived = true;
            transform.Rotate(0, rotationSpeed, 0, Space.World);

            Vector3 targetRotation = transform.rotation.eulerAngles;
            targetRotation.z = -90f;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(targetRotation), 0.05f);
        }
        if ((lastKeyCode == KeyCode.A || lastKeyCode == null) && Input.GetKey(KeyCode.A))
        {
            lastKeyCode = KeyCode.A;
            yAxisInputReceived = true;
            transform.Rotate(0, -rotationSpeed, 0, Space.World);

            Vector3 targetRotation = transform.rotation.eulerAngles;
            targetRotation.z = 90f;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(targetRotation), 0.05f);
        }

        if (!yAxisInputReceived)
        {
            Vector3 targetRotation = transform.rotation.eulerAngles;
            targetRotation.z = 0f;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(targetRotation), 0.05f);
        }


        if (!xAxisInputReceived && !yAxisInputReceived)
        {
            lastKeyCode = null;
        }

        // Marche droit devant toi
        rb.AddForce(transform.forward * forwardSpeed);
        
        // Mais vas pas trop vite fréro
        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("COLLISION ENTER");
    }
}
