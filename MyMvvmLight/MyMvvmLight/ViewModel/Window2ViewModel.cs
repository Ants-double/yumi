using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Threading;
using MyMvvmLight.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvvmLight.ViewModel
{
   public class Window2ViewModel : ViewModelBase
    {
        private Teacher _teacher;

        public Teacher Teacher
        {
            get
            {
                return _teacher;
            }
            set
            {
                _teacher = value;
                RaisePropertyChanged(() => Teacher);
            }
        }

        public RelayCommand ChangeTeacherNameCommand
        {
            get; set;
        }

        public RelayCommand AddStudentCommand
        {
            get; set;
        }

        public RelayCommand ChangeLastStudentNameCommand
        {
            get; set;
        }
        public Window2ViewModel()
        {
            Teacher = new Teacher()
            {
                Name = "LaoZhao",
                Age = 30,
                Students = new ObservableCollection<Student>()
            {
                new Student()
                {
                    Name="LaoZhange",
                    Age = 18
                }
            }
            };

            InitCommand();
        }
        private void InitCommand()
        {
            ChangeTeacherNameCommand = new RelayCommand(() =>
            {
                Task.Factory.StartNew(() =>
                {
                    Teacher.Name = "MaYun";
                });
            });

            //AddStudentCommand = new RelayCommand(() =>
            //{
            //    Task.Factory.StartNew(() =>
            //    {
            //        Teacher.Students.Add(new Student()
            //        {
            //            Name = "LaoLi",
            //            Age = 25
            //        });
            //    });
            //});
            AddStudentCommand = new RelayCommand(() =>
            {
                Task.Factory.StartNew(() =>
                {
                    DispatcherHelper.CheckBeginInvokeOnUI(() =>
                    {
                        Teacher.Students.Add(new Student()
                        {
                            Name = "LaoLi",
                            Age = 25
                        });
                    });
                });
            });

            ChangeLastStudentNameCommand = new RelayCommand(() =>
            {
                Task.Factory.StartNew(() =>
                {
                    var student = Teacher.Students.LastOrDefault();

                    if (student != null)
                    {
                        student.Name = "TheLast";
                    }
                });
            });
        }
    }
}
