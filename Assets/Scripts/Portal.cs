using UnityEngine;

public class Portal : MonoBehaviour
{
    private GameObject player;
    [SerializeField] PortalTeleport portalCollider;
    [SerializeField] Transform otherPortal;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        portalCollider.player = player.transform;
        portalCollider.receiver = otherPortal.transform;
    }
}
