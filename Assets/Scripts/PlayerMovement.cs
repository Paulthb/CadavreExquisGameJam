using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float jumpGrenade = 6f;

    public int maxPlatform = 5;
    [System.NonSerialized]
    public int nbCurrentPlatform = 0;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public Text heightText;

    public Transform cameraTransform = null;

    Vector3 velocity;
    bool isGrounded;

    #region Singleton Pattern
    private static PlayerMovement _instance;

    public static PlayerMovement Instance { get { return _instance; } }
    #endregion

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
           // velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.tag == "Platform" || hit.collider.tag == "PlatformZone")
        {
            //Debug.Log("c cool ca marche");
            velocity.y = Mathf.Sqrt(jumpGrenade * -2f * gravity);

            if (hit.collider.tag == "Platform")
            {
                Grenade platformObject = hit.gameObject.GetComponent<Grenade>();
                platformObject.StartDeathtime();
            }
        }
    }

    public void IncreaseNbPlatform()
    {
        nbCurrentPlatform++;
        updateText();
    }

    public void DecreaseNbPlatform()
    {
        nbCurrentPlatform--;
        updateText();
    }

    public void Teleport(Vector3 newPos)
    {
        controller.enabled = false;
        controller.transform.position = newPos;

        transform.rotation = Quaternion.identity;
        cameraTransform.rotation = Quaternion.identity;

        controller.enabled = true;
    }

    public void updateText()
    {
        heightText.text = (maxPlatform - nbCurrentPlatform).ToString();
    }
}