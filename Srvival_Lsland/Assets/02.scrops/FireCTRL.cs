using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCTRL : MonoBehaviour
{
    [Header("���۳�Ʈ��")]
    // �Ѿ� ������Ʈ
    public GameObject bulletPrefab;
    public Transform FirePos;
    // �߻� ��ġ
    public Animation fireAni;
    public AudioSource source;
    public AudioClip fireclip;
    public ParticleSystem muzzleFlash;
    [Header("���� ������")]
    private float fireTime;
    public HandCtrl handCtrl;
    // Start is called before the first frame update
    void Start()
    {
        handCtrl = this.gameObject.GetComponent<HandCtrl>();
        fireTime = Time.time;
        muzzleFlash.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        #region �ѹ߾� �߻��ϴ� ����
        // ���콺 ���� ��ư ������ �� 0
        // 1 ��  ������ 2�� ���콺 �ٹ�ư
        //if (Input.GetMouseButtonDown(0))
        //    Fire();
        #endregion
        #region �Ѿ� �߻縦 ����� �ϴ� ����
        if (Input.GetMouseButton(0))
        {
            if (Time.time - fireTime > 0.1f)
            {
                if(handCtrl.isRun==false)
                Fire();
                fireTime = Time.time;
                
            }
        }
        #endregion
        // ���콺 ���� ��ư�� ��������
        if (Input.GetMouseButtonUp(0)) 
        {
            muzzleFlash.Stop();
        }
    }
    void Fire() // �Ѿ� �߻� �Լ�
    {   // ������Ʈ ���� �Լ�
        Instantiate(bulletPrefab, FirePos.position,
            FirePos.rotation);
        source.PlayOneShot(fireclip,1.0f);
        fireAni.Play("fire");
        muzzleFlash.Play();
    }
}
