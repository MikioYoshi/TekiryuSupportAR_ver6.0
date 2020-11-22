using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class vbAction : MonoBehaviour, IVirtualButtonEventHandler
{
    //バーチャルボタン
    private GameObject vbBtnObj;

    //カラースフィアー
    public GameObject colorSphere;

    //ページ数
    public GameObject pageNm;

    //残す粒数を示すテキスト
    public GameObject howToText_1;

    //摘粒説明文_1
    public GameObject howToText_2;

    //摘粒説明文_2
    public GameObject howToText_3;

    //摘粒対象の粒のイラストの配置場所
    public UnityEngine.UI.Image pluckImg_1;

    //残す粒のイラストの配置場所
    public UnityEngine.UI.Image pluckImg_2;

    //摘粒対象の粒のイラストの配列
    public Sprite[] howToImg_1 = null;

    //残す粒のイラストの配列
    public Sprite[] howToImg_2 = null;

    //残す粒数の配列
    private int[] grainNm = { 4, 3, 2, 1 };

    //ページ数の配列
    private int[] pageNms = { 1, 2, 3, 4 };

    //摘粒対象のテキストの配列
    private string[] howTo_1 = { "下向き、内向き", "上下向き、内向き", "上下向き、内向き", "上向き" };

    //残す粒のテキストの配列
    private string[] howTo_2 = { "上向き", "横向き", "横向き", "下向き" };

    //キューブのマテリアルをシリアライズ化
    [SerializeField] Material[] materials = null;

    private int colorNm = 0;
    private int countNm = 0;

    // Start is called before the first frame update
    void Start()
    {
        vbBtnObj = GameObject.Find("VbBtn");
        vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {

        colorNm = (colorNm + 1) % materials.Length;

        //ColorSphereのマテリアルを変える
        colorSphere.GetComponent<Renderer>().material = materials[colorNm];

        if (countNm < 3)
        {
            countNm += 1;
        }
        else
        {
            countNm = 0;
        }

        //countNmに対応してそれぞれのページのテキスト、イラストに差し替える
        pluckImg_1.sprite = howToImg_1[countNm];
        pluckImg_2.sprite = howToImg_2[countNm];
        howToText_1.GetComponent<Text>().text = $"一段に残す粒数[{grainNm[countNm]}]";
        pageNm.GetComponent<Text>().text = pageNms[countNm] + " / 4";
        howToText_2.GetComponent<Text>().text = howTo_1[countNm] + "の粒を摘粒";
        howToText_3.GetComponent<Text>().text = howTo_2[countNm] + "の粒を残す";


    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
    }
}
