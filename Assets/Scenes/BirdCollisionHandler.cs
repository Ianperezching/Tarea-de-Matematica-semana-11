using UnityEngine;

public class BirdCollisionHandler : MonoBehaviour
{
    private Vector3 initialPosition;
    private Rigidbody rb;

    private void Start()
    {
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.left * 5f, ForceMode.Impulse);
            transform.position = new Vector3(transform.position.x, initialPosition.y, transform.position.z);
        }
    }

    private void Update()
    {
        
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        if (screenPoint.x < 0 || screenPoint.y > 1 || screenPoint.y < 0)
        {
            Debug.Log("Game Over");
            Time.timeScale = 0;
        }
    }
}
