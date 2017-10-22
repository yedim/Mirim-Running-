using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {


    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;

    private float platformWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

   // public GameObject[] thePlatforms;
    private int platformSelector;
    private float[] platformWidths;

   public ObjectPooler[] theObjectPools;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

    private CoinGenerator theCoinGenerator;
    public float randomCoinThreshold;

    public float randomSpikeThreshold;
    public ObjectPooler spikePool;

    public List<ObjectPooler> spikePoolList; //원하는 오브젝트들을 담는다.

    public ObjectPooler Teacher;
    public GameObject Player;

    public int block_cnt = 0;
    public int teacherAppear = 0; //언제나타나는지(블록 몇개 지난후에 선생님 나오는지(랜덤임))

    public List<Teacher> TeacherScript = new List<Teacher>();


    // Use this for initialization
    void Start () {
        // platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
        platformWidths = new float[theObjectPools.Length];

        for(int i=0; i< theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        theCoinGenerator = FindObjectOfType<CoinGenerator>();

        Player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update () {
		
        if(transform.position.x < generationPoint.position.x) // generationPoint에 도달하면 새로운 platform생성
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            platformSelector = Random.Range(0, theObjectPools.Length);
            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if(heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
            else if(heightChange < minHeight)
            {
                heightChange = minHeight;
            }
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector]/2) + distanceBetween,heightChange, transform.position.z);


            //Instantiate(/*thePlatform*/ thePlatforms[platformSelector], transform.position, transform.rotation);

            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            if(Random.Range(0f, 100f)<randomCoinThreshold)
            {
                //여기서 호출
                theCoinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z)); //Platform위에 코인생성
            }

            if (Random.Range(0f, 100f) < randomSpikeThreshold)
            {
                int RandomIndex = 0;

                if(transform.position.x<100){
                    RandomIndex = Random.Range(1, 5);
                }
                else if(100 <transform.position.x && transform.position.x < 200){
                    RandomIndex = Random.Range(5, 8);
                }
                else if (200 < transform.position.x && transform.position.x < 300){
                    RandomIndex = Random.Range(8, 12);
                }


                //GameObject newSpike = spikePool.GetPooledObject();
                GameObject newSpike = spikePoolList[RandomIndex].GetPooledObject();

                float spikeXPoisition = Random.Range(-platformWidths[platformSelector]/2f + 1f, platformWidths[platformSelector] / 2f-1f);
                Vector3 spikePosition = new Vector3(spikeXPoisition, newSpike.transform.position.y+4f, 0f);//장애물위치

                newSpike.transform.position = transform.position+spikePosition;
                newSpike.transform.rotation = transform.rotation;
                newSpike.SetActive(true);
            }


                transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) , transform.position.y, transform.position.z);
                 block_cnt++;

        }
        if (block_cnt == (int)Random.Range(teacherAppear, teacherAppear + 5))
        {

            GameObject newTeacher = Teacher.GetPooledObject();

            newTeacher.transform.position = new Vector3(16.3f + transform.position.x, -4f, 5);
            newTeacher.transform.rotation = transform.rotation;
            newTeacher.SetActive(true);

            block_cnt = 0;
            teacherAppear = Random.Range(0, 15);

            TeacherScript.Add(newTeacher.GetComponent<Teacher>());
        }

        //인사처리
        for (int i = 0; i < TeacherScript.Count; i++)
        {
            if (Player.transform.position.x + 20 >= TeacherScript[i].gameObject.transform.position.x && TeacherScript[i].isGreet == false)//일정거리오고 인사아직안했을때
            {
                if (Player.GetComponent<PlayerController>().greet)//인사 했을때(선생님 표정바뀌고 인사처리 isGreet)
                {
                    TeacherScript[i].GetComponent<Teacher>().Imgname = "teacher_happy";
                    TeacherScript[i].isGreet = true;
                }
                else
                    TeacherScript[i].GetComponent<Teacher>().Imgname = "teacher_find";//학생발견(선생님 표정바뀜)

                TeacherImageChange(TeacherScript[i].gameObject);
            }
            if (Player.transform.position.x >= TeacherScript[i].gameObject.transform.position.x && TeacherScript[i].isGreet == false)//인사안했을때(화난표정)
            {
                TeacherScript[i].GetComponent<Teacher>().Imgname = "teacher_angry";
                TeacherImageChange(TeacherScript[i].gameObject);
            }
            if (Player.transform.position.x - 20 > TeacherScript[i].gameObject.transform.position.x)//화면에서 사라지면 초기화
            {
                TeacherScript[i].GetComponent<Teacher>().Imgname = "teacher_normal";
                TeacherImageChange(TeacherScript[i].gameObject);
                TeacherScript[i].isGreet = false;
            }
        }
    }
    public void TeacherImageChange(GameObject tec)
    {
        tec.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(tec.GetComponent<Teacher>().Imgname) as Sprite;
    }
}
