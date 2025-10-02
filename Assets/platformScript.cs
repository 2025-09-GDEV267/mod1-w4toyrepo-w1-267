using UnityEngine;

public class platformScript : MonoBehaviour
{
    Collider col;
    Rigidbody player;
    private void Start()
    {
        col = GetComponent<Collider>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (player.linearVelocity.y > 0)
        {
            col.enabled = false;
        }
        else
        {
            col.enabled = true;
        }
    }
}
