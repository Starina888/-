using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TeacherInformationSystem.Models;
using System.Linq;

namespace TeacherInformationSystem
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Teacher> _teachers;
        private ObservableCollection<Chair> _chairs;
        private ObservableCollection<Faculty> _faculties;
        private ObservableCollection<Post> _posts;
        private ObservableCollection<object> _data;
        private object _selectedItem;

        public ObservableCollection<Teacher> Teachers
        {
            get { return _teachers; }
            set { SetProperty(ref _teachers, value); }
        }

        public ObservableCollection<Chair> Chairs
        {
            get { return _chairs; }
            set { SetProperty(ref _chairs, value); }
        }

        public ObservableCollection<Faculty> Faculties
        {
            get { return _faculties; }
            set { SetProperty(ref _faculties, value); }
        }

        public ObservableCollection<Post> Posts
        {
            get { return _posts; }
            set { SetProperty(ref _posts, value); }
        }

        public ObservableCollection<object> Data
        {
            get { return _data; }
            set { SetProperty(ref _data, value); }
        }

        public ICommand ShowTeachersCommand { get; }
        public ICommand ShowChairsCommand { get; }
        public ICommand ShowFacultiesCommand { get; }
        public ICommand ShowPostsCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }

        public MainViewModel()
        {
            Teachers = new ObservableCollection<Teacher>();
            Chairs = new ObservableCollection<Chair>();
            Faculties = new ObservableCollection<Faculty>();
            Posts = new ObservableCollection<Post>();

            ShowTeachersCommand = new RelayCommand(ShowTeachers);
            ShowChairsCommand = new RelayCommand(ShowChairs);
            ShowFacultiesCommand = new RelayCommand(ShowFaculties);
            ShowPostsCommand = new RelayCommand(ShowPosts);
            AddCommand = new RelayCommand(Add, CanAdd);
            DeleteCommand = new RelayCommand(Delete, CanDelete);

            Data = new ObservableCollection<object>(Teachers.Cast<object>());
            // По умолчанию отображаем данные преподавателей
        }

        private void ShowTeachers(object obj)
        {
            Data = new ObservableCollection<object>(Teachers.Cast<object>());
        }

        private void ShowChairs(object obj)
        {
            Data = new ObservableCollection<object>(Chairs.Cast<object>());
        }

        private void ShowFaculties(object obj)
        {
            Data = new ObservableCollection<object>(Faculties.Cast<object>());
        }

        private void ShowPosts(object obj)
        {
            Data = new ObservableCollection<object>(Posts.Cast<object>());
        }

        private void Add(object obj)
        {
            // Создаем нового преподавателя
            Teacher newTeacher = new Teacher();
            Teachers.Add(newTeacher);

            // При добавлении преподавателя добавляем также данные в другие коллекции,
            // чтобы они синхронизировались по идентификатору
            Chairs.Add(new Chair { Id = newTeacher.Id });
            Faculties.Add(new Faculty { Id = newTeacher.Id });
            Posts.Add(new Post { Id = newTeacher.Id });

            // Устанавливаем нового преподавателя как выбранный элемент
            SelectedItem = newTeacher;
        }

        private bool CanAdd(object obj)
        {
            // Разрешаем добавление 
            return true;
        }

        private void Delete(object obj)
        {
            if (SelectedItem != null)
            {
                // Удаляем элемент из Teachers
                if (SelectedItem is Teacher teacher)
                {
                    Teachers.Remove(teacher);

                    // Удаляем элементы из других коллекций по идентификатору
                    Chairs.Remove(Chairs.FirstOrDefault(c => c.Id == teacher.Id));
                    Faculties.Remove(Faculties.FirstOrDefault(f => f.Id == teacher.Id));
                    Posts.Remove(Posts.FirstOrDefault(p => p.Id == teacher.Id));
                }

                // Сбрасываем выбранный элемент после удаления
                SelectedItem = null;
            }
        }

        private bool CanDelete(object obj)
        {
            // Разрешаем удаление, если выбран какой-либо элемент
            return SelectedItem != null;
        }

        public object SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged();
                }
            }
        }

        // Реализация интерфейса INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
