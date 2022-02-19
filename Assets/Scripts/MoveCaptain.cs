using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCaptain : MonoBehaviour
{
    public float forwardSpeed = 20f, strafeSpeed = 7.5f, hoverSpeed = 5f, forwardMinSpeed = 10f;
    private float activeForwardSpeed, activeStrafeSpeed, activeHoverSpeed;
    private float forwardAcceleration = 2.5f, strafeAcceleration = 2f, hoverAcceleration = 2f;
    public float lookRateSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDistance;
    public Rigidbody m_captainBody;

    private float rollInput;
    public float rollSpeed = 10f, rollAcceleration = 3.5f;

    public float rollLimit = 40f;

    void Start(){
        Debug.Log("StartedMovementObj");
        screenCenter.x = Screen.width * .5f;
        screenCenter.y = Screen.height * .5f;
        m_captainBody.AddForce(Vector3.forward * 20f);

        //we know the captain body
    }
    void FixedUpdate(){
        // lookInput.x = Input.mousePosition.x;
        // lookInput.y = Input.mousePosition.y;

        // mouseDistance.x = (lookInput.x - screenCenter.x)/ screenCenter.x;
        // mouseDistance.y = (lookInput.y - screenCenter.y)/ screenCenter.y;

        // mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        // rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAcceleration = Time.deltaTime);

        // m_captainBody.transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, mouseDistance.x * lookRateSpeed * Time.deltaTime, rollInput* rollSpeed, Space.Self);

        // activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, forwardSpeed, forwardAcceleration*Time.deltaTime);
        // activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, strafeAcceleration*Time.deltaTime);
        // activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAcceleration*Time.deltaTime);
        
        // m_captainBody.transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
        // m_captainBody.transform.position += (transform.right * activeStrafeSpeed * Time.deltaTime) + (transform.up * activeHoverSpeed * Time.deltaTime);

        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDistance.x = (lookInput.x - screenCenter.x)/ screenCenter.x;
        mouseDistance.y = (lookInput.y - screenCenter.y)/ screenCenter.y;

        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAcceleration = Time.deltaTime);

        m_captainBody.transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, mouseDistance.x * lookRateSpeed * Time.deltaTime, rollInput* rollSpeed, Space.Self);

        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, forwardSpeed, forwardAcceleration*Time.deltaTime);
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, strafeAcceleration*Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAcceleration*Time.deltaTime);
        
        m_captainBody.AddForce( transform.forward * activeForwardSpeed, ForceMode.VelocityChange);
        m_captainBody.AddForce( transform.right * activeStrafeSpeed + transform.up * activeHoverSpeed,ForceMode.VelocityChange);


    }
}
