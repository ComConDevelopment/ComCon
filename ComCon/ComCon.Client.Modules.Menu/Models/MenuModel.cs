﻿using ComCon.Client.Modules.Menu.Classes;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using ComCon.Client.Base.Classes;

namespace ComCon.Client.Modules.Menu.Models
{
    public class MenuModel : INotifyPropertyChanged
    {
        #region Deklaration


        private ObservableCollection<MenuItem> mCurrentMenuItems = new ObservableCollection<MenuItem>();
        private ObservableCollection<MenuItem> mMenuItems = new ObservableCollection<MenuItem>();
        private DelegateCommand mNextCommand;
        private DelegateCommand mPreviousCommand;
        private int mPosition;

        #endregion

        #region Properties

        public ObservableCollection<MenuItem> CurrentMenuItems
        {
            get { return (MenuItems.Skip(mPosition * 3).Take(3).ToObservableCollection()); }
        }

        public ObservableCollection<MenuItem> MenuItems
        {
            get { return (mMenuItems); }
            set { mMenuItems = value; RaisePropertyChanged("MenuItems"); }
        }

        public DelegateCommand NextCommand
        {
            get { return (mNextCommand); }
            set { mNextCommand = value; RaisePropertyChanged("NextCommand"); }
        }

        public DelegateCommand PreviousCommand
        {
            get { return (mPreviousCommand); }
            set { mPreviousCommand = value; RaisePropertyChanged("PreviousCommand"); }
        }

        #endregion

        #region Konstruktor

        public MenuModel()
        {
            NextCommand = new DelegateCommand(Next);
            PreviousCommand = new DelegateCommand(Previous);
            LoadMenu();
        }

        #endregion

        #region Events



        #endregion

        #region Diverses

        private void Next()
        {
            if (MenuItems.Skip((mPosition + 1) * 3).Take(3).Count() > 0)
            {
                mPosition += 1;
            }
            RaisePropertyChanged("CurrentMenuItems");
        }

        private void Previous()
        {
            if (mPosition - 1 >= 0)
            {
                mPosition -= 1;
            }            
            RaisePropertyChanged("CurrentMenuItems");
        }


        private void LoadMenu()
        {
            MenuItems.Add(new MenuItem("Test1", "MainView", Regions.Main));
            MenuItems.Add(new MenuItem("Test2", "MainView", Regions.Main));
            MenuItems.Add(new MenuItem("Test3", "MainView", Regions.Main));
            MenuItems.Add(new MenuItem("Test4", "MainView", Regions.Main));
            MenuItems.Add(new MenuItem("Test5", "MainView", Regions.Main));
            MenuItems.Add(new MenuItem("Test6", "MainView", Regions.Main));
            MenuItems.Add(new MenuItem("Test7", "MainView", Regions.Main));
            MenuItems.Add(new MenuItem("Test8", "MainView", Regions.Main));
            RaisePropertyChanged("CurrentMenuItems");
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string pPropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(pPropertyName));
            }
        }

        #endregion
    }
}