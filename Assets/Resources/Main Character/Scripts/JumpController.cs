using System.Collections;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public float initialJumpForce = 10f;
    public float jumpForceIncrease = 40f;
    public float jumpCooldownTime = 1f;

    private bool canJump = true;
    private float lastJumpTime;
    private float currentJumpForce;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastJumpTime = -jumpCooldownTime; // Set an initial value to allow jumping at the start
        currentJumpForce = initialJumpForce; // Set the initial jump force
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && CanJump())
        {
            Jump();
        }
    }

    void Jump()
    {
        if (rb != null)
        {
            rb.AddForce(Vector3.up * currentJumpForce, ForceMode.Impulse);
            canJump = false;
            lastJumpTime = Time.time;
            StartCoroutine(ResetJumpCooldown());

            // Trigger the jump animation
            Debug.Log("Jump Triggered");
            GetComponent<Animator>().SetTrigger("JumpAnimationTrigger");
        }
        else
        {
            Debug.LogError("Rigidbody component not found.");
        }
    }

    bool CanJump()
    {
        return canJump;
    }

    IEnumerator ResetJumpCooldown()
    {
        yield return new WaitForSeconds(jumpCooldownTime);
        canJump = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            // The player picked up the power-up, increase jump force
            IncreaseJumpForce();
            // Optionally, disable or destroy the power-up object
            Destroy(other.gameObject);
        }
    }

    void IncreaseJumpForce()
    {
        currentJumpForce += jumpForceIncrease;
        Debug.Log("Jump Force Increased: " + currentJumpForce);
    }
}
