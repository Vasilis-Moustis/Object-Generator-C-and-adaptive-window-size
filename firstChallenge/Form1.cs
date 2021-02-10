using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firstChallenge
{
	public partial class Form1 : Form
	{

		List<Button> ButtonList = new List<Button>();

		private Random r = new Random();

		int count = 1;

		int N;

		int x = 10;
		int y = 40;
		
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (!int.TryParse(textBox1.Text, out N))
			{
				MessageBox.Show("Please insert an number!");
				return;
			}
			else
			{
				ButtonList = new List<Button>();
				N = Int32.Parse(textBox1.Text);
				for (int i = 0; i < N; i++)
				{
					Button b = new Button();
					ButtonList.Add(b);
				}

				foreach (Button b in ButtonList)
				{
					if (x < this.Width - b.Width)
					{
						b.Location = new Point(x, y);
						b.Width = 40;
						b.Height = 40;
						Color randomColor = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
						b.BackColor = randomColor;
						b.Text = count.ToString();
						this.Controls.Add(b);
						x += b.Width + 40;
						count++;
					}
					else
					{
						x = 10;
						y += b.Height + 40;
						b.Location = new Point(x, y);
						b.Width = 40;
						b.Height = 40;
						Color randomColor = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
						b.BackColor = randomColor;
						b.Text = count.ToString();
						this.Controls.Add(b);
						x += b.Width + 40;
						count++;
					}
				}
			}
		}

		private void Form1_Resize(object sender, EventArgs e)
		{
			count = 1;
			x = 10;
			y = 70;
			foreach (Button b in ButtonList)
			{
				if (y < this.Height - b.Height)
				{
					if (x < this.Width -  b.Width)
					{
						b.Location = new Point(x, y);
						x += b.Width + 40;
					}
					else
					{
						x = 10;
						y += b.Height + 40;
						b.Location = new Point(x, y); 
						x += b.Width + 40;
					}
				}
			}
		}
	}
}
