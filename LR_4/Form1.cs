using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LR_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void selectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            
            string filePath = openFileDialog.FileName;

            
            if (!File.Exists(filePath))
            {
                MessageBox.Show("File not found");
                return;
            }

            
            string[] lines = File.ReadAllLines(filePath);

            // Flip each line, not individual words
            for (int i = 0; i < lines.Length; i++)
            {
                string[] words = lines[i].Split(' '); 
                for (int j = 0; j < words.Length; j++)
                {
                    words[j] = ReverseString(words[j]); 
                }

                lines[i] = string.Join(" ", words); 
                lines[i] = ReverseString(lines[i]); 
            }

            
            string outputFilePath = Path.Combine(Path.GetDirectoryName(filePath), "mirrored_" + Path.GetFileNameWithoutExtension(filePath) + ".tmp");

            
            File.WriteAllLines(outputFilePath, lines);

            MessageBox.Show("File created successfully");
        }
        
        private string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }

}
