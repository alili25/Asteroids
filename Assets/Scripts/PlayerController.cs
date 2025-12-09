using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Ship parameters")]
    [SerializeField] private float shipAcceleration = 10f;
    [SerializeField] private float shipMaxVelocity= 10f;
    [SerializeField] private float shipRotationSpeed = 100f;
    [SerializeField] private float BulletSpeed = 8f;

    [Header("Object refereces")]
    [SerializeField] private Transform BulletSpawn;
    [SerializeField] private Rigidbody2D BulletPrefab;
    [SerializeField] private ParticleSystem destroyedParticles;

    private Rigidbody2D shipRigidbody;
    private bool isAlive = true;
    private bool isAccelerating = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
       shipRigidbody = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    private void Update()
    {
        if (isAlive)
        {
            HandleShipAcceleration();
            HandleShipRotation();
            HandleShooting();
        }
    }

    private void FixedUpdate()
    {
        if (isAlive && isAccelerating)
        {
            shipRigidbody.AddForce(shipAcceleration * transform.up);
            shipRigidbody.linearVelocity = Vector2.ClampMagnitude(shipRigidbody.linearVelocity, shipMaxVelocity);
        }
    }

    private void HandleShipAcceleration()
    {
        isAccelerating = Input.GetKey(KeyCode.UpArrow);
    }

    private void HandleShipRotation() {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(shipRotationSpeed * Time.deltaTime * transform.forward);
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-shipRotationSpeed * Time.deltaTime * transform.forward);
        }
    }

    private void HandleShooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody2D Bullet = Instantiate(BulletPrefab, BulletSpawn.position, Quaternion.identity);

            Vector2 shipVelocity = shipRigidbody.linearVelocity;
            Vector2 shipDirection = transform.up;
            float shipFowardSpeed = Vector2.Dot(shipVelocity, shipDirection);

            if (shipFowardSpeed < 0)
            {
                shipFowardSpeed = 0;
            }
            Bullet.linearVelocity = shipDirection * shipFowardSpeed;
            Bullet.AddForce(BulletSpeed * transform.up, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
    if (collision.CompareTag("Asteroid")) {
      isAlive = false;

      GameManager gameManager = FindAnyObjectByType<GameManager>();

      gameManager.GameOver();
      Instantiate(destroyedParticles, transform.position, Quaternion.identity);

      Destroy(gameObject);
    }
  }
}
