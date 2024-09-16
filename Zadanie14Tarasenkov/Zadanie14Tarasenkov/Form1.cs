using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Zadanie14Tarasenkov
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Подключаем обработчики событий
            this.Load += new System.EventHandler(this.Form1_Load);
            buttonInput.Click += new System.EventHandler(this.buttonInput_Click);
            comboBoxColors.SelectedIndexChanged += new System.EventHandler(this.comboBoxColors_SelectedIndexChanged);
            buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Заполнение комбинированного списка цветами
            AddColorToComboBox("Красный");
            AddColorToComboBox("Зелёный");
            AddColorToComboBox("Синий");
            AddColorToComboBox("Фиолетовый");
            AddColorToComboBox("Оранжевый");
            AddColorToComboBox("Белый");
        }

        private void AddColorToComboBox(string color)
        {
            // Проверка, существует ли цвет в комбинированном списке
            if (!comboBoxColors.Items.Contains(color))
            {
                comboBoxColors.Items.Add(color);
            }
        }

        private void buttonInput_Click(object sender, EventArgs e)
        {
            // Показываем комбинированный список
            comboBoxColors.Visible = true;
        }

        private void comboBoxColors_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Переносим выбранный цвет на ярлык
            labelColor.Text = comboBoxColors.SelectedItem.ToString();

            // Скрываем комбинированный список
            comboBoxColors.Visible = false;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            // Очищаем текст ярлыка
            labelColor.Text = string.Empty;
        }

        private void labelColor_Click(object sender, EventArgs e)
        {

        }
    }
}
