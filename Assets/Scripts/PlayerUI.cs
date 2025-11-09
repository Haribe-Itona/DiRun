using Unity.VisualScripting;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] public Player pl;
    public CustomButton LeftButton;
    public CustomButton RitghButton;
    public CustomButton Jump;
    public CustomButton Run;

    void Start()
    {
        LeftButton.OnHold += pl.Move;
        LeftButton.OnPress += () => { pl.move = -1f; };
        LeftButton.OnRelease += () => { pl.move = 0f; };
        LeftButton.OnRelease += () => {  Debug.Log("OnUp.R"); };
        RitghButton.OnHold += pl.Move;
        RitghButton.OnHold += () => { pl.move = 1f; };
        RitghButton.OnRelease += () => { pl.move = 0f; };
        RitghButton.OnRelease += () => {  Debug.Log("OnUp.R"); };

        Jump.OnPress += pl.Jump;
        Jump.OnHold += pl.HoldJump;
        Jump.OnRelease += () => { pl.isJump = false; };
        Jump.OnRelease += () => {  Debug.Log("OnUp.J"); };

        Run.OnPress += () => { pl.run = true; };
        Run.OnRelease += () => { pl.run = false; };
        Run.OnRelease += () => {  Debug.Log("OnUp.Run"); };
    }

    void FixedUpdate()
    {
        if (LeftButton.run)
        {
            LeftButton.Hold();
        }
        if (RitghButton.run)
        {
            RitghButton.Hold();
        }
        if (Jump.run)
        {
            Jump.Hold();
        }
        if (Run.run)
        {
            Run.Hold();
        }
    }
}

