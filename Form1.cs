using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project4_Michuta
{
    public partial class Form1 : Form
    {
        public int ij,ij_from, ij_to;
        public char[] abc = new char[32];
        public Form1()
        {
            char c = 'A';
            for (int i = 0; i < 32; i++)
            {
                abc[i] = c;
                c++;
            }
            InitializeComponent();
        }

        public void create_Click(object sender, EventArgs e)
        {
            ij = Convert.ToInt32(number.Text);
            if (r_graf_1.Checked == true && number.Text.Any() == true)
            {
                ij_from = ij;
                graf_1.RowCount = ij_from + 1;
                graf_1.ColumnCount = ij_from + 1;
                for(int i = 1; i <= ij_from; i++)
                {   
                    graf_1.Rows[i].Cells[0].Value = abc[i-1];
                    graf_1.Rows[0].Cells[i].Value = abc[i-1];
                }
                for (int i = 1; i <= ij_from; i++)
                {
                    for (int j = 1; j <= ij_from; j++)
                    {
                        graf_1.Rows[i].Cells[j].Value = 0;
                    }
                }
            }
            else
                if (r_graf_2.Checked == true && number.Text.Any() == true)
            {
                ij_to = ij;
                graf_2.RowCount = ij_to + 1;
                graf_2.ColumnCount = ij_to + 1;
                for (int i = 1; i <= ij_to; i++)
                {
                    graf_2.Rows[i].Cells[0].Value = abc[i - 1];
                    graf_2.Rows[0].Cells[i].Value = abc[i - 1];
                }
                for (int i = 1; i <= ij_to; i++)
                {
                    for (int j = 1; j <= ij_to; j++)
                    {
                        graf_2.Rows[i].Cells[j].Value = 0;
                    }
                }
            }
        }
        private void r_graf_1_CheckedChanged(object sender, EventArgs e)
        {
            if (r_graf_1.Checked == true)
                r_graf_2.Enabled = false;
            else if(r_graf_1.Checked == false)
                r_graf_2.Enabled = true;
        }
        private void r_graf_2_CheckedChanged(object sender, EventArgs e)
        {
            if (r_graf_2.Checked == true)
                r_graf_1.Enabled = false;
            else if (r_graf_2.Checked == false)
                r_graf_1.Enabled = true;
        }

        private void add_Click(object sender, EventArgs e)
        {
            
            int k=0,l=0,i;
            int x=0, y=0;
            char X, Y;
            if(from.Text.Any() == false || to.Text.Any() == false)
            {
                MessageBox.Show("Введіть всі вешини", "Error");
            }
            else
            {
                X = Convert.ToChar(from.Text);
                Y = Convert.ToChar(to.Text);
                X = Char.ToUpper(X);
                Y = Char.ToUpper(Y);
                if (r_graf_1.Checked == true )
                {
                    for (i = 0; i < ij_from; i++)
                    {
                        if (X == abc[i])
                        {
                            k++;
                        }
                        if (Y == abc[i])
                        {
                            l++;
                        }
                    }
                    if (k == 1 && l == 1)
                    {
                        for (i = 1; i <= ij_from; i++)
                        {
                            if (X == abc[i - 1])
                                x = i;
                            if (Y == abc[i - 1])
                                y = i;
                        }
                        graf_1.Rows[x].Cells[y].Value = 1;
                        graf_1.Rows[y].Cells[x].Value = 1;
                    }
                    else
                    {
                        MessageBox.Show("Ви ввели не існуючу вершину", "Error");
                    }
                }
                else
                    if (r_graf_2.Checked == true)
                {
                    for (i = 0; i < ij_to; i++)
                    {
                        if (X == abc[i])
                        {
                            k++;
                        }
                        if (Y == abc[i])
                        {
                            l++;
                        }
                    }
                    if (k == 1 && l == 1)
                    {
                        for (i = 1; i <= ij_to; i++)
                        {
                            if (X == abc[i - 1])
                                x = i;
                            if (Y == abc[i - 1])
                                y = i;
                        }
                        graf_2.Rows[x].Cells[y].Value = 1;
                        graf_2.Rows[y].Cells[x].Value = 1;
                    }
                    else
                    {
                        MessageBox.Show("Ви ввели не існуючу вершину", "Error");
                    }
                }
            }
        }

        private void association_Click(object sender, EventArgs e)
        {
            fgraf.RowCount = Math.Max(ij_from, ij_to) + 1;
            fgraf.ColumnCount = Math.Max(ij_from, ij_to) + 1;
            int k = Math.Max(ij_from, ij_to)+1;
            int l = Math.Min(ij_from, ij_to)+1;
            if (ij_from>=ij_to)
            {
                for (int i = 0; i < k; i++)
                {
                    for (int j = 0; j < k; j++)
                    {
                        fgraf.Rows[i].Cells[j].Value = graf_1.Rows[i].Cells[j].Value;
                    }
                }
                for (int i = 1; i < l; i++)
                {
                    for (int j = 1; j < l; j++)
                    {
                        if ((int)graf_2.Rows[i].Cells[j].Value == 1)
                        {
                            fgraf.Rows[i].Cells[j].Value = graf_2.Rows[i].Cells[j].Value;
                        }
                    }
                }
            }
            else
            if (ij_to >= ij_from)
            {
                for (int i = 0; i < k; i++)
                {
                    for (int j = 0; j < k; j++)
                    {
                        fgraf.Rows[i].Cells[j].Value = graf_2.Rows[i].Cells[j].Value;
                    }
                }
                for (int i = 1; i < l; i++)
                {
                    for (int j = 1; j < l; j++)
                    {
                        if ((int)graf_1.Rows[i].Cells[j].Value == 1)
                        {
                            fgraf.Rows[i].Cells[j].Value = graf_1.Rows[i].Cells[j].Value;
                        }
                    }
                }
            }
        }

        private void crossing_Click(object sender, EventArgs e)
        {
            fgraf.RowCount = Math.Max(ij_from, ij_to) + 1;
            fgraf.ColumnCount = Math.Max(ij_from, ij_to) + 1;
            int k = Math.Max(ij_from, ij_to) + 1;
            int l = Math.Min(ij_from, ij_to) + 1;
            for (int i = 1; i < k; i++)
            {
                fgraf.Rows[0].Cells[i].Value = abc[i-1];
                fgraf.Rows[i].Cells[0].Value = abc[i-1];
            }
            for (int i = 1; i < k; i++)
            {
                for (int j = 1; j < k; j++)
                {
                    fgraf.Rows[i].Cells[j].Value = 0;
                }
            }
            for (int i = 1; i < l; i++)
            {
                for (int j = 1; j < l; j++)
                {
                    if ((int)graf_2.Rows[i].Cells[j].Value == (int)graf_2.Rows[i].Cells[j].Value && (int)graf_2.Rows[i].Cells[j].Value == 1 )
                    {
                        fgraf.Rows[i].Cells[j].Value = graf_2.Rows[i].Cells[j].Value;
                    }
                    else
                    {
                        fgraf.Rows[i].Cells[j].Value = 0;
                    }
                }
            }
        }

        private void difference_1_Click(object sender, EventArgs e)
        {
            fgraf.RowCount = ij_from + 1;
            fgraf.ColumnCount = ij_from + 1;
            int k = ij_from + 1;
            int l = ij_to + 1;
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    fgraf.Rows[i].Cells[j].Value = graf_1.Rows[i].Cells[j].Value;
                }
            }
            for (int i = 1; i < l; i++)
            {
                for (int j = 1; j < l; j++)
                {
                    if ((int)graf_2.Rows[i].Cells[j].Value == 1 && i < k && j < k)
                    {
                        fgraf.Rows[i].Cells[j].Value = 0;
                    }
                }
            }
        }

        private void difference_2_Click(object sender, EventArgs e)
        {
            fgraf.RowCount = ij_to + 1;
            fgraf.ColumnCount = ij_to + 1;
            int k = ij_to + 1;
            int l = ij_from + 1;
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    fgraf.Rows[i].Cells[j].Value = graf_2.Rows[i].Cells[j].Value;
                }
            }
            for (int i = 1; i < l; i++)
            {
                for (int j = 1; j < l; j++)
                {
                    if ((int)graf_1.Rows[i].Cells[j].Value == 1 && i<k && j<k)
                    {
                        fgraf.Rows[i].Cells[j].Value = 0;
                    }
                }
            }
        }

        private void addition_Click(object sender, EventArgs e)
        {
            fgraf.RowCount = ij_from + 1;
            fgraf.ColumnCount = ij_from + 1;
            int l = ij_from + 1;
            for (int i = 1; i < l; i++)
            {
                fgraf.Rows[0].Cells[i].Value = abc[i - 1];
                fgraf.Rows[i].Cells[0].Value = abc[i - 1];
            }
            for (int i = 1; i < l; i++)
            {
                for (int j = 1; j < l; j++)
                {
                    if((int)graf_1.Rows[i].Cells[j].Value == 1)
                    {
                        fgraf.Rows[i].Cells[j].Value = 0;
                    }
                    else
                        if(i==j)
                    {
                        fgraf.Rows[i].Cells[j].Value = 0;
                    }
                    else
                        fgraf.Rows[i].Cells[j].Value = 1;


                }
            }
        }

        private void addition2_Click(object sender, EventArgs e)
        {
            fgraf.RowCount = ij_to + 1;
            fgraf.ColumnCount = ij_to + 1;
            int l = ij_to + 1;
            for (int i = 1; i < l; i++)
            {
                fgraf.Rows[0].Cells[i].Value = abc[i - 1];
                fgraf.Rows[i].Cells[0].Value = abc[i - 1];
            }
            for (int i = 1; i < l; i++)
            {
                for (int j = 1; j < l; j++)
                {
                    if ((int)graf_2.Rows[i].Cells[j].Value == 1)
                    {
                        fgraf.Rows[i].Cells[j].Value = 0;
                    }
                    else
                         if (i == j)
                    {
                        fgraf.Rows[i].Cells[j].Value = 0;
                    }
                    else
                    fgraf.Rows[i].Cells[j].Value = 1;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int k = 0;
            if(ij_from==ij_to)
            {
                for (int i = 1; i <= ij_from; i++)
                {
                    for (int j = 1; j <= ij_from; j++)
                    {
                        if((int)graf_1.Rows[i].Cells[j].Value == (int)graf_2.Rows[i].Cells[j].Value)
                        {
                            k++;
                        }
                    }
                }
                if (k == (ij_from*ij_to))
                {
                    MessageBox.Show("Графи ізоморфні", "");
                }
                else
                {
                    MessageBox.Show("Графи не є ізоморфними", "");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 vz = new Form2();
            vz.Show();
        }

        private void number_KeyPress(object sender, KeyPressEventArgs e)
        {
            char num = e.KeyChar;
            if (!Char.IsDigit(num) && num != 8)
                
                e.Handled = true;
        }

        private void from_KeyPress(object sender, KeyPressEventArgs e)
        {
            char num = e.KeyChar;
            if (!Char.IsLetter(num) && num != 8)
                e.Handled = true;
        }
    }
}
