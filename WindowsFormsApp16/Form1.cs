using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp16
{
    public partial class Form1 : Form
    {
        //enum It provides a way to represent a group of related named constants as a unique type, making the code more readable and self-documenting.
        public enum Player
            {
                X, O
            }
        Player currentPlayer;
        Random random = new Random();
        int CPUWinCount = 0;
        int playerWinCount = 0;
        List<Button> buttons;
        public Form1()
        {
            InitializeComponent();
            RestartGame();
        }

        private void CPUmove(object sender, EventArgs e)
        {
            // If there are still unselected buttons on the board
            if (buttons.Count > 0)
            {
                // Randomly choose an index from the available buttons
                // Use the random index to access a random button
                int index = random.Next(buttons.Count);
                 index = 0;
                buttons[index].Enabled = false;
                currentPlayer = Player.O;
                buttons[index].Text = currentPlayer.ToString();
                buttons[index].BackColor = Color.DarkOliveGreen;
                buttons.RemoveAt(index);
                CheckGame();// Check if the game is won or tied
                CPUTimer.Stop();// Stop the CPU move after making a selection

            }

            }

            private void PlayerClickButton(object sender, EventArgs e)
        {
            // Event handler for the player's button click
            // Cast sender to Button type
            var button = (Button)sender;
            currentPlayer = Player.X;
            button.Text = currentPlayer.ToString();
            button.Enabled = false;
            button.BackColor = Color.Cyan;
            buttons.Remove(button);
            CheckGame();// Check if the game is won or tied
            CPUTimer.Start();// Allow the CPU to make a move


        }

        private void RestartGame(object sender, EventArgs e)
        {
            // Event handler for restarting the game
            RestartGame();
        }
        private void CheckGame()
        {
            // Check if any winning condition is met for either player
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
                || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
                || button7.Text == "X" && button8.Text == "X" && button9.Text == "X"
                || button3.Text == "X" && button4.Text == "X" && button7.Text == "X"
                || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
                || button1.Text == "X" && button6.Text == "X" && button9.Text == "X"
               || button1.Text == "X" && button5.Text == "X" && button7.Text == "X"
                || button3.Text == "X" && button5.Text == "X" && button9.Text == "X"
               || button3.Text == "X" && button4.Text == "X" && button7.Text =="X")
            //button1.BackColor = Color.PowderBlue; //just in case
            {
                CPUTimer.Stop();
                MessageBox.Show("Player Wins", "N Says");
                playerWinCount++;
                label1.Text = "Player Wins" + playerWinCount;
                RestartGame();
                //button1.BackColor = Color.PowderBlue;

            }
            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
              || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
              || button7.Text == "O" && button8.Text == "O" && button9.Text == "O"
              || button3.Text == "O" && button4.Text == "O" && button7.Text == "O"
              || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
               || button1.Text == "O" && button6.Text == "O" && button9.Text == "O"
             || button1.Text == "O" && button5.Text == "O" && button7.Text == "O"
              || button3.Text == "O" && button5.Text == "O" && button9.Text == "O"
             || button3.Text == "O" && button4.Text == "O" && button7.Text =="O")
             
            {
                CPUTimer.Stop();
                MessageBox.Show("CPU Wins", "N Says");
                CPUWinCount++;
                label2.Text = "CPU Wins" + CPUWinCount;
                RestartGame();

            }

        }
        private void RestartGame()
        {
            // Reset the game state and enable all buttons
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            foreach (Button x in buttons)
            {
                x.Enabled = true;
                x.Text = "!";
                x.BackColor = DefaultBackColor;
                
            }
            MessageBox.Show("you are starting the game");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
