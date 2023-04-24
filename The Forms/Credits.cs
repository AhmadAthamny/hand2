using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hand2
{
    public partial class Credits : Form
    {
        Admin ad = new Admin();
        bool increasing = false;
        int ticks = 0;
        Form sourceform;
        public Credits(Form source_form)
        {
            InitializeComponent();
            this.sourceform = source_form;
            this.panel1.Location = new Point(0, this.Height);
            MakeCreditsList(ad.returnAllAdmins());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!increasing)
                panel1.Location = new Point(panel1.Location.X, panel1.Location.Y - 1);
            else if (increasing && this.Height < CopyRights.Height)
            {
                this.Height++;
                panel1.Location = new Point(panel1.Location.X, panel1.Location.Y + 1);
            }
            else if(increasing) /// After taking it down, this counts 40 ticks before moving it up again.
                ticks++;

            if (ticks == 45)
                increasing = false; ///////////// After X ticks, it changes "increasing" to false so the it moves up.

            int y_constant = this.Height;
            if (y_constant == 2) ///// 2 is the minimum for a form's height set programmatically.
            {
                if (ticks == 45) ////// When the little drop-down reaches the top, then start shortening the width.
                {
                    if (this.Width == 2) this.Close();
                    timer1.Interval = 11;
                    this.Width -= 2;
                    this.Left++;
                }
                else
                {
                    CopyRights.Text = "Officially Directed by Ahmad Athamny";
                    increasing = true;
                }
            }
            else if (!increasing) ////// Checks if the credits were moving down, if not, move it up.
            {
                int y_panel = panel1.Height + panel1.Location.Y;
                if (y_panel - y_constant < 0)
                    this.Height--;
            }
        }
        private void MakeCreditsList(User[] array)
        {
            int current_y = 0;
            int last_level = -1;
            Label rank;
            Label people;
            string level_name = "";
            for (int i = 0; i < array.Length; i++)
            {
                if (ad.returnAdminLevelName(last_level) != ad.returnAdminLevelName(array[i].level))
                {
                    current_y += 85;
                    rank = returnRankLabel(current_y);
                    level_name = ad.returnAdminLevelName(array[i].level);
                    if(level_name == "None")
                        level_name = "Other";
                    rank.Text = level_name+"s"; // Huh because admin ranks are in the "single" form. We need to add an "s" to make it multiple. English ENGLISH!
                    panel1.Controls.Add(rank);
                    last_level = array[i].level;
                }
                current_y += 20;
                people = returnPeopleLabel(current_y);
                people.Text = array[i].name;
                panel1.Controls.Add(people);
            }
            current_y += 60;
            Hand2Pic.Location = new Point((this.Width-Hand2Pic.Width)/2, current_y);
            current_y += Hand2Pic.Height + 15;
            CopyRights.Width = this.Width;
            CopyRights.Text = "Hand2 © Copyrights reserved to Hand2, " + DateTime.Now.Year;
            CopyRights.Location = new Point(CopyRights.Location.X, current_y);
            
        }
        private Label returnRankLabel(int y)
        {
            Label textLabel = new Label()
            {
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new System.Drawing.Font(Font.Name, 12),
                Dock = DockStyle.None,
                Location = new Point(0, y),
                Width = this.Width
            };
            return textLabel;
        }
        private Label returnPeopleLabel(int y)
        {
            Label textLabel = new Label()
            {
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new System.Drawing.Font(Font.Name, 10),
                Dock = DockStyle.None,
                Location = new Point(0, y),
                Width = this.Width
            };
            return textLabel;
        }

        private void Credits_FormClosed(object sender, FormClosedEventArgs e)
        {
            sourceform.Enabled = true;
        }

        private void Credits_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                sourceform.Enabled = true;
            }
        }
    }
}
