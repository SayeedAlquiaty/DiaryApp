using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DiaryApp.ViewModel;
using System.Collections.ObjectModel;
using DiaryApp.Model;

namespace DiaryApp.ViewModel
{
    
    class TeacherDiaryPresenter : DiaryPresenter
    {
        private ServerConnector _serverConnect;
        public string DiaryNotes { get; set; }

        

        public ObservableCollection<CheckedListItem<String>> ClassroomList { get; set; }
        private CheckedListItem<String> _selectedClassroom;// = new List<CheckedListItem<string>>();
        public CheckedListItem<String> SelectedClassroom
        {
            get { return _selectedClassroom; }
            set
            {
                _selectedClassroom = value;
                RaisePropertyChangedEvent("SelectedClass");
            }
        }
        public void SelectedClass()
        {
            int index = ClassroomList.IndexOf(SelectedClassroom);
            ClassroomList.RemoveAt(index);
            ClassroomList.Insert(index, SelectedClassroom);
        }
        public ObservableCollection<CheckedListItem<String>> CStudentList { get; set; }
        private CheckedListItem<String> _selectedCStudent;
        public CheckedListItem<String> SelectedCStudent
        {
            get { return _selectedCStudent; }
            set
            {
                _selectedCStudent = value;
                RaisePropertyChangedEvent("SelectedStudent");
            }
        }
        private void SelectedStudent()
        {
        }
        public TeacherDiaryPresenter()
        {
            ObservableCollection<CheckedListItem<String>> CRList = new ObservableCollection<CheckedListItem<string>>();
            CRList.Add(new CheckedListItem<string>("Class1A",true));
            CRList.Add(new CheckedListItem<string>("Class1B"));
            CRList.Add(new CheckedListItem<string>("Class2A"));
            CRList.Add(new CheckedListItem<string>("Class2B"));
            CRList.Add(new CheckedListItem<string>("Class3A"));
            CRList.Add(new CheckedListItem<string>("Class3B"));
            CRList.Add(new CheckedListItem<string>("Class4A"));
            CRList.Add(new CheckedListItem<string>("Class4B"));
            CRList.Add(new CheckedListItem<string>("Class5A"));
            CRList.Add(new CheckedListItem<string>("Class5B"));
            CRList.Add(new CheckedListItem<string>("Class6A"));
            CRList.Add(new CheckedListItem<string>("Class6B"));
            CRList.Add(new CheckedListItem<string>("Class7A"));
            CRList.Add(new CheckedListItem<string>("Class7B"));
            CRList.Add(new CheckedListItem<string>("Class8A"));
            CRList.Add(new CheckedListItem<string>("Class8B"));
            CRList.Add(new CheckedListItem<string>("Class9A"));
            CRList.Add(new CheckedListItem<string>("Class9B"));
            CRList.Add(new CheckedListItem<string>("Class10A"));
            CRList.Add(new CheckedListItem<string>("Class10B"));

            ClassroomList = CRList;
            _serverConnect = new ServerConnector();
            Thread.Sleep(1000);
            _serverConnect.TeacherDiary();

        }
    }
}
