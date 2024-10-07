using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Zadanie16Tarasenkov1
{
    public partial class MainForm : Form
    {
        private VendingMachine vendingMachine;

        public MainForm()
        {
            InitializeComponent();

            vendingMachine = new VendingMachine(5, 5, 5); // Пример инициализации
                                                          // Настройте UI элементы здесь...

            btnStart.Click += BtnStart_Click;
            btnChangePin.Click += BtnChangePin_Click;

            // Другие обработчики...
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            vendingMachine.StartSimulation();
            UpdateEventLog();
        }

        private void BtnChangePin_Click(object sender, EventArgs e)
        {
            string newPin = txtNewPin.Text; // Получите новый PIN из текстового поля
            try
            {
                vendingMachine.ChangePinCode(newPin);
                MessageBox.Show("PIN-код изменен успешно!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtNewPin.Clear();
        }

        private void UpdateEventLog()
        {
            txtEventLog.Text = string.Join(Environment.NewLine, vendingMachine.EventLog.ToArray());
            // Обновите текстовое поле с журналом событий
        }
    }
    public class VendingMachine
    {
        private int width;
        private int height;
        private int depth;
        // private int simulationTime; // Время моделирования
        private string pinCode = "1234"; // Начальный PIN-код
        private List<string> eventLog = new List<string>();
        private Dictionary<string, int> inventory = new Dictionary<string, int>();
        private bool isRunning = false;

        public int Width => width;
        public int Height => height;
        public int Depth => depth;

        private int simulationTime; // Поле для хранения времени моделирования

        // Метод для получения времени моделирования
        public int GetSimulationTime()
        {
            return simulationTime; // Возвращаем текущее время симуляции
        }

        // Метод для установки времени моделирования
        public void SetSimulationTime(int value)
        {
            // Проверка на допустимые значения времени моделирования
            if (value < 0)
            {
                throw new ArgumentException("Время моделирования не может быть отрицательным.");
            }

            // Если симуляция уже запущена, очищаем журнал событий
            if (isRunning)
            {
                eventLog.Clear(); // Сбрасываем журнал событий
                eventLog.Add("Журнал событий сброшен из-за изменения времени симуляции."); // Логируем событие
            }

            simulationTime = value; // Устанавливаем новое значение времени симуляции
        }

        public List<string> EventLog => eventLog;

        public VendingMachine(int width, int height, int depth)
        {
            if (width > 10 &&  height > 20 && depth > 10)
                throw new ArgumentException("Размеры ячеек превышают допустимые значения.");

            this.width = width;
            this.height = height;
            this.depth = depth;

            FillInventory();
        }

        private void FillInventory()
        {
            Random rand = new Random();
            for (int i = 0; i < width * height * depth; i++)
            {
                inventory[$"Item {i + 1}"] = rand.Next(0, 10); // Случайное количество товара от 0 до 9
            }
        }

        public void StartSimulation()
        {
            isRunning = true;
            eventLog.Add("Simulation started.");
            // Здесь можно добавить логику для симуляции покупок
        }

        public void StopSimulation()
        {
            isRunning = false;
            eventLog.Add("Simulation stopped.");
        }

        public void ChangePinCode(string newPin)
        {
            if (newPin.Length == 4)
                pinCode = newPin;
            else
                throw new ArgumentException("PIN-код должен содержать 4 цифры.");
        }

        public bool ValidatePin(string inputPin)
        {
            return pinCode == inputPin;
        }

        // Метод для записи состояния в файл
        public void SaveState(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"{width},{height},{depth},{simulationTime}");
                foreach (var item in inventory)
                {
                    writer.WriteLine($"{item.Key}:{item.Value}");
                }
                writer.WriteLine(string.Join(",", eventLog.ToArray()));
            }
        }

        // Метод для загрузки состояния из файла
        public void LoadState(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                var dimensions = reader.ReadLine().Split(',');
                width = int.Parse(dimensions[0]);
                height = int.Parse(dimensions[1]);
                depth = int.Parse(dimensions[2]);
                simulationTime = int.Parse(dimensions[3]);

                inventory.Clear();
                string line;
                while ((line = reader.ReadLine()) != null && !string.IsNullOrEmpty(line))
                {
                    var parts = line.Split(':');
                    inventory[parts[0]] = int.Parse(parts[1]);
                }

                eventLog.Clear();
                eventLog.AddRange(reader.ReadLine().Split(','));
            }
        }
    }
}