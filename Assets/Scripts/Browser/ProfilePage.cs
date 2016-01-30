using UnityEngine;
using UnityEngine.UI;

public class ProfilePage : MonoBehaviour 
{
    public Text SummaryText;
    public Text Major1Text;
    public Text Major2Text;
    public Text LibArtText;
    public Text NormalText;
    MyUnivData playerData;
    
    void OnEnable()
    {
        string major1Name = playerData.major;
        string major2Name = playerData.secondaryMajor;
        
        string summaryStr = "요약: ";
        string major1Str = "전공: ";
        string major2Str = "";
        string libArtStr = "\n교양: ";
        string normalStr = "\n일반선택: ";
        int major1Unit = 0;
        int major2Unit = 0;
        int libArtUnit = 0;
        int totalUnit = 0;
        bool is2Majored = string.IsNullOrEmpty(playerData.secondaryMajor);
        
        foreach (Subject item in playerData.finishedSubjects)
        {
            int category = (int)item.category;
            
            if (category < 2 && item.department.Equals(major1Name))
            {
                major1Str += item.name + ", ";
                major1Unit += item.units;
            }
            else if (is2Majored && category < 2 && item.department.Equals(major2Name))
            {
                major2Str += item.name + ", ";
                major2Unit += item.units;
            }
            else if (category > 2)
            {
                libArtStr += item.name + ", ";
                libArtUnit += item.units;
            }
            else
            {
                normalStr += item.name + ", ";
                totalUnit += item.units;
            }
        }
        
        summaryStr += "전공 - " + major1Unit.ToString() + "학점, ";
        if (is2Majored)
            summaryStr += "제2전공 - " + major2Unit.ToString() + "학점, ";
        summaryStr += "교양 - " + libArtUnit.ToString() + "학점, ";
        summaryStr += "총 " + totalUnit.ToString() + "학점";
        string res = major1Str + major2Str + libArtStr + normalStr;
    }
}
