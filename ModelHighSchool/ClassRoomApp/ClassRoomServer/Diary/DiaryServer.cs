using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassRoomApp.SchoolRepository;
using DiaryLib;


namespace ClassRoomServer.Diarys
{
       
    public class DiaryServer
    {
        public List<ClassroomInfo> CLRoomInfo { get; set; }
        public StudentDiary StudentDiaryObj { get; set; }

        public string DiaryInterface { get; set; }

        DiaryServer (string _interface)
        {
            DiaryInterface = _interface;
            
        }

        public void InitializeComponets()
        {
            
            StudentDiary _studentDiaryObj = new StudentDiary();
            StudentDiaryObj = _studentDiaryObj;

            BuildClassroomInfo();
        }

        private void BuildClassroomInfo()
        {
            //StudentDiaryObj;
        }


    }
}
