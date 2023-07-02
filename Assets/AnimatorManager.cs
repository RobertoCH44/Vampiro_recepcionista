using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public Animator anim;
    public string animation01;

    public void PlayAnimation()
    {
        anim.Play(animation01);
    }
}
