using UnityEngine;

public class Saw : MonoBehaviour
{
        [SerializeField] float damage;

        private void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
