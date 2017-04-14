using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public enum ForceType
    {
        Point = 1, //1
        LevelI = 2, //1
        Lance = 3, //4,
        Star = 4,
        AugmentedLance = 5, //6
        AirLance = 6, //6
        LevelII = 7, //6
        Nova = 8, //10
        Binary = 9, //10
        Company = 10, //12+  
        AugmentedCompany = 11, //12+
        Trinary = 12, //15
        CompanyTaskForce = 13, //18-24
        SuperNova = 14, //20
        SuperNovaTrinary = 15, //30        
        Cluster = 16, //30-90
        LevelIII = 17, //36
        Battalion = 18, //36+
        AugmentedBattalion = 19, //48+
        SquareBattalion = 20, //48+
        Regiment, //108-240
        AugmentedRegiment, //120-240
    }
}
