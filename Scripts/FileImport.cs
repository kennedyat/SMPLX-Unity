using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Linq;
using UnityEditor;

public class FileImport : MonoBehaviour
{
    /*[FolderPath]
    public string UnityProjectPath;

    [FolderPath(AbsolutePath = true)]
    public string AbsolutePath;*/

    [SerializeField] TextAsset betaFile;
    [SerializeField] 
    public List<TextAsset> poseFile;// should take folder
    //[SerializeField] TextAsset poseFile;
    [SerializeField]
    public string[] betaArray;
    InputField iField;
    private string key;
    public bool animate=false;
    // [InspectoButton("OnButtonClicked")]

    [SerializeField]
    public bool addAnimation;
    [SerializeField]
    //public Dictionary<string, List<TextAsset>> assignKey;


    public string prevKey;

    public List<string> poseArray;
    public List<string> motionArray;//public string[] poseArray;
    public List<string> paths;
    public List<string> movement;

    

    //[SerializeField] TextAsset animationFile;

    // Start is called before the first frame update
    [Serializable]
    public struct Animator
    {
        public string key;
        public List<TextAsset> assignKey;
    }
    public List<Animator> assignKey;

    void Start()
    {
        List<Animator> assignKeys = new List<Animator>();
        //var anim = new Animator;
       // for(i in )
        poseArray.Clear();
        paths = Directory.EnumerateFiles(@"C:\Users\ktpen\Downloads\run\run", "*.txt").ToList();
        movement = Directory.EnumerateFiles(@"C:\Users\ktpen\Downloads\run\run_trans", "*.txt").ToList();//"C:\Users\ktpen\OneDrive\Desktop\SMPLX-Unity\Assets\SMPLX\Scripts\man_walking_2", "*.txt").ToList();
        prevKey = "Arrow";
         ReadBetaFile();
        ReadPoseFile();
        ReadTransformFile();


    }
    void Update()
    {
        //if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        //{
          //  transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f, 0f));



        //}
        //float h = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)&&prevKey=="Space")
        {
            poseArray.Clear();
            motionArray.Clear();
            paths = Directory.EnumerateFiles(@"C:\Users\ktpen\Downloads\run\run", "*.txt").ToList();
            movement = Directory.EnumerateFiles(@"C:\Users\ktpen\Downloads\run\run_trans", "*.txt").ToList();
            ReadPoseFile();
            ReadTransformFile();

            prevKey = "Arrow";
            // if (h > 0 && !facingRight)
            //     Flip();
            //  else if (h < 0 && facingRight)
            //    Flip();

        }
        if (Input.GetKey(KeyCode.Space)&&prevKey=="Arrow")
        {
            poseArray.Clear();
            motionArray.Clear();
            //paths = Directory.EnumerateFiles(@"C:\Users\ktpen\Downloads\actions\unity_jump\Pose", "*.txt").ToList();
            //movement = Directory.EnumerateFiles(@"C:\Users\ktpen\Downloads\actions\unity_jump\smplx_params", "*.txt").ToList();
            //paths = Directory.EnumerateFiles(@"C:\Users\ktpen\Downloads\jumping", "*.txt").ToList();
            //movement = Directory.EnumerateFiles(@"C:\Users\ktpen\Downloads\jump_v2\jump_v2", "*.txt").ToList();
            paths = Directory.EnumerateFiles(@"C:\Users\ktpen\Downloads\actions\unity_kick\Pose", "*.txt").ToList();
            movement = Directory.EnumerateFiles(@"C:\Users\ktpen\Downloads\actions\unity_kick\smplx_params", "*.txt").ToList();
            //paths = Directory.EnumerateFiles(@"C:\Users\ktpen\Downloads\actions\unity_punch\Pose", "*.txt").ToList();
            //movement = Directory.EnumerateFiles(@"C:\Users\ktpen\Downloads\actions\unity_punch\smplx_params", "*.txt").ToList();
            ReadPoseFile();
            ReadTransformFile();
            prevKey = "Space";
            // if (h > 0 && !facingRight)
            //     Flip();
            //  else if (h < 0 && facingRight)
            //    Flip();

        }




        /* for( int i = 0; i < assignKey.Count; i++)
         {
             paths.Add(assignKey[i].);
         }
             if (Input.GetKey(KeyCode.UpArrow && assignKey[i].key == "space"))

                 //key = "Up Arrow";
             else if (Input.GetKey(KeyCode.DownArrow))
                 key = "Down Arrow";
             else if (Input.GetKey(KeyCode.RightArrow))
                 key = "Right Arrow";
             else if (Input.GetKey(KeyCode.LeftArrow))
                 key = "Left Arrow";

             //print("here");
             //assignKey.Add(key, poseFile);

             //print(key);
             animate = false;*/


        /* if (animate)
         {
             if (Input.anyKeyDown)
             {
                 if (Input.GetKey(KeyCode.UpArrow))
                     key = "Up Arrow";
                 else if (Input.GetKey(KeyCode.DownArrow))
                     key = "Down Arrow";
                 else if (Input.GetKey(KeyCode.RightArrow))
                     key = "Right Arrow";
                 else if (Input.GetKey(KeyCode.LeftArrow))
                     key = "Left Arrow";

                 print("here");
                 //assignKey.Add(key, poseFile);

                 print(key);
                 animate = false;

             }
             //if (addAnimation)
             //  Animation();
             //ReadBetaFile();
             //ReadPoseFile();
         }*/
    }

 

    // Update is called once per frame

    public string[] ReadBetaFile()
    {
        //print("read file");
        betaArray = betaFile.text.Split(new string[] { "\n" }, StringSplitOptions.None);
        return betaArray;

    }
    public List<string> ReadPoseFile()
    {
        int i = 0;

        foreach (string file in paths)
        {
            string[] poses = File.ReadAllLines(file);

            poseArray.AddRange(poses.ToList()); //Adds extra? 
        }

        foreach(string pose in poseArray)
        {
            i++;
            //print(pose+"  Number: "+ i);
        }
        //print("read file");
        // poseArray = poseFile.text.Split(new string[] { "\n" }, StringSplitOptions.None);
        return poseArray;

    }
    public List<string> ReadTransformFile()
    {
        int i = 0;

        foreach (string file in movement)
        {
            string[] motion = File.ReadAllLines(file);

            motionArray.AddRange(motion.ToList()); //Adds extra? 
        }

        foreach (string move in motionArray)
        {
            i++;
            //print(move + "  Number: " + i);
        }
        //print("read file");
        // poseArray = poseFile.text.Split(new string[] { "\n" }, StringSplitOptions.None);
        return motionArray;

    }


    public void Animation()
    {
       //int i = 0;
        //key="helo ";
        animate = true;
        int i = 0;
        while (animate==true&& i<50)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                    key = "Up Arrow";
                else if (Input.GetKey(KeyCode.DownArrow))
                    key = "Down Arrow";
                else if (Input.GetKey(KeyCode.RightArrow))
                    key = "Right Arrow";
                else if (Input.GetKey(KeyCode.LeftArrow))
                    key = "Left Arrow";

                //print("here");
                //assignKey.Add(key, poseFile);

                //print(key);
                animate = false;

            }
            print(i);
            i++;
        }
        //Create two lists one for the key name second for the file and create another dictionary form this. each one correleates.
           // Update();
       // print(animate);
       // return animate;
        //bool statement = true;
      
        //TextAsset animFile=null;
        // key cases for up, down, left, right, space, enter
       
        
       // print("here");
       
        //print("key");
        //print(poseFile.Count);
       
        //return;

        //string keyName = Input.GetKey(KeyCode).toString();
        // assignKey(keyName, animationFile);
        //input key and add string to dictionary
        //Add button check if either key or file animation is null before adding.
    }
}
