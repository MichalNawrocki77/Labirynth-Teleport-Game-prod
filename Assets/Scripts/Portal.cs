using UnityEngine;

public class Portal : MonoBehaviour
{
    private GameObject player;

    [SerializeField] Transform portalCollider;
    [SerializeField] Portal otherPortal;
    [SerializeField] Material material;
    public UnityEngine.Camera myCamera;

    public Transform renderSurface;

    private PortalTeleport portalTeleport;
    private PortalCamera portalCamera;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        portalTeleport = portalCollider.GetComponent<PortalTeleport>();
        portalTeleport.player = player.transform;
        portalTeleport.receiver = otherPortal.portalCollider;

        portalCamera = myCamera.GetComponent<PortalCamera>();
        portalCamera.playerCamera = player.GetComponentInChildren<Camera>().transform;
        portalCamera.otherPortal = otherPortal.transform;
        portalCamera.portal = transform;

        renderSurface.GetComponent<Renderer>().material = Instantiate(material);
        if(myCamera.targetTexture != null)
        {
            myCamera.targetTexture.Release();
        }
        myCamera.targetTexture = new RenderTexture(Screen.width, Screen.height,24);
        
    }

    private void Start()
    {
        renderSurface.GetComponent<Renderer>().material.mainTexture = otherPortal.GetComponent<Portal>().myCamera.targetTexture;
    }
}
