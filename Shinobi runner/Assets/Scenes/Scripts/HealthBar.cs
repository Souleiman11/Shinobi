using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health PlayerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    private void Start(){
        currentHealthBar.fillAmount = PlayerHealth.currentHealth / 10;

    }
    // Update is called once per frame
    void Update()
    {
        currentHealthBar.fillAmount = PlayerHealth.currentHealth / 10;
    }
}
