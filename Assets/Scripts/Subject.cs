public class Subject 
{
    public enum Category
    {
        MajorRequisite, MajorSelect, Normal, LibArt1, LibArt2, LibArt3, LibArt4, LibArt5, LibArt6, LibArt7, LibArt8
    }
    public enum Day
    {
        Monday, Tuesday, Wednesday, Thursday, Friday
    }
    
    public int number = 1;
    public string name;  //강좌명
    public string code;  //강좌코드
    public int units;   //이수학점
    
    public struct PeriodInfo
    {
        public Day day;
        public int period;
        public int length;
        
        public override string ToString()
        {
            string res;
            switch(day)
            {
                case Day.Monday:
                    res = "월";
                break;
                case Day.Tuesday:
                    res = "화";
                break;
                case Day.Wednesday:
                    res = "수";
                break;
                case Day.Thursday:
                    res = "목";
                break;
                case Day.Friday:
                    res = "금";
                break;
                default:
                    res = "";
                break;
            }
            string startTime = (period + 8).ToString("00") + ":00";
            string endTime = (period + length + 8).ToString("00") + ":50";
            res += "(" + startTime + "~" + endTime + ")"; 
            return res;
        }
    }
    public PeriodInfo[] periodInfo;   //교시
    public Category category;   //강좌종류(전선,전필,일선,핵교 등)
    public string college;  //단과대학
    public string department;   //개설학과
    public bool isMajorOnly = false;    //전공생 수강제한 여부
    public bool isMajorExcluded = false;    //전공생 수강금지 여부
    public bool isNewbieFirst = false;  //1학년 우선신청 여부
    public string others;    //기타 임시용 필드
    public int currentStudent = 0;
    public int capacity;
}