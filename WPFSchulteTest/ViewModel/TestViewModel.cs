﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp2
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    internal class TestViewModel
    {
        private ObservableCollection<Cell> cells;
        private readonly RelayCommand exit;
        private readonly int elementCount;
        private List<int> numbers;
        private string nextNumber;
        public string currentNumber;

        public IEnumerable<Cell> Cells => cells;
        public ICommand Exit => exit;

        public string CurrentNumber
        {
            get => currentNumber;
            set
            {
                currentNumber = value;
                if (!int.TryParse(currentNumber, out int number)) number = 0;
                int index = numbers.IndexOf(number);

                if (currentNumber == nextNumber)
                {
                    cells[index].CanPress = true;
                    if (nextNumber == (elementCount - 1).ToString())
                    {
                        Quit();
                        cellsInit();
                        return;
                    }
                    nextNumber = (++number).ToString();
                }
                cells[index].Pressed = true;
                cells[index].Pressed = false;
                cells[index].CanPress = false;
            }
        }


        public TestViewModel(int rows)
        {
            numbers = new List<int>();
            currentNumber = nextNumber = string.Empty;
            cells = new();
            exit = new((o) => Quit());
            if (rows % 2 == 0) rows++;
            elementCount = rows * rows;
            cellsInit();
        }

        private void cellsInit()
        {
            int zeroIndex;
            Random rnd = new();
            nextNumber = "1";
            cells.Clear();
            numbers.Clear();
            numbers.AddRange(Enumerable.Range(0, elementCount).OrderBy(n => rnd.Next()).ToList());
            zeroIndex = numbers.IndexOf(0);
            (numbers[zeroIndex], numbers[elementCount / 2]) = (numbers[elementCount / 2], numbers[zeroIndex]);
            foreach (var item in numbers)
            {
                Cell cell = new();
                Color tmp = Color.FromArgb(255, (byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255));
                if (item != 0)
                {
                    cell.Number = item;
                    cell.BorderColor = new SolidColorBrush(tmp);
                    cell.BackColor = new SolidColorBrush(tmp + Color.FromArgb(255, 60, 60, 60));
                }
                cells.Add(cell);
            }
            cells[elementCount / 2].Eye = true;
        }
        private void Quit()
        {
            if (MessageBox.Show("Do you want to continue ? ", "Exit", MessageBoxButton.YesNo) == MessageBoxResult.Yes) return;
            Application.Current.Shutdown();
        }
    }

}
