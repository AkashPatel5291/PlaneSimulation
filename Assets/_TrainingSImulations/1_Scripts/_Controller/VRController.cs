using UnityEngine;

public class VRController : MonoBehaviour
{
    Animator anim;
    bool isOn = false;

    public void Start()
    {
        anim = GetComponent<Animator>();
        SetMaterial(false);
    }

    public void OnPointerEnter()
    {
        SetMaterial(true);
    }

    public void OnPointerExit()
    {
        SetMaterial(false);
    }

    public void OnPointerClick()
    {
        if (isOn)
        {
            isOn = false;
            anim.Play("Off");
        }
        else
        {
            isOn = true;
            anim.Play("On");
        }
    }

    private void SetMaterial(bool gazedAt)
    {
        
    }
}
