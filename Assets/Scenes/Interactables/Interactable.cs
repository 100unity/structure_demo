using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] public float Radius { get; set; }
    [SerializeField] public Transform InteractionTransform { get; set; }

    private bool isFocus = false;
    private Transform player;
    private bool hasInteracted = false;

    void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, InteractionTransform.position);
            if (distance <= Radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public virtual void Interact()
    {
        // override
        Debug.Log("INTERACT");
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(InteractionTransform.position, Radius);
    }
}