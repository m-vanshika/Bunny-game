using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Start is called before the first frame update
  public  List<LevelBlock> legoBlocks=new List<LevelBlock>();
    List<LevelBlock> currentBlocks=new List<LevelBlock>();
    public Transform initialPoint;
    private static LevelGenerator _sharedInstance;
    public byte initialBlockNumber=2;
    public static LevelGenerator sharedInstance
    {
        get
        {
            return _sharedInstance;
        }
    }
    private void Awake()
    {
        _sharedInstance=this;
        CreateInitialBlocks();
       
    }
    public void CreateInitialBlocks()
    {
        if(currentBlocks.Count>0)
        {
            return;
        }
         for (int i = 0; i < initialBlockNumber; i++)
        {
            AddNewBlock(true);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddNewBlock(bool initialBlocks=false)
    {
        int randNum=initialBlocks?0:Random.Range(0,legoBlocks.Count);
        var block=Instantiate(legoBlocks[randNum]);
        block.transform.SetParent(transform);
        Vector3 blockPosition=Vector3.zero;
        if(currentBlocks.Count==0)
        {
            blockPosition=initialPoint.position;
        }
        else
        {
            int lastBlockPos=currentBlocks.Count-1;
            blockPosition=currentBlocks[lastBlockPos].exitPoint.position;
        }
        block.transform.position=blockPosition;
        currentBlocks.Add(block);
    }
    public void RemoveOldBlock()
    {
        var oldBlock=currentBlocks[0];
        currentBlocks.Remove(oldBlock);
        Destroy(oldBlock.gameObject);
    }
    
    public void RemoveAllBlocks()
    {
        while (currentBlocks.Count>0)
        {
            RemoveOldBlock();
        }
    }
}
