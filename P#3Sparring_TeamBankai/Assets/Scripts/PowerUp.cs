using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerType { Strengh,FullHealth }
    public PowerType powerType;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerControl player = other.GetComponent<PlayerControl>();

            if (powerType == PowerType.Strengh) player.StrengthBoost();

            if (powerType == PowerType.FullHealth) player.FullHeal();

            Destroy(gameObject);
        }
    }
}
