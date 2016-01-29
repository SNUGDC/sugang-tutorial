using UnityEngine;
using UnityEngine.UI;

public class SubjectDisplayer : MonoBehaviour 
{
    public Text nameText;
    public Text numberText;
    public Text codeText;
    public Text unitText;
    public Text periodText;
    public Text categoryText;
    public Text collegeText;
    public Text departmentText;
    public Text infoText;
    public Text currentText;
    public Text capacityText;
    
    public void ShowSubject(Subject target)
    {
        nameText.text = target.name;
        numberText.text = target.number.ToString("000");
        codeText.text = target.code;
        unitText.text = target.units.ToString();
        collegeText.text = target.college;
        departmentText.text = target.department;
        currentText.text = target.currentStudent.ToString();
        capacityText.text = target.capacity.ToString();
        
        string category = "";
        switch(target.category)
        {
            case Subject.Category.MajorRequisite:
                category = "전필";
            break;
            case Subject.Category.MajorSelect:
                category = "전선";
            break;  
            case Subject.Category.Normal:
                category = "일선";
            break;
            default:
                category = "교양";
            break;   
        }
        categoryText.text = category;
        
        string period = "";
        for (int i=0; i<target.periodInfo.Length; i++)
        {
            period += target.periodInfo[i].ToString();
            if (i < target.periodInfo.Length - 1)
                period += "\n";
        }
        periodText.text = period;
        
        string info = "";
        if (target.isMajorOnly)
            info = target.department + "주전공및제2전공만 수강가능";
        else if (target.isMajorExcluded)
            info = target.department + "주전공및제2전공 수강불허";
        infoText.text = info;
    }
}
