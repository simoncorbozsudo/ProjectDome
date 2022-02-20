using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float rotationSpeed = 2f;

    public float forwardSpeed = 10f;

    public float maxVelocity = 1.5f;

    public Transform cameraTransform;

    public Animator animator;

    private Rigidbody rb;

    private AudioSource audiosource;

    private KeyCode? lastKeyCode = null;
    private bool isDead = false;

    void Start()
    {
        audiosource =GetComponent<AudioSource>(); 
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        bool xAxisInputReceived = false;
        if (lastKeyCode != KeyCode.S && Input.GetKey(KeyCode.W))
        {
            lastKeyCode = KeyCode.W;
            xAxisInputReceived = true;
            transform.Rotate(-rotationSpeed, 0, 0);
        }
        if (lastKeyCode != KeyCode.W && Input.GetKey(KeyCode.S))
        {
            lastKeyCode = KeyCode.S;
            xAxisInputReceived = true;
            transform.Rotate(rotationSpeed, 0, 0);
        }

        bool yAxisInputReceived = false;
        if (lastKeyCode != KeyCode.A && Input.GetKey(KeyCode.D))
        {
            lastKeyCode = KeyCode.D;
            yAxisInputReceived = true;
            transform.Rotate(0, rotationSpeed, 0);

            Vector3 slerpedRotation = Quaternion.Slerp(Quaternion.Euler(0, 0, transform.localEulerAngles.z), Quaternion.Euler(0, 0, -90f), 0.04f).eulerAngles;
            slerpedRotation.x = transform.localEulerAngles.x;
            slerpedRotation.y = transform.localEulerAngles.y;

            transform.localEulerAngles = slerpedRotation;
        }
        if (lastKeyCode != KeyCode.D && Input.GetKey(KeyCode.A))
        {
            lastKeyCode = KeyCode.A;
            yAxisInputReceived = true;
            transform.Rotate(0, -rotationSpeed, 0);

            Vector3 slerpedRotation = Quaternion.Slerp(Quaternion.Euler(0, 0, transform.localEulerAngles.z), Quaternion.Euler(0, 0, 90f), 0.04f).eulerAngles;
            slerpedRotation.x = transform.localEulerAngles.x;
            slerpedRotation.y = transform.eulerAngles.y;

            transform.localEulerAngles = slerpedRotation;
        }


        if (!xAxisInputReceived && !yAxisInputReceived)
        {
            lastKeyCode = null;

            Vector3 targetRotationX = transform.rotation.eulerAngles;
            targetRotationX.x = 0f;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(targetRotationX), 0.04f);

            Vector3 targetRotationZ = transform.rotation.eulerAngles;
            targetRotationZ.z = 0f;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(targetRotationZ), 0.04f);

        }

        // Marche droit devant toi
        if (!isDead)
        {
            rb.AddForce(transform.forward * forwardSpeed);
        }

        // Mais vas pas trop vite fréro
        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isDead = true;

        cameraTransform.SetParent(null);

        rb.velocity = Vector3.zero;
        Vector3 dir = collision.contacts[0].point - transform.position;
        dir = -dir.normalized;
        rb.AddForce(dir * 30);
        audiosource.Play();
        animator.SetBool("isDead", true);
    }
}
