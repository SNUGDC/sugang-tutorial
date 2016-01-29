public class Subject 
{
    public enum Category
    {
        MajorRequisite, MajorSelect, Normal, LibArt1, LibArt2, LibArt3, LibArt4, LibArt5, LibArt6, LibArt7, LibArt8
    }
    
    public string subjectName;  //강좌명
    public string subjectCode;  //강좌코드
    public int units;   //이수학점
    public Category category;   //강좌종류(전선,전필,일선,핵교 등)
    public string college;  //단과대학
    public string department;   //개설학과
    public bool isMajorOnly = false;    //전공생 수강제한 여부
    public bool isMajorExcluded = false;    //전공생 수강금지 여부
    public bool isNewbieFirst = false;  //1학년 우선신청 여부
    public string otherInfo;    //기타 임시용 필드
}