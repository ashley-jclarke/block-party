using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{

    [SerializeField] private PlayerController player;

    private const string IS_WALKING = "IsWalking";
    private Animator animator;

    void Awake()
    {
        this.animator = GetComponent<Animator>();
        this.animator.SetBool(IS_WALKING, this.player.IsWalking());
    }

    // Update is called once per frame
    void Update()
    {
        this.animator.SetBool(IS_WALKING, this.player.IsWalking());
    }
}
