using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IStatisticsService
    {
        int GetCategoryCount();
        int GetHeadingCountByCategoryName(string categoryName);
        int GetWritersWithA(string a);
        string GetCategoryWithMostHeadings();
        int DifferenceStatusCategory();
    }
}
