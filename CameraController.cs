using UnityEngine;
using Photon.Pun;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    private PhotonView photonView;
    private Rigidbody rb;

    public float speed = 5f;
    public float jumpForce = 7f;
    public float crouchHeight = 0.5f;
    private float originalHeight;
    private bool isGrounded;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody>();
        originalHeight = transform.localScale.y;
    }

    private void Update()
    {
        if (photonView.IsMine)
        {
            Move();
            HandleJump();
            HandleCrouch();
            MaintainHeight();
        }
    }

    public void AssignPlayer(Photon.Realtime.Player player)
    {
        photonView.Owner = player;
        if (photonView.IsMine)
        {
            playerTransform = PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity).transform;
            transform.SetParent(playerTransform);
        }
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void HandleCrouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchHeight, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, originalHeight, transform.localScale.z);
        }
    }

    private void MaintainHeight()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if (hit.distance < 5f)
            {
                Vector3 targetPosition = new Vector3(transform.position.x, hit.point.y + 5f, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
