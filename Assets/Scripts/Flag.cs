using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[RequireComponent(typeof(Collider))]
public class Flag : MonoBehaviour
{
    public int lives;
    private int scoreNeeded = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
            if (UIManager.Instance.score == scoreNeeded)
            {
                UIManager.Instance.SetLives(UIManager.Instance.startLives+1);
                Debug.Log("Parabens és fixe!");
            }
        }
    }
}
