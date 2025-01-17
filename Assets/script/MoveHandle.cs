using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
public class MoveHandle : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;
    private AudioSource audioSource;
    [SerializeField] private AudioClip lowerSE;
    private float movetime = 0.8f;
    [SerializeField] private Material elevator_cabin;
    [SerializeField] private GameObject ele_light;
    public bool electricity = false;//ハンドルを回して、電力を復旧させたらtrueにする
    [SerializeField] private AudioSource audioSE;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //emissionをオフ
        elevator_cabin.DisableKeyword("_EMISSION");
        ele_light.SetActive(false);
    }
    public void LowerHandle()//ハンドルを回すとエレベーター
    {
        //elevatorのライトをオンにする
        elevator_cabin.EnableKeyword("_EMISSION");
        ele_light.SetActive(true);
        this.transform.DOLocalRotate((_rotation), movetime);
        audioSource.PlayOneShot(lowerSE);
        StartCoroutine("EventSECoturine");
        electricity = true;
        this.tag = "Untagged";
    }
    private IEnumerator EventSECoturine()
    {
        yield return new WaitForSeconds(movetime);
        audioSE.Play();
    }
}
