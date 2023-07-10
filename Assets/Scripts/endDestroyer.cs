using UnityEngine;

public class endDestroyer : MonoBehaviour
{

    public GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "enemy")
        {
             
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "bullet")
        {
            Destroy(other.gameObject);
            player.GetComponent<playerController>().BulletMissed();
        }
    }
}
