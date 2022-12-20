using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Task_10_Forms_PM01_N4
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		static void z10(string Path, TextBox textBox1)
		{
			if (Directory.Exists(@"C:\temp\ALL"))
			{
				MessageBox.Show("Вероятно, данная программа уже выполнялась,\nпожалуйста, удалите папку temp, чтобы программа работала корректно.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			textBox1.Text = "";
			//1 задание
			Directory.CreateDirectory(Path + @"\K1");
			textBox1.Text += String.Format("Папка K1 создана.\r\n");
			Directory.CreateDirectory(Path + @"\K2");
			textBox1.Text += String.Format("Папка K2 создана.\r\n\r\n");
			//2 задание
			File.Create(Path + @"\K1\t1.txt").Close();
			textBox1.Text += String.Format("Файл t1.txt создан.\r\n");
			string t1 = "Мокеева Дарья Алексеевна, 2004 года рождения, место жительства г. Владимир.\n";
			File.WriteAllText(Path + @"\K1\t1.txt", t1);
			textBox1.Text += String.Format("В файл t1.txt записан текст.\r\n");
			File.Create(Path + @"\K1\t2.txt").Close();
			textBox1.Text += String.Format("Файл t2.txt создан.\r\n");
			string t2 = "Мальцева Ксения Александровна, 1992 года рождения, место жительства г. Москва.\n";
			File.WriteAllText(Path + @"\K1\t2.txt", t2);
			textBox1.Text += String.Format("В файл t2.txt записан текст.\r\n\r\n");
			//3 задание
			File.Create(Path + @"\K2\t3.txt").Close();
			textBox1.Text += String.Format("Файл t3.txt был создан.\r\n");
			File.WriteAllText(Path + @"\K2\t3.txt", File.ReadAllText(Path + @"\K1\t1.txt"));
			File.AppendAllText(Path + @"\K2\t3.txt", File.ReadAllText(Path + @"\K1\t2.txt"));
			textBox1.Text += String.Format("В файл t3.txt записан текст.\r\n\r\n");
			//4 задание
			FileInfo f1 = new FileInfo(@"C:\temp\K1\t1.txt");
			FileInfo f2 = new FileInfo(@"C:\temp\K1\t2.txt");
			FileInfo f3 = new FileInfo(@"C:\temp\K2\t3.txt");
			textBox1.Text += String.Format($"Имя файла: {f1.Name}\r\nВремя создания: {f1.CreationTime}\nРазмер: {f1.Length}\r\n");
			textBox1.Text += String.Format($"Имя файла: {f2.Name}\r\nВремя создания: {f2.CreationTime}\nРазмер: {f2.Length}\r\n");
			textBox1.Text += String.Format($"Имя файла: {f3.Name}\r\nВремя создания: {f3.CreationTime}\nРазмер: {f3.Length}\r\n\r\n");
			//5-6 задание
			f2.MoveTo(@"C:\temp\K2\t2.txt");
			textBox1.Text += String.Format("Файл t2.txt был перемещен в папку K2\r\n");
			f1.CopyTo(@"C:\temp\K2\t1.txt");
			textBox1.Text += String.Format("Файл t1.txt был скопирован в папку K2\r\n\r\n");
			//7 задание
			Directory.Move(@"C:\temp\K2", @"C:\temp\ALL");
			textBox1.Text += String.Format("Папка K2 была переименована в All.\r\n");
			File.Delete(@"C:\temp\K1\t1.txt");
			Directory.Delete(@"C:\temp\K1");
			textBox1.Text += String.Format("Папка K1 была удалена\r\n\r\n");
			//8 Задание
			DirectoryInfo dinf = new DirectoryInfo(@"C:\temp\ALL");
			FileInfo[] finf = dinf.GetFiles();

			foreach (FileInfo f in finf)
			{
				textBox1.Text += String.Format("Полное имя файла: " + f.FullName.ToString() + "\r\n");
				textBox1.Text += String.Format("Атрибуты: " + f.Attributes.ToString()) + "\r\n";
				textBox1.Text += String.Format("Существует ли файл: " + f.Exists.ToString()) + "\r\n";
				textBox1.Text += String.Format("Размер файла: " + f.Length.ToString()) + " байт" + "\r\n";
				textBox1.Text += String.Format("Расширение файла: " + f.Extension.ToString() + "\r\n\r\n");
			}
		}
		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				string path = @"C:\temp";
				if (Directory.Exists(path))
				{
					z10(path, textBox1);
					
				}
				else
				{
					Directory.CreateDirectory(path);
					z10(path, textBox1);
				}
			}
			catch
			{
				MessageBox.Show("Неизвестная ошибка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
