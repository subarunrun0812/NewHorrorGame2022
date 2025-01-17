using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
public class NormalDoor : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip openSE;
    [SerializeField] private AudioClip closeSE;
    private bool OpenFlag;
    [Header("基本は-120度")]
    [SerializeField] private int y_rotation;
    void Start()
    {
        //doorが閉まっているときはtrue
        OpenFlag = true;
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    public void IsNearNormalDoor()
    {

        if (OpenFlag == true)//ドアを開けるとき
        {
            this.transform.DOLocalRotate(new Vector3(0, y_rotation, 0), 1.6f);
            OpenFlag = false;
            audioSource.PlayOneShot(openSE);

        }
        else//ドアを閉めるとき
        {
            CloseDoor();
        }
    }
    public void CloseDoor()
    {
        this.transform.DOLocalRotate(new Vector3(0, 0, 0), 1.0f);
        OpenFlag = true;
        audioSource.PlayOneShot(closeSE);
    }

}

