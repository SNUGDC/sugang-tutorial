using UnityEngine;
using System;
using System.Collections.Generic;

public class SubjectDataParser : MonoBehaviour 
{
    public TextAsset subjectData;

    public List<Subject> Parse()
    {
        List<Subject> subjectList = new List<Subject>();
        string src = subjectData.text;
        string[] lines = src.Split(new [] { '\r', '\n' });
        
        for (int i=0; i<lines.Length; i++)
        {
            try
            {
                string[] datas = lines[i].Split(';');                
                Subject newSubject = new Subject();
                
                int category;
                switch(datas[0])
                {
                    case "전필":
                        category = 0;
                    break;
                    case "전선":
                        category = 1;
                    break;
                    case "교양":
                        category = 3;
                    break;
                    default:
                        category = 2;
                    break;
                }
                newSubject.category = (Subject.Category)category;
                
                newSubject.department = datas[1];
                
                newSubject.code = datas[3];
                
                newSubject.code = datas[4];
                
                newSubject.name = datas[5];
                
                newSubject.capacity = int.Parse(datas[10]);
                
                subjectList.Add(newSubject);
            }
            catch
            {
                continue;
            }
        }
        
        return subjectList;
    }
}
