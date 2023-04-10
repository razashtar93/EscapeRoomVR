using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animation anim;

    private void Start()
    {
        anim = GetComponent<Animation>();
    }

    public void PlayAnimation()
    {
        anim.Play();
    }
}
