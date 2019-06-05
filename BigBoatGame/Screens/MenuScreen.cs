﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BigBoatGame.Screens
{
    public partial class MenuScreen : UserControl
    {
        public XmlWriter writer;
        public MenuScreen()
        {
            InitializeComponent();
            GameForm.yank = true;
            flipperButton.Text = "USA";
            flipperButton.BackgroundImage = Properties.Resources.AmericanFlag;
            displayBox.BackgroundImage = Properties.Resources.F4F_4_Menu;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            GameForm.ChangeScreen(this, "GameScreen");
        }
        private void vsButton_Click(object sender, EventArgs e)
        {
            GameForm.vs = true;
            GameForm.ChangeScreen(this, "GameScreen");
        }

        private void highscoreButton_Click(object sender, EventArgs e)
        {
            GameForm.ChangeScreen(this, "HighScreen");
        }

        private void howButton_Click(object sender, EventArgs e)
        {
            GameForm.ChangeScreen(this, "HowScreen");
        }

        private void flipperButton_Click(object sender, EventArgs e)
        {
          
            GameForm.yank = !GameForm.yank;
            if (GameForm.yank)
            {
                flipperButton.Text = "USA";
                flipperButton.BackgroundImage = Properties.Resources.AmericanFlag;
                displayBox.BackgroundImage = Properties.Resources.F4F_4_Menu;
            }
            else
            {
                flipperButton.Text = "Japan";
                flipperButton.BackgroundImage = Properties.Resources.JapaneseFlag;
                displayBox.BackgroundImage = Properties.Resources.A6M2_Menu;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            GameForm.scores.Add(new Score { name = "DIE", number = "12" });
            writer = XmlWriter.Create("Resources/HighScores.xml"); // make reader
            writer.WriteStartElement("HighScores");

            for(int i = 0; i < 10; i++)
            { 

                //Write sub-elements
                writer.WriteStartElement("player");
                writer.WriteAttributeString("number", GameForm.scores[i].number);
                writer.WriteAttributeString("name", GameForm.scores[i].name);
                writer.WriteEndElement();
            }
            
            writer.WriteEndElement();
            // end the root element

            //Write the XML to file and close the writer
            writer.Close();


            Application.Exit();
        }

      
    }
}
