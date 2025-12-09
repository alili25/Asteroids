using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float bulletLifetime = 1f;

    private void awake()
    {
        Destroy(gameObject, bulletLifetime);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
