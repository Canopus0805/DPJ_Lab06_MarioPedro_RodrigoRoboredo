using UnityEngine;
[RequireComponent(typeof(Collider))]
public class Token : MonoBehaviour
{
    public int value;
    public AudioClip pickupSfx;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Awake()
    {
        GetComponent<Collider>().isTrigger = true;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        if (UIManager.Instance != null)
        {
            UIManager.Instance.AddScore(value);
        }

        if (pickupSfx != null)
        {
            AudioSource.PlayClipAtPoint(pickupSfx, transform.position);
        }

        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()

    {
        
    }
}
