using UnityEngine;
using System.Collections;
using System.Collections.Generic;    

public class AnimationPlayer : MonoBehaviour
{
    public Animator myAnimator;
    public List<string> animationQueue;
    private List<bool> animationLoopStatus;
    private bool isPlayingAnimation = false;

    private void Start()
    {
        animationQueue = new List<string>();
        animationLoopStatus = new List<bool>();
    }

    private void PlayAnimation(string animationName, bool isLoop)
    {
        myAnimator.Play(animationName, 0, 0);
        StartCoroutine(WaitTime(myAnimator.GetCurrentAnimatorStateInfo(0).length));
    }

    public void AddAnimation(string animationName, bool isLoop)
    {
        animationQueue.Add(animationName);
        animationLoopStatus.Add(isLoop);
        if(isPlayingAnimation == false)
        {
            PlayAnimation(animationQueue[0], animationLoopStatus[0]);
        }
    }

    public void SkipAnimation()
    {
        animationQueue.Remove(animationQueue[0]);
        animationLoopStatus.Remove(animationLoopStatus[0]);
        if(animationQueue.Count > 0)
        {
            PlayAnimation(animationQueue[0], animationLoopStatus[0]);
        }
        else
        {
            myAnimator.enabled = false;
            myAnimator.enabled = true;
        }
    }

    private IEnumerator WaitTime(float waitTime)
    {
        isPlayingAnimation = true;
        yield return new WaitForSeconds(waitTime);
        isPlayingAnimation = false;

        if(animationLoopStatus[0] == true)
        {
            PlayAnimation(animationQueue[0], true);
        }
        else
        {
            animationQueue.Remove(animationQueue[0]);
            animationLoopStatus.Remove(animationLoopStatus[0]);
            if(animationQueue.Count > 0)
            {
                PlayAnimation(animationQueue[0], animationLoopStatus[0]);
            }

        }
    }
}
