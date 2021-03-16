using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public abstract class FolderSystem : MonoBehaviour
{
    protected List<string> foldersPath;
    protected List<string> foldersName  = new List<string>();
    private List<string> list;
    protected string prevPath;
    protected bool isFolder = true;
    protected bool isFile = false;
    protected bool isImage = false;
    protected int clicked;
    protected string currentDirect;

    //Need to get the folder location
    protected void inializeMain(string targetDirectory)
    {
        collectFoldersName(targetDirectory);
        collectFoldersPath(targetDirectory);   
    }

    //Doesn't need an if statement for if its in a folder or not because you can never mix excel and folder together
    //And you can never go from excel to an excel; only folder to excel, or excel to folder
    protected void directoryGoback()
    {
        string targetDirectory;
            if((foldersPath== null) || (foldersPath.Count == 0))
            {
                targetDirectory = prevPath;
            // Debug.Log("inside folder with photos: path = " + targetDirectory);
                targetDirectory = trimPathString(targetDirectory,1);
            }
            else
            {
                targetDirectory = foldersPath[0];
                //Debug.Log("inside folder with no photos: path = " + targetDirectory);
                targetDirectory = trimPathString(targetDirectory,2);
            }
            collectFoldersPath(targetDirectory);
            collectFoldersName(targetDirectory);

    }

    //Go back to the previous directory when coming out of a file
    protected void directoryFileGoBack(string targetDirectory)
    {
        targetDirectory = trimPathString(targetDirectory,1);
        collectFoldersPath(targetDirectory);
        collectFoldersName(targetDirectory);
    }

    protected void collectFoldersPath(string targetDirectory)
    {
        string [] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
        foldersPath = new List<string>();
        foreach(string subdirectory in subdirectoryEntries)
        {
            foldersPath.Add(subdirectory);
            //Debug.Log(subdirectory);
        }

        if((foldersPath== null)|| (foldersPath.Count == 0)) //There is no path if there is no folder only file
        {
            prevPath = targetDirectory;
        }
    }

    protected void collectFoldersName(string targetDirectory)
    {
        foldersName = new List<string>();
        string [] fileEntries = Directory.GetFiles(targetDirectory);
        foreach(string fileName in fileEntries)
        {
            foldersName.Add(fileName);
            //Debug.Log(fileName);
        }

        if(foldersName.Count == 0) //Your in a void (nothing is inside the folder)
        {
            directoryGoback(); //Got to go back to get out of the void directory
        }
        else
        {
            checkFolderType(foldersName[0]); //only need to check the frist because everything MUST be the same type
        }
        
        currentDirect = targetDirectory;
    }

    protected void checkFolderType(string fileName)
    {
        if(fileName.Contains(".meta"))
        {
            isFolder = true;
            isFile = false;
            isImage = false;
        }
        else if(fileName.Contains(".csv"))
        {
            isFolder = false;
            isFile = true;
            isImage = false;
        }
        else if(fileName.Contains(".PNG") || fileName.Contains(".png") ||fileName.Contains(".JPG") || fileName.Contains(".jpg") )
        {
            isFolder = false;
            isFile = false;
            isImage = true;
        }
        else
        {
            isFolder = false;
            isFile = false;
            isImage = false;
        }
    }

    //File name will contain two types a .meta and imagetype.meta
    //Must remove .meta files for display leaving on the image type
    //String index is for example: "SciGallery\\"
    protected void cleanFolderPathForImages(string targetDirectory, string stringIndex)
    {
        list = new List<string>();
        foldersName = new List<string>();
        string [] fileEntries = Directory.GetFiles(targetDirectory);
        foreach(string fileName in fileEntries)
        {
            if(fileName.Contains(".meta")){}
            else{
                list .Add(fileName);
                //Debug.Log(fileName);
            }
        }

        string [] array = list.ConvertAll( list => list.ToString() ).ToArray();
        //Debug.Log(array[0]);

        //Cut the image type and add it to foldersName
        foreach(string fileName in array)
        {
            string temp = fileName;
            int pos = temp.IndexOf(".");
            temp = temp.Remove(pos);
            int pos1 = temp.IndexOf(stringIndex);
            temp = temp.Remove(0,pos1);
            temp = temp.Replace("\\","/");
            foldersName.Add(temp);
            //Debug.Log(temp);
        }
    }

    //Will trim it down removing the path and the type
    private string trimPathString(string targetDirectory, int cut)
    {
        char[] charArr = new char[targetDirectory.Length];
        charArr = targetDirectory.ToCharArray();
        List<int> counter = new List<int>();
        int i = 0;
        foreach (char c in charArr)
        {
            if(c == '\\')
            {
                counter.Add(i); // Stores the position of the "\"
            }
            i = i + 1;
        }

        char[] newCharArr = new char[counter[counter.Count-cut]];
        i = 0;
        foreach(char c in charArr)
        {
            if(i>=newCharArr.Length)
            {
                break;
            }
            newCharArr[i] = c;
            i = i + 1;
        }
        targetDirectory = new string(newCharArr);
        //Debug.Log("New Path " + targetDirectory);
        return targetDirectory;
    }

    //Gets rid of the path for the name
    public List<string> trimNameStringFromBackSlash(List<string> name)
    {
        List<string> newName = new List<string>();
        for(int k = 0; k<name.Count;k++)
        {

        char[] charArr = new char[name[k].Length];
        charArr = name[k].ToCharArray();
        List<int> counter = new List<int>();
        int i = 0;
        foreach (char c in charArr)
        {
            if(c == '\\')
            {
                counter.Add(i); // Stores the position of the "\"
            }
            i = i + 1;
        }

        int end = name[k].Length - counter[counter.Count-1];
        char[] newCharArr = new char[end];
        i = 0;
        int j = 0;
        foreach(char c in charArr)
        {
            if(i>counter[counter.Count-1])
            {
                newCharArr[j] = c;
                j = j+1;
            }
            
            i = i + 1;
        }
        newName.Add(new string(newCharArr));
    }
        return newName;
    }


    public List<string> trimNameStringFromForwardSlash(List<string> name)
    {
        List<string> newName = new List<string>();
        for(int k = 0; k<name.Count;k++)
        {

        char[] charArr = new char[name[k].Length];
        charArr = name[k].ToCharArray();
        List<int> counter = new List<int>();
        int i = 0;
        foreach (char c in charArr)
        {
            if(c == '/')
            {
                counter.Add(i); // Stores the position of the "\"
            }
            i = i + 1;
        }

        int end = name[k].Length - counter[counter.Count-1];
        char[] newCharArr = new char[end];
        i = 0;
        int j = 0;
        foreach(char c in charArr)
        {
            if(i>counter[counter.Count-1])
            {
                newCharArr[j] = c;
                j = j+1;
            }
            
            i = i + 1;
        }
        newName.Add(new string(newCharArr));
    }
        return newName;
    }

    public bool getIsFolder()
    {
        return isFolder;
    }

    public bool getIsFile()
    {
        return isFile;
    }

       public bool getIsImage()
    {
        return isImage;
    }

    public int getLength()
    {
        return foldersName.Count; //Use foldersName because path can be null if no folders
    }

    public string getDirectory()
    {
        return currentDirect;
    }
}
