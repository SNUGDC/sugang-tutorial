using System.Collections.Generic;
using UnityEngine;

public static class SiteInfo
{
    static Dictionary<string, int> sites = new Dictionary<string, int>
    {
        {"http://sugang.snu.ac.kr/", 1},
        {"http://my.snu.ac.kr/", 2}
    };
    
    public static int Search(string addressStr)
    {   
        if (!sites.ContainsKey(addressStr))
            return 0;
        
        return sites[addressStr];
    }
}
