﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DownloadManager.Models;
using DownloadManager.Views;

namespace DownloadManager.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged, IObserver<File>
    {
        //TODO url for test
        //http://212.183.159.230/5MB.zip 5mb
        //http://212.183.159.230/10MB.zip 10mb
        //http://212.183.159.230/50MB.zip 50mb
        //http://212.183.159.230/512MB.zip
        //http://212.183.159.230/1GB.zip
        //observer part start
        private IDisposable _unsubscriber;

        public virtual void Subscribe(IObservable<File> provider)
        {
            if (provider != null)
                _unsubscriber = provider.Subscribe(this);
        }

        public virtual void OnCompleted()
        {
            //TODO inplement download competed alert
            Console.WriteLine(@"The download has completed!");
            this.Unsubscribe();
        }

        public virtual void OnError(Exception e)
        {
            //TODO inplement error download alert
            Console.WriteLine(@"Error!");
        }

        public virtual void OnNext(File value)
        {
            MessageBox.Show(@"New file: "+value.FileName+@" is downloaded");
            FilesList.Add(value);
        }

        public virtual void Unsubscribe()
        {
            _unsubscriber.Dispose();
        }
        //observer part end

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public event EventHandler Closing;

        private RelayCommand _openSetting;
        private RelayCommand _addUrl;
        private RelayCommand _removeUrl;
        private RelayCommand _todayFiles;
        private RelayCommand _allFiles;
        private RelayCommand _biggestFiles;
        private RelayCommand _groupFiles;
        private RelayCommand _network;
        private List<File> _filesList = new List<File>();
        private readonly FilesContext _filesContext = new FilesContext();
        private readonly string _sourcePath = Properties.Settings.Default.Path;
        private Folder _groupedFiles;

        public RelayCommand Network
        {
            get { return _network ?? (_network = new RelayCommand(o =>
            {
                // Create receiver, command, and invoker
                NetworkView networkView = new NetworkView();
                Command command = new OpenCommand(networkView);
                Invoker invoker = new Invoker();

                // Set and execute command
                invoker.SetCommand(command);
                invoker.ExecuteCommand();
            })); }
        }

        public List<File> FilesList
        {
            get => _filesList;
            set
            {
                _filesList = value;
                OnPropertyChanged(nameof(FilesList));
            }
        }

        public RelayCommand OpenSetting
        {
            get
            {
                return _openSetting ??
                       (_openSetting = new RelayCommand(o =>
                       {
                           // Create receiver, command, and invoker
                           SettingView settingView = new SettingView();
                           Command command = new OpenCommand(settingView);
                           Invoker invoker = new Invoker();

                           // Set and execute command
                           invoker.SetCommand(command);
                           invoker.ExecuteCommand();
                       }));
            }
        }

        public RelayCommand AddUrl
        {
            get
            {
                return _addUrl ??
                       (_addUrl = new RelayCommand(o =>
                       {
                           // Create receiver, command, and invoker
                           AddUrlView addUrlView = new AddUrlView(this);//receiver 
                           Command command = new OpenCommand(addUrlView);
                           Invoker invoker = new Invoker();

                           OnClosing(EventArgs.Empty);
                           // Set and execute command
                           invoker.SetCommand(command);
                           invoker.ExecuteCommand();
                       }));
            }
        }

        public RelayCommand RemoveUrl
        {
            get
            {
                return _removeUrl ??
                       (_removeUrl = new RelayCommand(o =>
                       {
                           //TODO delete url function
                           MessageBox.Show(@"Item is deleted");
                       }));
            }
        }

        public RelayCommand TodayFiles
        {
            get
            {
                return _todayFiles ??
                       (_todayFiles = new RelayCommand(o =>
                       {
                           var filesToday = new FilesToday();
                           FilesList = filesToday.Run();
                       }));
            }
        }

        public RelayCommand BiggestFiles
        {
            get
            {
                return _biggestFiles ??
                       (_biggestFiles = new RelayCommand(o =>
                       {
                           var filesToday = new FilesBiggest();
                           FilesList = filesToday.Run();
                       }));
            }
        }

        public RelayCommand GroupFiles
        {
            get
            {
                return _groupFiles ??
                       (_groupFiles = new RelayCommand(o =>
                       {
                           _groupedFiles = GetGroupedFiles();
                           MessageBox.Show(@"Files were grouped in '" + _sourcePath+@"' !");
                       }));
            }
        }

        private Folder GetGroupedFiles()
        {
            var root = new Folder("root");
            string tmpMonth="";
            string tmpPath="";
            string sourceFile;
            string destinationFile;
            Folder tmpFolder= new Folder("root");
            foreach (var file in _filesContext.Files.ToList())
            {
                if (file.DateTime.ToString("MM yyyy") != tmpMonth)
                {
                    if(tmpFolder.GetName()!="root")
                        root.Add(tmpFolder);
                    tmpMonth = file.DateTime.ToString("MM yyyy");
                    tmpPath = System.IO.Path.Combine(_sourcePath, tmpMonth);
                    tmpFolder = new Folder(tmpPath);
                }
                tmpFolder.Add(new FileItem(file.FileName));
                sourceFile = System.IO.Path.Combine(_sourcePath, file.FileName);
                System.IO.Directory.CreateDirectory(tmpPath);
                destinationFile = System.IO.Path.Combine(tmpPath, file.FileName);
                // To move a file or folder to a new location:
                System.IO.File.Move(sourceFile, destinationFile);
            }
            return root;
        }

        private void CreateArchive()
        {
            //todo create archive from component 
        }

        public RelayCommand AllFiles
        {
            get
            {
                return _allFiles ??
                       (_allFiles = new RelayCommand(o =>
                       {
                           FilesList = _filesContext.Files.ToList();
                       }));
            }
        }

        private void OnClosing(EventArgs e)
        {
            Closing?.Invoke(this, e);
        }
        //private RelayCommand _test;
        //public RelayCommand Test
        //{
        //    get
        //    {
        //        return _test ??
        //               (_test = new RelayCommand(o =>
        //               {
        //                   using (var ctx = new FilesContext())
        //                   {
        //                       var file = new File()
        //                       {
        //                           FileName = "Bill",
        //                           DateTime = DateTime.Now
        //                       };
        //                       ctx.Files.Add(file);
        //                       ctx.SaveChanges();
        //                   }
        //                   var collection = new DownloadsCollection();
        //                   collection.AddItem("First");
        //                   collection.AddItem("Second");
        //                   collection.AddItem("Third");

        //                   Console.WriteLine("Straight traversal:");

        //                   foreach (var element in collection)
        //                   {
        //                       MessageBox.Show(element.ToString());
        //                   }

        //                   //Console.WriteLine("\nReverse traversal:");

        //                   collection.ReverseDirection();

        //               }));
        //    }
        //}
    }
}
