using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Quartz.netLesson8Core
{
    public class SchedulerConfigurationService
    {

        private static string _dataFileBase = Directory.GetCurrentDirectory();




        public SchedulersModel GetData()
        {

          
            //if (_dataFileBase[_dataFileBase.Length - 1] != '\\' && _dataFileBase[_dataFileBase.Length - 1] != '/')
            //{
            //    _dataFileBase = _dataFileBase + "\\";
            //}
            if (_dataFileBase.Contains("\\")|| _dataFileBase.Contains(@"\"))
            {
                _dataFileBase += "\\";
            }
            if (_dataFileBase.Contains("/") || _dataFileBase.Contains("//"))
            {
                _dataFileBase += "/";
            }
           
            var fileUrl = _dataFileBase + "QuartzSchedulerConfiguration.json";
            Console.WriteLine(fileUrl);
            return JsonConvert.DeserializeObject<SchedulersModel>(File.ReadAllText(fileUrl));
        }
    }
    public class SchedulersModel
    {
        public int ThreadCount { get; set; }
        public  List<JobModel> Jobs { get; set; }
    }

    public class JobModel
    {
        public string JobName { get; set; }
        public string GroupName { get; set; }
        public string CronExpression { get; set; }
    }




}
