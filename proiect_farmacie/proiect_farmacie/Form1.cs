using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proiect_farmacie
{
    public partial class Form1 : Form
    { 
  
        private Farmacie _farmacie;

        private const int FONT_SIZE = 9;
        private const int DIMENSIUNE_PAS_Y = 25;
        private const int DIMENSIUNE_CONTROL = 120;
        private const int DIMENSIUNE_PAS_X = 120;
        private const int OFFSET_X = 200;

        private List<Label> labels = new List<Label>();

        public Form1(Farmacie farmacie)
        {
            _farmacie = farmacie;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fieldNames = new List<string>()
            {
                "Id",
                "Nume Medicament",
                "Cantitate",
            };

            var fontBold = new Font("Arial", FONT_SIZE, FontStyle.Bold);
            var currentXOffset = OFFSET_X;

            foreach (var labelName in fieldNames)
            {
                var newLabel = new Label();
                newLabel.Width = DIMENSIUNE_CONTROL;
                newLabel.Font = fontBold;
                newLabel.Text = labelName;
                newLabel.Left = currentXOffset;
                newLabel.ForeColor = Color.Black;
                this.Controls.Add(newLabel);
                labels.Add(newLabel);

                currentXOffset += DIMENSIUNE_PAS_X;
            }

            var normalFont = new Font("Arial", FONT_SIZE);
            var offestY = DIMENSIUNE_PAS_Y;

            foreach (var medicament in _farmacie.medicamente)
            {
                currentXOffset = OFFSET_X;
                var currentField = 0;

                foreach (var atribute in medicament.GetAtributes())
                {
                    var newLabel = new Label();
                    newLabel.Width = DIMENSIUNE_CONTROL;
                    newLabel.Font = normalFont;
                    newLabel.Text = atribute;
                    newLabel.Left = currentXOffset;
                    newLabel.Top = offestY;
                    newLabel.ForeColor = Color.Black;
                    this.Controls.Add(newLabel);
                    labels.Add(newLabel);

                    currentXOffset += DIMENSIUNE_PAS_X;
                }

                offestY += DIMENSIUNE_PAS_Y;
            }


        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var label in labels)
            {
                label.Dispose();
            }
        }
    }
}
