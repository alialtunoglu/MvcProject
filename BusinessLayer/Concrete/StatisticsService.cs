using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class StatisticsService:IStatisticsService
    {
        public ICategoryDal _categoryDal;
        public IHeadingDal _headingDal;
        public IWriterDal _writerDal;

        public StatisticsService(ICategoryDal categoryDal, IHeadingDal headingDal,IWriterDal writerDal)
        {
            _categoryDal = categoryDal;
            _headingDal = headingDal;
            _writerDal = writerDal;
        }

        public int DifferenceStatusCategory()
        {
            int trueCount = _categoryDal.List(x => x.CategoryStatus == true).Count;
            int falseCount = _categoryDal.List(x => x.CategoryStatus == false).Count;
            return Math.Abs( trueCount - falseCount);
        }

        public int GetCategoryCount()
        {
            return _categoryDal.List().Count;
        }

        public string GetCategoryWithMostHeadings()
        {
            return _headingDal.List().Max(x => x.Category.CategoryName);
        }

        public int GetHeadingCountByCategoryName(string categoryName)
        {
            return _headingDal.List(x => x.Category.CategoryName == categoryName).Count;
        }

        public int GetWritersWithA(string a)
        {
            return _writerDal.List(x => x.WriterName.Contains(a)).Count;
        }
       
    }
}
